using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public float length, startPos;
        public Transform layer;
        public Vector2 speed;   
    }

    public ParallaxLayer[] layers;

    private void Start()
    {
        foreach(ParallaxLayer layer in layers)
        {
            layer.startPos = transform.position.y;
            layer.length = layer.layer.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        }
    }

    void FixedUpdate()
    {
        foreach (ParallaxLayer layer in layers)
        {
            if (layer.layer != null)
            {
                Vector3 newPos = layer.layer.position;
                newPos.y -= layer.speed.y * Time.deltaTime;
                layer.layer.position = newPos;

                checkLayerBounds(layer, newPos);

            }
        }
    }

    private static void checkLayerBounds(ParallaxLayer layer, Vector3 newPos)
    {
        if (newPos.y <= layer.startPos - layer.length)
        {
            newPos.y += layer.length;
            layer.layer.position = newPos;
        }
        else if (newPos.y >= layer.startPos + layer.length)
        {
            newPos.y -= layer.length;
            layer.layer.position = newPos;
        }
    }
}
