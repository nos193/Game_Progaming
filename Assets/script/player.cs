using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;






public class player : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Animator An;
    public float movementSpeed = 4f;
    public float jumpForce = 7f;
    public int maxjump = 2;
    public int currentjump = 0;
    public float maxSpeed = 8f;
    public int diams = 5;

   
    public Text diamsText;
    
    public LayerMask dielayer;    
    
    
    
    
    
    

   

// mise en place du start
    void Start()
    {
       
        diamsText = GameObject.Find("textdiams2").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);       
        

        
    }



// mise en place de la fonction isdead
    public void Die(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "lasttag")
            {
            diamsText.text = "You have: " + diams; 
            
            Destroy(collision.gameObject);
            diams++;
                // vérification pour s'assurer que diamsText n'est pas nulle

           
            
            
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSources[2].Play();
            }
         
    
            // gestion du changement de scene
            else if (collision.gameObject.tag == "nextlevel")
            {   
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
            else if (collision.gameObject.tag == "die")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && An.GetInteger("attack") == 1 )
        {
            Destroy(collision.gameObject);
            
       
    }
    }
    
     // mise en place de la fonction des déplacements et des sauts du joueur
    void Update()
    {
        
        if (isdead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );          //si le joueur est mort il est redirigé vers la scène de mort
            print("dead");
        }
                                        //le script de la barre de vie est appelé
        An.SetInteger("attack", 0);
        An.SetFloat("jump", Mathf.Abs(rb.velocity.y));                      //les animations du joueur et setup des déplacements
        An.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKey(KeyCode.LeftArrow) && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(-movementSpeed, 0f), ForceMode2D.Force);
            rb.transform.localScale = new Vector2(-4, 4);
            maxSpeed = 6f;
        
        }

        if (Input.GetKey(KeyCode.RightArrow) && rb.velocity.x < maxSpeed)       //les déplacements du joueur
        {
            rb.AddForce(new Vector2(movementSpeed, 0f), ForceMode2D.Force);
            rb.transform.localScale = new Vector2(4, 4);
            maxSpeed = 6f;
            
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentjump < maxjump )
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
             GetComponent<AudioSource>().Play();
            currentjump++;
        }                                                                       //les sauts du joueur
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0f, -0.1f ), ForceMode2D.Impulse);
           
        }
    
        if (An.GetFloat("jump") == 0 && currentjump == 2)
        {
            currentjump = 0;
        }
        if (Input.GetKey(KeyCode.Space)&& An.GetInteger("attack") == 0)
        {
            An.SetInteger("attack", 1);
            AudioSource[] audioSources = GetComponents<AudioSource>();          //les attaques du joueur
            audioSources[1].Play();
            
        }
        if (An.GetFloat("jump") != 0)
        {
            maxSpeed = 4f;
        }
        
        
            
        // gestion des collisions avec les pièces et les ennemis et le changement de scene 
   
       

           
        
    }
    //variable de "mort" du joueur
    private bool isdead(){
            return rb.IsTouchingLayers(dielayer);
        }
    

   
        
        

}




   