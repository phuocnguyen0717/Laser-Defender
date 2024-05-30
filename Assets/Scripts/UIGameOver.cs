using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        GetYourScore();
    }
    void GetYourScore()
    {
        if (scoreKeeper != null)
        {
            scoreText.text = "Your Score\n" + scoreKeeper.GetScore();
        }
    }
}
