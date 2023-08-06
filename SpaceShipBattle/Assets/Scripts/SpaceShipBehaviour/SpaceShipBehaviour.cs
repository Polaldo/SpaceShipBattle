using UnityEngine;

public class SpaceShipBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
