using UnityEngine;

public class MeetZaniyah : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.MeetZaniyahEvent += GiveObjective;
    }

    private void GiveObjective()
    {
        Debug.Log("Follow me");
    }

    private void OnDestroy() {
        GameEvents.current.BoulderEvent -= GiveObjective;
    }
}
