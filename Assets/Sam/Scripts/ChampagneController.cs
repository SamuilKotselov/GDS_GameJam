using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampagneController : MonoBehaviour
{
   
    public Transform zoneStart;
    public Transform zoneWin;
    public Transform zoneLose;

    [SerializeField] private float chWinSpeed; //stands for Champagne Speed heh
    [SerializeField] private float chLoseSpeed;
    [SerializeField] private float loseRotationSpeed;

    public AudioClip winSound;
    public AudioClip loseSound;

    private AudioSource audioSource;
    private RectTransform champagneTransform;
    private bool soundPlayed = false; //Prevents the sound from being played twice

    void Start()
    {
        champagneTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }


    public void ToastWin()
    {
        StartCoroutine(MoveChampagne(zoneWin.position, chWinSpeed, false, winSound));
    }

    public void ToastLose()
    {
        StartCoroutine(MoveChampagne(zoneLose.position, chLoseSpeed, true, loseSound));
    }

    private IEnumerator MoveChampagne(Vector3 target, float speed, bool shouldRotate, AudioClip clip)
    {
        soundPlayed = false;

        while(Vector3.Distance(champagneTransform.position, target) > 0.1f)
        {
            champagneTransform.position = Vector3.MoveTowards(champagneTransform.position, target, speed * Time.deltaTime);
            
            if (shouldRotate)
            {
                champagneTransform.Rotate(0, 0, -loseRotationSpeed * Time.deltaTime);
            }

            if (!soundPlayed && Vector3.Distance(champagneTransform.position, target) < 1.7f)
            {
                PlaySound(clip);
                soundPlayed = true;
            }

            yield return null;
        }  
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

}
