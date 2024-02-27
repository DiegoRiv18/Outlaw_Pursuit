using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    //private int SavedCoins;

    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Tutorial,
        Hub,
        Level1
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
        //SavedCoins = Shop.Singleton.balance;
        
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Tutorial.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Shop.Singleton.balance = Shop.Singleton.runningBalance;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
