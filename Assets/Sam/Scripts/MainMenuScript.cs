using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int levelGenerate;
    public AudioSource M_MenuMusic;

    private void Start()
    {
        M_MenuMusic.loop = true;
        M_MenuMusic.Play();
    }
    public void LoadLevelsRandom()
    {
        levelGenerate = Random.Range(1,3);
        SceneManager.LoadScene(levelGenerate);

        M_MenuMusic.Stop();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
