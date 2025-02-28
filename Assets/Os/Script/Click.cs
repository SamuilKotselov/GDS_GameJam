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
   bool GameWin = false;

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
        if (BackgroundMusic != null)
        {
            BackgroundMusic.loop = true;
            BackgroundMusic.Play();
        }
        if (audiosource == null)
        {
            audiosource = gameObject.AddComponent<AudioSource>();
        }

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
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.Stop();
                }
            }
        }
       
    }
    public void ChangeSprite()
    {
        if (button )
        {
            button.image.sprite = NewSprite;
        }
        if (audiosource != null )
        {
            if (WinSound != null)
            {
                audiosource.PlayOneShot(WinSound);
            }
            if (ChampOpen != null)
            {
                audiosource.PlayOneShot(ChampOpen);
            }
        }
    }

    public void GameEnd() { 
     
        bool GameWin = true;
       //SceneManager

    
    }



}
