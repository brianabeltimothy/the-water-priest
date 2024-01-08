using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravaTriggerArea : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetGrava)
            {
                if(!DialogueManager.isActive)
                { 
                    trigger.StartDialogue();
                }
                GameEvents.current.StartMeetGrava();
            }
        }
    }
}
