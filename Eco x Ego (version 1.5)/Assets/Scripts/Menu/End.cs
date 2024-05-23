using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class End : MonoBehaviour
{
    [SerializeField] GameObject returnPage;
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.ExitPlaymode();
#else
       
        Application.Quit();
#endif
    }
}