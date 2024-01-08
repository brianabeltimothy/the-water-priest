using UnityEngine;

public class RenardTriggerArea : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueTrigger trigger2;
    public UIManager uiManager;

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetReinard1)
            {
                if(!DialogueManager.isActive)
                { 
                    trigger.StartDialogue();
                }
                GameEvents.current.StartMeetReinard1();
            }   

            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetReinard2)
            {
                if(!DialogueManager.isActive)
                {
                    trigger2.StartDialogue();
                }
                GameEvents.current.StartMeetReinard2();
            }
        }
    }
}
