using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldmover : MonoBehaviour
{
    void Update()
    {
      this.transform.Translate(new Vector3 (-3f, 0f, 0f) * Time.deltaTime,Space.Self);
    }
}
