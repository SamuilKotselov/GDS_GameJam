using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFX;

    public AudioClip Backgroundmusic;
    public AudioClip ClickSound;
    public AudioClip WinSound;
    public AudioClip LoseSound;

    private void Start()
    {
        musicSource.clip = Backgroundmusic;
        musicSource.Play();
    }

    public void SfxPlay(AudioClip clip)
    {

        SFX.PlayOneShot(clip);
    }

}
