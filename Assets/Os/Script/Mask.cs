using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mask : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource PlayMusic;
    public AudioClip PlaySound;  
    public AudioClip LoseSound;  

    private ChoosenMask choosenMask;
    private bool gameWon;
    private bool gameLost;

    private Timer timer;

    private void Start()
    {
        choosenMask = GetComponent<ChoosenMask>();

        if (BackgroundMusic != null)
        {
            BackgroundMusic.loop = true;
            BackgroundMusic.Play();
        }

        if (PlayMusic == null)
        {
            PlayMusic = gameObject.AddComponent<AudioSource>();
        }

        timer = Timer.instance;
        if (timer != null)
        {
            timer.OnTimerEnd += LoseGame;
        }
    }

    void Update()
    {
        if (!gameWon || !gameLost) 
        {
            CheckClick();
        }
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null) 
            {
                if (choosenMask != null && hit.collider.gameObject == choosenMask.MascaraW())
                {
                    WinGame();
                }
                else
                {
                    LoseGame();
                }
            }
            else
            {
                LoseGame(); 
            }
        }
    }

    private void WinGame()
    {
        gameWon = true;
        Debug.Log("You won!");

        Destroy(choosenMask.MascaraW());

        if (BackgroundMusic != null) BackgroundMusic.Stop();

        if (PlayMusic != null && PlaySound != null)
        {
            PlayMusic.PlayOneShot(PlaySound);
        }

        StartCoroutine(DelayedSceneTransition());
    }

    private void LoseGame()
    {
        gameLost = true;
        Debug.Log(" You lost");

        if (BackgroundMusic != null) BackgroundMusic.Stop();

        if (PlayMusic != null && LoseSound != null)
        {
            PlayMusic.PlayOneShot(LoseSound);
        }

        HealthManager.instance.LoseHealth();

        StartCoroutine(DelayedSceneTransition());
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
        while (randomSceneIndex == currentSceneIndex || randomSceneIndex == 0 || randomSceneIndex == 4);

        SceneManager.LoadScene(randomSceneIndex);
    }

    IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(1f);

        LoadRandomScene();
    }

    private void OnDestroy()
    {
        if (timer != null)
        {
            timer.OnTimerEnd -= LoseGame;
        }
    }
}