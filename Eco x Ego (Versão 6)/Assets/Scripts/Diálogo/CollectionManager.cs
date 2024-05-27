using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager Instance;

    private HashSet<string> collectedItems = new HashSet<string>();

    public string[] requiredItems = { "AirTotem", "WaterTotem", "EarthTotem" };

    public GameObject npcAir;
    public GameObject npcWater;
    public GameObject npcEarth;
    public GameObject npcNeftis;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Chamando fuções para fazer as validações (Destruição de totem em Collectible)
    public void CollectItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            DestroyCorrespondingNPC(itemName);
            CheckAllItemsCollected();
        }
    }


    // Verificando os totens e destruindo cada NPC respectivo
    private void DestroyCorrespondingNPC(string itemName)
    {
        switch (itemName)
        {
            case "AirTotem":
                if (npcAir != null)
                {
                    Destroy(npcAir);
                }
                break;
            case "WaterTotem":
                if (npcWater != null)
                {
                    Destroy(npcWater);
                }
                break;
            case "EarthTotem":
                if (npcEarth != null)
                {
                    Destroy(npcEarth);
                }
                break;
        }
    }

    private void CheckAllItemsCollected()
    {
        foreach (string item in requiredItems)
        {
            if (!collectedItems.Contains(item))
            {
                return;
            }
        }

        // Invocando Neftis após coletar os totens
        if (npcNeftis != null)
        {
            Visibility visibility = npcNeftis.GetComponent<Visibility>();
            if (visibility != null)
            {
                // visibility.ShowNPC();
                visibility.ActivateNeftis();
            }
        }
    }
}