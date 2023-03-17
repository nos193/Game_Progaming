using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class TIMER : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI timerText;
    
    public GameObject UInBcoins; 

    [Header("Timer Settings")]
    public float currentTime;
    public bool countdown;

    //add time to timer when player collides with coin

    

    [Header("Limits Settings")]
    public bool hasLimits;
    public float timerLimit;
   
  
    private void Start()
    {
        settimertext();
    }

    private void Update()
    {
        currentTime = countdown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;

        if (hasLimits && ((countdown && currentTime <= timerLimit) || (!countdown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            settimertext();
            timerText.color = Color.red;
            enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        settimertext();
    }

  

    private void settimertext()
    {
        timerText.text = currentTime.ToString("0");

    }
}
