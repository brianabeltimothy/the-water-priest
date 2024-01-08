using System;
using Invector.vCharacterController;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public static GameObject player;
    private static bool isInteracting = false;

    public static void SetPlayerInteraction(bool interacting)
    {
        isInteracting = interacting;

        vThirdPersonInput playerInputScript = player.GetComponent<vThirdPersonInput>();
        if (playerInputScript != null)
        {
            playerInputScript.enabled = !interacting;

            // Conditionally set input magnitude to 0 only when interacting
            if (interacting)
            {
                SetInputMagnitude();
                playerInputScript.enabled = false;
            }
        }
        else
        {
            Debug.LogError("vThirdPersonInput script not found on the player GameObject.");
        }

    }

    private static void SetInputMagnitude()
    {
        // Set the input magnitude in your player input script
        player.GetComponent<Animator>().SetFloat("InputMagnitude", 0f);
    }

}