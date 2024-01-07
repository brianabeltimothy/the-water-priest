using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;
    // public static GameEvents current;

    private void Start()
    {
        result = new int[]{0, 0};
        correctCombination = new int[] {1, 6};
        isOpened = false;
        Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Wheel One":
                result[0] = number;
                break;

            case "Wheel Two":
                result[1] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1])
        {
            isOpened = true;
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
