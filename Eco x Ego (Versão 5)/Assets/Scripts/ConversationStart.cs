using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStart : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private bool conversationStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted)
        {
            ConversationManager.Instance.StartConversation(myConversation);
            conversationStarted = true;
        }
    }
}
