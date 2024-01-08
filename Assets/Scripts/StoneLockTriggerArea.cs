using System.Collections;
using Invector.vCharacterController;
using UnityEngine;
using TMPro;

public class StoneLockTriggerArea : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    public Transform camTargetPosition;
    public float camMoveSpeed = 2.0f;
    public float camRotationSpeed = 2.0f;
    private bool playerCanInteract = false;
    public GameObject stoneLock;
    StoneLockController puzzleStoneControllerScript;
    bool disableInputMagnitudeChange = false;
    public TMP_Text interactText;

    private void Start() {
        puzzleStoneControllerScript = stoneLock.GetComponent<StoneLockController>();
        puzzleStoneControllerScript.enabled = false;
        interactText.enabled = false;
    }

    private void Update() {
        if(disableInputMagnitudeChange)
        {
            player.GetComponent<Animator>().SetFloat("InputMagnitude", 0f);
        }

        if(playerCanInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactText.text = "Press 'Esc' to exit";

                DisablePlayerInputScript(player);
                DisableCameraScript(camera);

                StartCoroutine(ChangeCameraPosition());

                puzzleStoneControllerScript.enabled = true;
                disableInputMagnitudeChange = true;
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                interactText.text = "Press 'E' to Interact";

                if(!player.GetComponent<vThirdPersonInput>().enabled)
                {
                    player.GetComponent<vThirdPersonInput>().enabled = true;
                }
                if(!camera.GetComponent<vThirdPersonCamera>().enabled)
                {
                    camera.GetComponent<vThirdPersonCamera>().enabled = true;
                }

                //stop selection highlight
                puzzleStoneControllerScript.wheelControllers[puzzleStoneControllerScript.previousWheelId].GetComponent<Renderer>().material.color =  puzzleStoneControllerScript.originalColour;
                
                //change animation to idle
                disableInputMagnitudeChange = false;
                puzzleStoneControllerScript.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCanInteract = true;
            player = collision.gameObject;
            interactText.enabled = true;
            interactText.text = "Press 'E' to Interact";
        }
    }

    private void OnTriggerStay(Collider collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCanInteract = true;
            player = collision.gameObject;
            interactText.enabled = true;
        }
    }
    
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCanInteract = false;
            player = null;
            interactText.enabled = false;
        }
    }

    private void DisablePlayerInputScript(GameObject player)
    {
        vThirdPersonInput playerInputScript = player.GetComponent<vThirdPersonInput>();

        if (playerInputScript != null)
        {
            playerInputScript.enabled = false;
        }
        else
        {
            Debug.LogWarning("vThirdPersonInput script not found on the player GameObject.");
        }
    }

    private void DisableCameraScript(Camera camera)
    {
        vThirdPersonCamera cameraScript = camera.GetComponent<vThirdPersonCamera>();

        if (cameraScript != null)
        {
            cameraScript.enabled = false;
        }
        else
        {
            Debug.LogWarning("vThirdPersonInput script not found on the player GameObject.");
        }
    }
    
    IEnumerator ChangeCameraPosition()
    {
        float elapsedTime = 0f;
        float transitionDuration = 2.0f;

        Vector3 initialPosition = camera.transform.position;
        Quaternion initialRotation = camera.transform.rotation;

        while (elapsedTime < transitionDuration)
        {
            camera.transform.position = Vector3.Lerp(initialPosition, camTargetPosition.position, elapsedTime / transitionDuration);
            camera.transform.rotation = Quaternion.Slerp(initialRotation, camTargetPosition.rotation, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        camera.transform.position = camTargetPosition.position;
        camera.transform.rotation = camTargetPosition.rotation;
    }

    void DisplayEText()
    {
        interactText.text = "Press 'E' to Interact";
    }
}
