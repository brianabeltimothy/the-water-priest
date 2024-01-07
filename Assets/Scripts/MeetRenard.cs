using UnityEngine;

public class MeetRenard : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.MeetReinard1Event += GiveObjective1;
        GameEvents.current.MeetReinard2Event += GiveObjective2;
    }

    private void GiveObjective1()
    {
        Debug.Log("Go meet Grava");
    }

    private void GiveObjective2()
    {
        Debug.Log("Go meet Zaniyah");
    }

    private void OnDestroy() {
        GameEvents.current.BoulderEvent -= GiveObjective1;
        GameEvents.current.BoulderEvent -= GiveObjective2;
    }
}
