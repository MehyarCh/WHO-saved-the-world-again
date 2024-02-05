using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    public DalekRedGenerator redGenerator;

    void Update()
    {
        transform.Translate(Vector2.left * redGenerator.currSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("SpawnPoint")){
            redGenerator.randomizeRedSpawn();
        }
        if(collision.gameObject.CompareTag("DestroyPoint")){
            Destroy(this.gameObject);
        }
    }
}
