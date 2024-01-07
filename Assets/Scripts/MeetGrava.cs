using UnityEngine;

public class MeetGrava : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.MeetGravaEvent += GiveObjective;
    }

    private void GiveObjective()
    {
        Debug.Log("Here is the map");
    }

    private void OnDestroy() {
        GameEvents.current.BoulderEvent -= GiveObjective;
    }
}
