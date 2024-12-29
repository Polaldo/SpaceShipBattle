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

    void Update()
    {
        foreach (ParallaxLayer layer in layers)
        {
            if (layer.layer != null)
            {
                float temp = layer.layer.position.y * (1f - layer.speed.y);
                Vector3 newPos = layer.layer.position;
                newPos.y += layer.speed.y * Time.deltaTime; // Move Y

                layer.layer.position = newPos;

                if (temp > layer.startPos + layer.length)
                    layer.startPos += layer.length;
                else if (temp < layer.startPos - layer.length)
                    layer.startPos -= layer.length;

            }
        }
    }
}
