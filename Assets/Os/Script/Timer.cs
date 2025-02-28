using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] float timeE = 0f; //Final Time
    float timeS = 8f; //Start Time
    [SerializeField] TextMeshProUGUI countdown;

    public event Action OnTimerEnd;

    private bool isTimerRunning = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timeE = timeS;
    }
    private void Update()
    {
        if (isTimerRunning)
        {
            Countdown();
        }
    }
    private void Countdown()
    {
        timeE -= Time.deltaTime;
        countdown.text = timeE.ToString("0");

        if (timeE <= 0)
        {
            timeE = 0;
            Debug.Log("End Game");

            OnTimerEnd?.Invoke();
        }
    }

    public void ResetTimer()
    {
        timeE = timeS; 
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}

