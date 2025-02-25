using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class Click : MonoBehaviour
{
   public int Score = 0;
   private int ScoreIncrease = 1;
    
   [SerializeField] private TextMeshProUGUI Mark;
    [SerializeField] private Button button;
    [SerializeField] private Sprite NewSprite;
    public void IncreaseScore () { 
        Score += ScoreIncrease;
        Mark.text = Score.ToString();
        Debug.Log("Puntaje aumentado: " + Score);
        if (Score >= 12)
        {
            Debug.Log("End game");
            ChangeSprite();
        }
    }
    public void ChangeSprite()
    {
        if (button )
        {
            button.image.sprite = NewSprite;
        }
    }
}
