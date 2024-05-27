using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitionAnim;
    public float transitionDelay = 2f;

    public void Transition(string sceneName) 
    {
        StartCoroutine(LoadScene(sceneName)); // Carrega a Cena + Transi��o
    }

    //IEnumerator � uma Coroutine
    IEnumerator  LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("Start"); // Aciona a anima��o de transi��o
        
        yield return new WaitForSeconds(transitionDelay); // Atrasa a transi��o

        SceneManager.LoadScene(sceneName); // Carrega a cena selecionada dentro de jogo
    }

    public void OnDialogueEnd()
    {
        // Trocar cena dentro de Dialogue Editor ao finalizar dialogo
        StartCoroutine(LoadScene("Forest"));
    }
}
