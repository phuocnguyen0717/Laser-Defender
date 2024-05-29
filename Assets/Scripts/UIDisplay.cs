using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health healthPlayer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = healthPlayer.GetHealth();
    }

    void Update()
    {
        if (scoreKeeper != null)
        {
            healthSlider.value = healthPlayer.GetHealth();
            scoreText.text = scoreKeeper.GetScore().ToString("0");
        }
    }
}
