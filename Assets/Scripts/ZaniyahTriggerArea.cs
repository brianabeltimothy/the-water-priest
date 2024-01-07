using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaniyahTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(GameEvents.currentObjective == GameEvents.ObjectiveState.MeetZaniyah)
            {
                GameEvents.current.StartMeetZaniyah();
            }
        }
    }
}
