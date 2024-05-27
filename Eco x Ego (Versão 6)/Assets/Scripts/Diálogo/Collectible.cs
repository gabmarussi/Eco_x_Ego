using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject interactionUI;
    private bool isPlayerNear = false;
    public string itemName;

    // Inicia com interface desativada
    void Start()
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    // Condição para coletar objeto
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    // Destuindo objeto ao ser coletado
    void Collect()
    {
        CollectionManager.Instance.CollectItem(itemName);
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
        Destroy(gameObject);
    }

    // Mostrando interface ao chegar perto de objeto
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactionUI != null)
            {
                interactionUI.SetActive(true);
            }
        }
    }

    // Removendo interface ao se distanciar de objeto
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactionUI != null)
            {
                interactionUI.SetActive(false);
            }
        }
    }
}