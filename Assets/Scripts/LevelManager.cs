using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        if (scoreKeeper != null)
        {

            scoreKeeper.ResetScore();
        }
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", timeDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string nameScene, float delay)
    {
        SceneManager.LoadScene(nameScene);
        yield return new WaitForSeconds(delay);
    }

}
