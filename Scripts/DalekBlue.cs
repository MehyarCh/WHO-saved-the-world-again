using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DalekBlue : MonoBehaviour
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
    public bool isBlue(){
        return true;
    }
    public void TakeDamage()
    {
        Destroy(gameObject);
    }

}
