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

    // private void OnTriggerEnter(Collider other) {
    //     if (other.gameObject.CompareTag("Player")) 
    //     {
    //         //display E to talk to Reinard
    //         Debug .Log("Press E to talk with Renard");
    //         // if(Input.GetKey(KeyCode.E))
    //         // {
    //         //     Debug.Log("E key us pressed");
    //         //     GameEvents.current.StartMeetReinard1();
    //         // }
    //         GameEvents.current.StartMeetReinard1();
    //     }
    // }
}
