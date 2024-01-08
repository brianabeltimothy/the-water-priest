using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !DialogueManager.isActive)
        {
            trigger.StartDialogue();
        }
    }
}
