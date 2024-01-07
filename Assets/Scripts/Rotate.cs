using System.Collections;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    private void Update() {
        if (coroutineAllowed)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("rightkey works");
                StartCoroutine(RotateWheel(60.0f));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("left key works");
                StartCoroutine(RotateWheel(-60.0f));
            }
        }
    }

    float totalRotation = 0f;
    private IEnumerator RotateWheel(float rotateDirection)
    {
        coroutineAllowed = false;
        
        float elapsedTime = 0f;
        float rotationDuration = 1f; // Adjust the duration of rotation as needed
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < rotationDuration)
        {
            transform.rotation *= Quaternion.Euler(0f, rotateDirection * Time.deltaTime / rotationDuration, 0f);
            totalRotation += rotateDirection * Time.deltaTime / rotationDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 6)
        {
            numberShown = 1;
        }

        Rotated(name, numberShown);
        Debug.Log("name: " + name);
        Debug.Log("numberShown: " + numberShown);
    }
}
