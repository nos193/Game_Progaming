using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthbar : MonoBehaviour
{
    public float health;
    public LayerMask dielayer;
    public float maxHealth;
    public Image healthBar;
    public float damage;
    private Rigidbody2D rb;
    public Animator An;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        rb = GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
    void Update()


    {
        An.SetInteger("attack", 0);
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (isdead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );          //si le joueur est mort il est redirigé vers la scène de mort
            print("dead");
        }
        else if (health <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );          //si le joueur est mort il est redirigé vers la scène de mort
            print("dead");
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "cherry" && health < 100)
        {
            health += 15;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "cherry" && health >= 100)
        {
            health = 100;
            Destroy(collision.gameObject);
        }
    }
      private bool isdead(){
            return rb.IsTouchingLayers(dielayer);
        }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && An.GetInteger("attack") == 0)
        {
            health -= 10;
        }
    }
        
}
