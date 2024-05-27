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
        StartCoroutine(LoadScene(sceneName)); // Carrega a Cena + Transição
    }

    //IEnumerator é uma Coroutine
    IEnumerator  LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("Start"); // Aciona a animação de transição
        
        yield return new WaitForSeconds(transitionDelay); // Atrasa a transição

        SceneManager.LoadScene(sceneName); // Carrega a cena selecionada dentro de jogo
    }

    public void OnDialogueEnd()
    {
        // Trocar cena dentro de Dialogue Editor ao finalizar dialogo
        StartCoroutine(LoadScene("Forest"));
    }
}
