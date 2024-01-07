using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour
{   
    public GameObject[] doors;
    private bool isOpened = false;
    Vector3 leftDoorTargetPos;
    Vector3 rightDoorTargetPos;

    private void Start() {
        LockControl.OpenDoorEvent += OpenDoors;

        leftDoorTargetPos = new Vector3(doors[0].transform.position.x + 2.5f, doors[0].transform.position.y, doors[0].transform.position.z);
        rightDoorTargetPos = new Vector3(doors[1].transform.position.x - 2.5f, doors[1].transform.position.y, doors[1].transform.position.z);
    }

    private void Update() {
        if(isOpened)
        {
            StartCoroutine(OpenDoorsCoroutine());
        }
    }

    void OpenDoors()
    {
        isOpened = true;
    }

    IEnumerator OpenDoorsCoroutine()
    {
        yield return new WaitForSeconds(2.0f);

        float elapsedTime = 0f;
        float transitionDuration = 2.0f;

        Vector3 leftDoorInitialPos = doors[0].transform.position;
        Vector3 rightDoorInitialPos = doors[1].transform.position;

        while (elapsedTime < transitionDuration)
        {
            doors[0].transform.position = Vector3.Lerp(leftDoorInitialPos, leftDoorTargetPos, elapsedTime / transitionDuration);
            doors[1].transform.position = Vector3.Lerp(rightDoorInitialPos, rightDoorTargetPos, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        doors[0].transform.position = leftDoorTargetPos;
        doors[1].transform.position = rightDoorTargetPos;
    }
}
