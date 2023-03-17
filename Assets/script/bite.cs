
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ItemCollector : MonoBehaviour
{
    private int diams = 1;

   
    private Text diamsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "lasttag")
            {
            Debug.Log("You have collected all the diamonds!" + diams);
            Destroy(collision.gameObject);
            diams++;
            
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
}



