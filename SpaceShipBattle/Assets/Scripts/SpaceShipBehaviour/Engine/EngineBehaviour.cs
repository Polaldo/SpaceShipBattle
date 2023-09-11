using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject engineEffects = transform.GetChild(0).gameObject;
        SpriteRenderer spriteRenderer = engineEffects.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = PlayerManager.Instance.shipData.engineData.spriteEngine;
        Animator animator = engineEffects.GetComponent<Animator>();
        animator.runtimeAnimatorController = PlayerManager.Instance.shipData.engineData.animationEngine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
