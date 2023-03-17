using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainmenu : MonoBehaviour
{
   public void PlayGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSources[0].Play();
        }
        
    }
    public void QuitGame()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSources[0].Play();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
