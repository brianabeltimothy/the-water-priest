using System;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;
    public static event Action OpenDoorEvent;
    public static void StartOpenDoorEvent()
    {
        OpenDoorEvent?.Invoke();
    }

    private void Start()
    {
        result = new int[]{1, 1, 1, 1};
        correctCombination = new int[] {1, 2, 3, 4};
        isOpened = false;
        StoneLockController.Rotated += CheckResults;
    }

    private void CheckResults(string stoneName, int wheelId, int numberShown)
    {   
        switch (stoneName)
        {
            case "Stone Lock Right" when wheelId == 0:
                result[0] = numberShown;
                break;
            case "Stone Lock Right" when wheelId == 1:
                result[1] = numberShown;
                break;
            case "Stone Lock Left" when wheelId == 0:
                result[2] = numberShown;
                break;
            case "Stone Lock Left" when wheelId == 1:
                result[3] = numberShown;
                break;
        }
        foreach(int i in result)
        {
            Debug.Log("Result: " + i);
        }

        if (result[0] == correctCombination[0] && 
            result[1] == correctCombination[1] &&
            result[2] == correctCombination[2] &&
            result[3] == correctCombination[3]) 
        {
            isOpened = true;
            Debug.Log("Is opened: " + isOpened);
            StartOpenDoorEvent();
        }
    }

    private void OnDestroy()
    {
        StoneLockController.Rotated += CheckResults;
    }
}
