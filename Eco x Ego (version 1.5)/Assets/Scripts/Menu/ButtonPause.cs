
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    [SerializeField] public GameObject MenuPause;

    public void Options()
    {
        MenuPause.SetActive(true);
    }

}