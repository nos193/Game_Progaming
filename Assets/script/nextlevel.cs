using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextlevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "nextlevel" )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
        }

}
