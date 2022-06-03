using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    Night2 n2;
    float t;

    public float timeToTransitionToNextColorTimer;
    public Color yellow;
    public Color red;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMPro.TextMeshProUGUI>(); // cache the text component
        n2 = FindObjectOfType<Night2>();
    }

    // Update is called once per frame
    void Update()
    {        
        
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            t = Time.timeSinceLevelLoad - 31;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            t = Time.timeSinceLevelLoad - 10; // time since scene loaded
        }        
        

        float milliseconds = (Mathf.Floor(t * 100) % 100); // calculate the milliseconds for the timer

        int seconds = (int)(t % 60); // return the remainder of the seconds divide by 60 as an int
        t /= 60; // divide current time y 60 to get minutes
        int minutes = (int)(t % 60); //return the remainder of the minutes divide by 60 as an int
        t /= 60; // divide by 60 to get hours
        int hours = (int)(t % 24); // return the remainder of the hours divided by 60 as an int

        //timerText.text = string.Format("{0}:{1}:{2}.{3}", hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));
        timerText.text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));

        if (timerText.gameObject.activeInHierarchy && Time.timeSinceLevelLoad >= 120 && Time.timeSinceLevelLoad <= 125)
        {            
            timerText.color = Color.Lerp(timerText.color, yellow, timeToTransitionToNextColorTimer);            
        }      
        if (timerText.gameObject.activeInHierarchy && Time.timeSinceLevelLoad >= 220 && Time.timeSinceLevelLoad <= 225)
        {
            timerText.color = Color.Lerp(yellow, red, timeToTransitionToNextColorTimer);
        }
    }
}
