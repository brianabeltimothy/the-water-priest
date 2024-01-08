using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage1;
    public Image actorImage2;
    public TMP_Text actorName1;
    public TMP_Text actorName2;
    public TMP_Text dialogueText;
    public RectTransform backgroundBox;

    Dialogue[] currentDialogues;
    Actor[] currentActors;
    int activeDialogue = 0;
    public static bool isActive = false;
    public float textSpeed = 2f;

    private void Start() {
        gameObject.transform.localScale = Vector3.zero;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && isActive)
        {
            if(dialogueText.text == currentDialogues[activeDialogue].line)
            {
                NextLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = currentDialogues[activeDialogue].line;
            }
        }
    }

    public void OpenDialogue(Actor[] actors, Dialogue[] dialogues)
    {
        currentDialogues = dialogues;
        currentActors = actors;
        activeDialogue = 0;
        isActive = true;

        dialogueText.text = string.Empty;
        DisplayDialogue();
        
        gameObject.transform.localScale = Vector3.one;
    }

    void DisplayDialogue()
    {
        Dialogue dialogueTextToDisplay = currentDialogues[activeDialogue];
        StartCoroutine(TypeDialogue());

        IEnumerator TypeDialogue()
        {
            foreach (char letter in dialogueTextToDisplay.line)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        Actor actorToDisplay = currentActors[dialogueTextToDisplay.actorId];

        if(dialogueTextToDisplay.actorId == 0)
        {
            actorName1.text = actorToDisplay.name;
            actorImage1.sprite = actorToDisplay.sprite;
            
            actorImage1.gameObject.SetActive(true);
            actorImage2.gameObject.SetActive(false);
            actorName1.gameObject.SetActive(true);
            actorName2.gameObject.SetActive(false);
        }
        else
        {
            actorName2.text = actorToDisplay.name;
            actorImage2.sprite = actorToDisplay.sprite;
            
            actorImage1.gameObject.SetActive(false);
            actorImage2.gameObject.SetActive(true);
            actorName1.gameObject.SetActive(false);
            actorName2.gameObject.SetActive(true);
        }
    }

    public void FinishLine()
    {
        Debug.Log("activeDialogue: " + activeDialogue);
        activeDialogue = currentDialogues.Length + 1;
        dialogueText.text = string.Empty;
        isActive = false;
    }

    public void NextLine()
    {
        activeDialogue++;
        if (activeDialogue < currentDialogues.Length)
        {
            dialogueText.text = string.Empty;
            DisplayDialogue();
        }
        else{
            Debug.Log("conversation ended");
            isActive = false;
            gameObject.transform.localScale = Vector3.zero;
        }
    }
}
