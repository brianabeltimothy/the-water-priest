using UnityEngine;
using TMPro;

[System.Serializable]
public class UIManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text objectiveText;

    private void Start()
    {
        GameEvents.current.ChangeObjectiveEvent += ChangeObjectiveText;
    }

    private void Update()
    {
        if(!DialogueManager.isActive)
        { 
            objectiveText.enabled = false;
        }
        objectiveText.enabled = true;
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
            case GameEvents.ObjectiveState.MeetZaniyah:
                objectiveText.text = "Find Zaniyah";
                break;
            case GameEvents.ObjectiveState.ExploreCatacombs:
                objectiveText.text = "Find a way out from catacombs and reach the shore";
                break;
            case GameEvents.ObjectiveState.GetToTheBoat:
                objectiveText.text = "Get to the boat";
                break;
        }
    }

    void OnDestroy()
    {
        GameEvents.current.ChangeObjectiveEvent -= ChangeObjectiveText;
    }
}
