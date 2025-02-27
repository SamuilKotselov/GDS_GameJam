using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
     float timeE = 0f; //Final Time
     float timeS = 8f; //Start Time
    [SerializeField] TextMeshProUGUI countdown;

    public delegate void TimerEndAction();
    public event TimerEndAction OnTimerEnd;

    private void Start()
    {
        timeE = timeS;
    }
    private void Update()
    {
        Countdown();
    }
    private void Countdown()
    {
        if (timeE > 0)
        {
            timeE -= Time.deltaTime; 
            countdown.text = Mathf.Ceil(timeE).ToString();
        }
        else
        {
            timeE = 0f;
            countdown.text = "0";
            if (OnTimerEnd != null) OnTimerEnd();
            Debug.Log("End Game");
        }
    }

    public void ResetTimer()
    {
        timeE = timeS;
        countdown.text = Mathf.Ceil(timeE).ToString();
    }
}
