using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScrollerController : MonoBehaviour
{

    [Header("Progress Bar Settings")]
    public Image progressBar;
    public float fillSpeed = 0.1f;
    public float decayRate = 0.02f;
    public float winThreshhold = 1f;

    [Header("Background Speed Control")]
    public BGRotator bgRotator;
    public BGRotator bgRotator2;
    public float minBGSpeed = 8f;
    public float maxBGSpeed = 15f;
    public float speedIncreaseRate = 0.5f;

    private Vector3 lastMousePos;
    private float progress = 0f;
    private bool hasWon = false;

    
    void Start()
    {
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon) return; //Stop updating the bar when victory 

        //Detects mouse input
        Vector3 currentMousePos = Input.mousePosition;
        float movement = Mathf.Abs(currentMousePos.x - lastMousePos.x);

        //Increases progress bar based on mouse move
        progress += movement * fillSpeed * Time.deltaTime;

        //Slowly decays progress
        progress -= decayRate * Time.deltaTime;
        progress = Mathf.Clamp(progress, 0f, winThreshhold);

        //Updates the UI
        progressBar.fillAmount = progress;

        //Adjusts the speed of the background based on the value of the progress bar
        if (bgRotator != null && bgRotator2 != null)
        {
            float newSpeed = Mathf.Lerp(minBGSpeed, maxBGSpeed, Mathf.Pow(progress, speedIncreaseRate));
            bgRotator.speed = newSpeed;
            bgRotator2.speed = newSpeed;
        }

        //Checks win state
        if (progress >= winThreshhold)
        {
            WinGame();
        }

        lastMousePos = currentMousePos;
    }


    void WinGame()
    {
        Debug.Log("woo you spin my head right round right round baby go down");
        hasWon = true;
        progress = 1f;
        progressBar.fillAmount = 1f; //Lock the progress bar when victory happens 

        //Stops the guys from spinning monkey
        if (bgRotator != null && bgRotator2 != null)
        {
            bgRotator.speed = 0f;
            bgRotator2.speed = 0f;
        }
    }
}
