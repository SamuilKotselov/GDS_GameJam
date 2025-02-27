using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int levelGenerate;
    
    public void LoadLevelsRandom()
    {
        levelGenerate = Random.Range(1,3);
        SceneManager.LoadScene(levelGenerate);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
