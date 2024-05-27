using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject audioMenu;
    private bool isPaused = false;

    private Movement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public bool IsPaused
    {
        get { return isPaused; }
    }

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
        isPaused = false;
        Time.timeScale = 1f; // Retomar o tempo do jogo
        if (playerMovement != null)
        {
            playerMovement.EnableMovement();
        }
    }

    public void Back()
    {
        audioMenu.SetActive(false);
        MenuPause.SetActive(true);
    }

    private void Pause()
    {
        MenuPause.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f; // Pausar o tempo do jogo
        if (playerMovement != null)
        {
            playerMovement.DisableMovement();
        }
    }
}