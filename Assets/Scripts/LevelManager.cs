using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    public void LoadGame()
    {
        Debug.Log("Game");
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        Debug.Log("Mainmenu");
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
