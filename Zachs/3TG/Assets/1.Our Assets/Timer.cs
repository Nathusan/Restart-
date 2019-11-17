using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //gives us the time since level starts 
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime; //where the timer starts and stores it in t

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }   
    public void Finish()
    {
        timerText.color = Color.red;
    }
}
