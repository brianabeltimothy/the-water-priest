using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public enum ObjectiveState
    {
        None,
        MeetReinard1,
        MeetGrava,
        MeetReinard2,
        MeetZaniyah,
        ReachedBoat
    }

    public static ObjectiveState currentObjective = ObjectiveState.None;

    private void Awake() {
        current = this;
        SetNextObjectives();
    }

    private void Update() {
        StartChangeObjectivesEvent();
    }

    private void SetNextObjectives()
    {
        switch (currentObjective)
        {
            case ObjectiveState.None:
                currentObjective = ObjectiveState.MeetReinard1;
                break;
            case ObjectiveState.MeetReinard1:
                currentObjective = ObjectiveState.MeetGrava;
                break;
            case ObjectiveState.MeetGrava:
                currentObjective = ObjectiveState.MeetReinard2;
                break;
            case ObjectiveState.MeetReinard2:
                currentObjective = ObjectiveState.MeetZaniyah;
                break;
            case ObjectiveState.MeetZaniyah:
                currentObjective = ObjectiveState.ReachedBoat;
                break;
            case ObjectiveState.ReachedBoat:
                Debug.Log("All objectives completed!");
                break;  
        }
        Debug.Log("Current Objective: " + currentObjective);
    }

    public event Action ChangeObjectiveEvent;
    public void StartChangeObjectivesEvent()
    {
        if(ChangeObjectiveEvent != null)
        {
            ChangeObjectiveEvent();
        }
    }

    public event Action MeetReinard1Event;
    public void StartMeetReinard1()
    {
        if (MeetReinard1Event != null)
        {
            if(currentObjective == ObjectiveState.MeetReinard1)
            {
                MeetReinard1Event();
                SetNextObjectives();
            }
        }
    }

    public event Action MeetGravaEvent;
    public void StartMeetGrava()
    {
        if (MeetGravaEvent != null)
        {
            if(currentObjective == ObjectiveState.MeetGrava)
            {
                MeetGravaEvent();
                SetNextObjectives();
            }
        }
    }

    public event Action MeetReinard2Event;
    public void StartMeetReinard2()
    {
        if (MeetReinard2Event != null)
        {
            if(currentObjective == ObjectiveState.MeetReinard2)
            {
                MeetReinard2Event();
                SetNextObjectives();
            }
        }
    }

    public event Action MeetZaniyahEvent;
    public void StartMeetZaniyah()
    {
        if (MeetZaniyahEvent != null)
        {
            MeetZaniyahEvent();
            SetNextObjectives();
        }
    }

    public event Action ReachedBoatEvent;
    public void StartReachedBoat()
    {
        if (ReachedBoatEvent != null)
        {
            ReachedBoatEvent();
            SetNextObjectives();
        }
    }

    // catacombs
    public event Action BoulderEvent;
    public void StartBoulderEvent()
    {
        if (BoulderEvent != null)
        {
            BoulderEvent();
        }
    }
}
