using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaniyahTriggerArea : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetZaniyah)
            {
                if(!DialogueManager.isActive)
                { 
                    trigger.StartDialogue();
                }
                GameEvents.current.StartMeetZaniyah();
            }
        }
    }
}
