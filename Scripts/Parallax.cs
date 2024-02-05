using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, i;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        i = 0;
    }

    void Update()
    {
        float temp = cam.transform.position.x * (parallaxEffect - 1) + length * i;
        float dist = (cam.transform.position.x * (1 - parallaxEffect));

        transform.position = new Vector3(startpos - dist, transform.position.y, transform.position.z);

        if (temp < startpos - length)
        {
            startpos += length;
            i += 2;
        }
    }
}
