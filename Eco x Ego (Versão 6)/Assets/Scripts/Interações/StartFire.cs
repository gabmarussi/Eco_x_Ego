using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    public GameObject Fire;
    public float transitionDuration = 1.0f;

    private ParticleSystem fireParticleSystem;

    // Verifica e inicia o fogo como desativado
    void Start()
    {
        if (Fire != null)
        {
            fireParticleSystem = Fire.GetComponent<ParticleSystem>();
            if (fireParticleSystem != null)
            {
                var main = fireParticleSystem.main;
                main.startColor = new Color(main.startColor.color.r, main.startColor.color.g, main.startColor.color.b, 0f);
            }
            Fire.SetActive(false);
        }
    }
    
    // Ao entrar em trigger o fogo ativa
    void OnTriggerEnter(Collider other)
    {
        if (Fire != null)
        {
            Fire.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    // Ao sair de trigger o fogo desativa
    void OnTriggerExit(Collider other)
    {
        if (Fire != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    //  Leve transição ao entrar em trigger
    IEnumerator FadeIn()
    {
        if (fireParticleSystem != null)
        {
            var main = fireParticleSystem.main;
            float elapsedTime = 0f;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(1f + (elapsedTime / transitionDuration));
                main.startColor = new Color(main.startColor.color.r, main.startColor.color.g, main.startColor.color.b, alpha);
                yield return null;
            }

            main.startColor = new Color(main.startColor.color.r, main.startColor.color.g, main.startColor.color.b, 1f);
        }
    }

    // Leve transição ao sair de trigger
    IEnumerator FadeOut()
    {
        if (fireParticleSystem != null)
        {
            var main = fireParticleSystem.main;
            float elapsedTime = 0f;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(1f - (elapsedTime / transitionDuration));
                main.startColor = new Color(main.startColor.color.r, main.startColor.color.g, main.startColor.color.b, alpha);
                yield return null;
            }

            main.startColor = new Color(main.startColor.color.r, main.startColor.color.g, main.startColor.color.b, 0f);
            Fire.SetActive(false);
        }
    }
}