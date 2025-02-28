using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Click : MonoBehaviour
{
   public int Score = 0;
    public int ScoreMax = 20;
   private int ScoreIncrease = 1;
   

    [SerializeField] private TextMeshProUGUI Mark;
    [SerializeField] private Button button;
    [SerializeField] private Sprite NewSprite;
    //Music
    public AudioSource BackgroundMusic;
    public AudioSource audiosource;
    public AudioClip WinSound;
    public AudioClip Lose;
    public AudioClip ChampOpen;



    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        BackgroundMusic.loop = true;
        BackgroundMusic.Play();
    }


    public void IncreaseScore () {
        if (Score < ScoreMax)
        {
            Score += ScoreIncrease;
            Mark.text = Score.ToString();
            Debug.Log("Number " + Score);
            if (Score == ScoreMax)
            {

                Debug.Log("End game");
                ChangeSprite();
                GameEnd();
                BackgroundMusic.Stop();
            }
        }
        //add audio
    }
    public void ChangeSprite()
    {
        if (button )
        {
            button.image.sprite = NewSprite;
        }
        //add audio
    }

    public void GameEnd() { 
     
            bool GameWin = true;
       //SceneManager

    
    }



}
