using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float JumpForce;
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    private int health = 3;
    public static bool gameispaused;
    public GameObject gameoverui, blink;
    public GameObject villager1, villager2, villager3;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) & isGrounded == true ) 
        { 
            animator.SetTrigger("jump");
            body.AddForce(Vector2.up * JumpForce);
            isGrounded  = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");

            Invoke("Shoot", 0.5f);
        }
        //this.transform.Translate(new Vector3 (3f, 0f, 0f) * Time.deltaTime,Space.Self);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        gameispaused = false;
    }

    void Shoot()
    {
      Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
        
        if(collision.gameObject.CompareTag("Enemy") | collision.gameObject.CompareTag("Obstacle")){
            Invoke("EnableBlink", 0.1f);
            Invoke("DisableBlink", 0.3f);
            GameObject.Find("player").transform.position = new Vector3(-7.8f,4f,0f);
                        
            switch (health){
                case 3:
                    villager3.gameObject.SetActive(false);
                    health = 2; 
                    break;
                case 2:
                    villager2.gameObject.SetActive(false);
                    health = 1;
                    break;
                case 1:
                    villager1.gameObject.SetActive(false);  
                    health = 0;
                    break;
                case 0:
                    //this.enabled = false;
                    gameoverui.SetActive(true);
                    Time.timeScale =0f;
                    gameispaused= true;
                    break;

                default:
                break;
            }            
        }
        
    }

    private void EnableBlink(){
        blink.SetActive(true);
    }
    private void DisableBlink(){
        blink.SetActive(false);
    }
}