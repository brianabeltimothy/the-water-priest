using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenardTriggerArea : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueTrigger trigger2;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetReinard1)
            {
                GameEvents.current.StartMeetReinard1();
                trigger.StartDialogue();
            }   

            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetReinard2)
            {
                GameEvents.current.StartMeetReinard2();
                trigger2.StartDialogue();
            }
        }
    }
}
