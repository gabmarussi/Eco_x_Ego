using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private Renderer npcRenderer;

    // Neftis tem luzes e imagem
     public GameObject NeftisFinal;

    // Inicia com NPC ativo e renderização invisivel
    void Start()
    {
        npcRenderer = GetComponent<Renderer>();
        npcRenderer.enabled = false;
        NeftisFinal.gameObject.SetActive(false);
    }

    // Renderização ativa
    public void ShowNPC()
    {
        npcRenderer.enabled = true;
    }

    // Renderização nula
    public void HideNPC()
    {
        npcRenderer.enabled = false;
    }

    // Verifica se o Player entrou do trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcRenderer.enabled = true;
        }
    }

    // Verifica se o Player saiu do trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            npcRenderer.enabled = false;
        }
    }

    public void ActivateNeftis()
    {
        gameObject.SetActive(true);
    }
    // Habilitar e dasabilitar Neftis
    public void DesactivateNeftis()
    {
        gameObject.SetActive(false);
    }

    // Função para destruir objeto
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}