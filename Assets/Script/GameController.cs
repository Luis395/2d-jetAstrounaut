using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public static GameController instance;
    public Text scoreText;
    void Start()
    {
        instance = this;
    }
    public void UpdateScoreText() 
    {
        scoreText.text = totalScore.ToString();
    }
}