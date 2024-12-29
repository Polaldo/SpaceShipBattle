using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _length, _startPos;
    public GameObject MyCamera;
    public float ParallaxEffect;
    void Start()
    {
        _startPos = transform.position.y;
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        float temp = MyCamera.transform.position.y * (1f - ParallaxEffect);
        float dist = (MyCamera.transform.position.y * ParallaxEffect);

        transform.position = new Vector3(_startPos + dist, transform.position.y, transform.position.z);

        if (temp > _startPos + _length)
            _startPos += _length;
        else if (temp < _startPos - _length)
            _startPos -= _length;
    }
}
