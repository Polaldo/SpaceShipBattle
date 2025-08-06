using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailWigger : MonoBehaviour
{
    public float wiggleAmount = 0.1f;
    public float wiggleSpeed = 5f;

    private Vector3 originalLocalPos;

    void Start()
    {
        originalLocalPos = transform.localPosition;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount;
        float y = Mathf.Cos(Time.time * wiggleSpeed * 0.8f) * wiggleAmount;
        transform.localPosition = originalLocalPos + new Vector3(x, y, 0);
    }
}
