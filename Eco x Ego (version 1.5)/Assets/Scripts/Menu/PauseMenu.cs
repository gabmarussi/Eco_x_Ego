using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] GameObject audioMenu;

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Options()
    {
        MenuPause.SetActive(false);
        audioMenu.SetActive(true);
    }

    public void Resume()
    {
        MenuPause.SetActive(false);
    }

    public void Back()
    {
        audioMenu.SetActive(false);
        MenuPause.SetActive(true);
    }
}
  