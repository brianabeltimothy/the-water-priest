using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(actors, dialogues);
    }
}

[System.Serializable]
public class Dialogue{
    public int actorId;
    public string line;
}

[System.Serializable]
public class Actor{
    public string name;
    public Sprite sprite;
}