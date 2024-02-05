using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalekRedGenerator : MonoBehaviour
{
    private static System.Random rnd = new System.Random();

    public GameObject red;
    public GameObject blue;
    public GameObject spines;
    public GameObject woodSpine;

    public float minSpeed;
    public float currSpeed;
    public float maxSpeed;

    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        currSpeed= minSpeed;
        generateRed();
    }

    public void randomizeRedSpawn(){
        float r = Random.Range(1f, 10f);
        int s  = rnd.Next(0, 4);

        switch (s){
            case 0:
                Invoke("generateRed", r);
                break;
            case 1:
                Invoke("generateBlue", r);
                break;
            case 2:
                Invoke("generateSpine",r);
                break;
            case 3:
                Invoke("generateWood",r);
                break;
            default:
                break;
        }
    }

    void generateRed(){
        GameObject redIns = Instantiate(red, transform.position, transform.rotation);
        redIns.GetComponent<DalekRed>().redGenerator = this;
    }
    void generateBlue(){
        GameObject blueIns = Instantiate(blue, transform.position, transform.rotation);
        blueIns.GetComponent<DalekBlue>().redGenerator = this;
    }
    void generateSpine(){
        GameObject spineIns = Instantiate(spines, transform.position, transform.rotation);
        spineIns.GetComponent<Spines>().redGenerator = this;
    }
    void generateWood(){
        GameObject woodIns = Instantiate(woodSpine, transform.position, transform.rotation);
        woodIns.GetComponent<WoodSpine>().redGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currSpeed < maxSpeed){
            currSpeed += speedIncrease;
        }
    }
}
