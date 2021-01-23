using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 4;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        PlayerPrefsController.SetLevel();
        SceneManager.LoadScene("Start Screen 1");
    }

    public void LoadMainMenuNotSaveLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen 1");
    }

    public void LoadOptionScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Option Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void loadCoutinueGame()
    {
        Time.timeScale = 1;
        int saveLevel = PlayerPrefsController.GetLevel();
        if (saveLevel != 0)
        {
            SceneManager.LoadScene(currentSceneIndex + saveLevel - 1);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}   