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

        timeE -=  Time.deltaTime;//time is being rest subtract by real time.
        countdown.text = timeE.ToString("0");
        //the moment the time reach 0
        if (timeE <= 0)
        {
            timeE = 0;
            Debug.Log("End game ");

        }
    }
}
