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
    private bool gameWin;
    private bool gameLoss;

    [SerializeField] private TextMeshProUGUI Mark;
    [SerializeField] private Button button;
    [SerializeField] private Sprite NewSprite;
    //Music
    public AudioSource BackgroundMusic;
    public AudioSource audiosource;
    public AudioClip WinSound;
    public AudioClip Lose;
    public AudioClip ChampOpen;

    private Timer timer;

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

        timer = Timer.instance;
        if (timer != null)
        {
            timer.OnTimerEnd += GameLose;
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
                GameWin();
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

    private void GameWin() {

        gameWin = true;

        if (BackgroundMusic != null)
        {
            BackgroundMusic.Stop();
        }

        //SceneManager
        StartCoroutine(DelayedSceneTransition());
    }

    private void GameLose()
    {
        gameLoss = true;
        StartCoroutine(DelayedSceneTransition());
        HealthManager.instance.LoseHealth();
    }

    IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(1f);

        LoadRandomScene();
    }

    void LoadRandomScene()
    {
        //Gets the level's scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int randomSceneIndex;

        do
        {
            randomSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        }
        while (randomSceneIndex == currentSceneIndex || randomSceneIndex == 0 || randomSceneIndex == 3);

        SceneManager.LoadScene(randomSceneIndex);
    }

    private void OnDestroy()
    {
        if (timer != null)
        {
            timer.OnTimerEnd -= GameLose;
        }
    }
}

