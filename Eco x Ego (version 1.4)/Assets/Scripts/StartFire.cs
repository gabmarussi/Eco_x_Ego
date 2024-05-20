using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    public GameObject Fire;
    public float transitionDuration = 1.0f; // Duração da transição em segundos

    private ParticleSystem fireParticleSystem;

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

    void OnTriggerEnter(Collider other)
    {
        if (Fire != null)
        {
            Fire.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Fire != null)
        {
            StartCoroutine(FadeOut());
        }
    }

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