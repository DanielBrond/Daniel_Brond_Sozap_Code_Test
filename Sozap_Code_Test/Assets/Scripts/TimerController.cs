using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public string currentTime;
    public string savedTime;
    public Text timeCounter;

    public float savedFloatTime;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;

        StartTimer();
    }

    public void StartTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        
        timerGoing = false;
        savedTime = currentTime;
        savedFloatTime = elapsedTime;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time:" + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            DisplayCurrentTime(timePlaying);
            yield return null;
        }
    }

    public void DisplayCurrentTime(TimeSpan time)
    {
        currentTime = time.ToString("mm':'ss'.'ff");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTimer();
        }
    }
}
