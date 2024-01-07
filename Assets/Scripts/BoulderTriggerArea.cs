using UnityEngine;

public class BoulderTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameEvents.current.StartBoulderEvent();
        }
    }
}
