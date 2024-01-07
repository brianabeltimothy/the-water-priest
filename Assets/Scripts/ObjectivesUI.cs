using UnityEngine;
using TMPro;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text objectiveText;

    private void Start()
    {
        GameEvents.current.ChangeObjectiveEvent += ChangeObjectiveText;
    }

    private void ChangeObjectiveText()
    {
        switch (GameEvents.currentObjective)
        {
            case GameEvents.ObjectiveState.MeetReinard1:
                objectiveText.text = "Find Renard";
                break;
            case GameEvents.ObjectiveState.MeetGrava:
                objectiveText.text = "Find Grava";
                break;
            case GameEvents.ObjectiveState.MeetReinard2:
                objectiveText.text = "Meet Renard";
                break;
            // case GameEvents.ObjectiveState.MeetZaniyah:
            //     objectiveText.text = "Follow Zaniyah";
            //     break;
            case GameEvents.ObjectiveState.MeetZaniyah:
                objectiveText.text = "Find Zaniyah";
                break;
            // case GameEvents.ObjectiveState.MeetZaniyah:
            //     objectiveText.text = "Get to the boat";
            //     break;
        }
    }

    void OnDestroy()
    {
        GameEvents.current.ChangeObjectiveEvent -= ChangeObjectiveText;
    }
}
