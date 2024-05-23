using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string levelGameName;
    [SerializeField] private GameObject startMenu;
    [SerializeField] GameObject optionsMenu;

    //  public string sceneName;
    public LevelLoader LevelLoader;

    public void Play()
    {
        LevelLoader.Transition("ForestDestroyed");
    }

    public void Options()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene("End");
    }
}
