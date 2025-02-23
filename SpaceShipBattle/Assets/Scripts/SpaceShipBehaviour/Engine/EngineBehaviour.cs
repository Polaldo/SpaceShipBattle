using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{

    void Start()
    {
        GameObject engineEffects = transform.GetChild(0).gameObject;
        SpriteRenderer spriteRenderer = engineEffects.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = PlayerManager.Instance.shipData.engineData.spriteEngine;
        Animator animator = engineEffects.GetComponent<Animator>();
        animator.runtimeAnimatorController = PlayerManager.Instance.shipData.engineData.animationEngine;
    }
}
