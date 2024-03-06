using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    private int SavedCoins;
    private bulletcounter counter;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (FindAnyObjectByType<bulletcounter>() != null)
        {
            counter = FindAnyObjectByType<bulletcounter>();
        }
    }
    public enum Scene
    {
        MainMenu,
        Tutorial,
        Hub,
        Level1,
        Level2,
        Level3,
    }

    public void LoadScene(Scene scene)
    {
        Debug.Log(scene.ToString());
        SceneManager.LoadScene(scene.ToString());
        SavedCoins = Shop.Singleton.balance;
        counter.ChangeAmmo(6);
        if (scene.ToString() == "Level2")
        {
            AudioManager.Instance.PlayMusic("Cave Theme");
        }
        if (scene.ToString() == "Level3")
        {
            AudioManager.Instance.PlayMusic("Train Theme");
        }
        if (scene.ToString() == "Hub")
        {
            AudioManager.Instance.PlayMusic("Hub Theme");
        }

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
        Shop.Singleton.balance = SavedCoins;
        counter.ChangeAmmo(6 + Shop.Singleton.getAmmo());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
