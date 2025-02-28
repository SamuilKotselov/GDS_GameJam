using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int maxHealth = 3;
    private int currentHealth;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            currentHealth = maxHealth;
            UpdateHealthUI();
        }
    }

    public void LoseHealth()
    {
        currentHealth--;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Game Over");

            SceneManager.LoadScene(0);
        }
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    public int CurrentHealth => currentHealth;

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
