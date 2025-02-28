using System.Collections;
using UnityEngine;


public class Mask : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource PlayMusic;
    public AudioClip PlaySound;  
    public AudioClip LoseSound;  

    private ChoosenMask choosenMask;
    private bool gameEnded = false;

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
    }

    void Update()
    {
        if (!gameEnded) 
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
        gameEnded = true;
        Debug.Log("You won!");

        Destroy(choosenMask.MascaraW());

        if (BackgroundMusic != null) BackgroundMusic.Stop();

        if (PlayMusic != null && PlaySound != null)
        {
            PlayMusic.PlayOneShot(PlaySound);
        }

    }

    private void LoseGame()
    {
        gameEnded = true;
        Debug.Log(" You lost");

        if (BackgroundMusic != null) BackgroundMusic.Stop();

        if (PlayMusic != null && LoseSound != null)
        {
            PlayMusic.PlayOneShot(LoseSound);
        }
        
    }

    
}