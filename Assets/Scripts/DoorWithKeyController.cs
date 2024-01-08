using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKeyController : MonoBehaviour
{
    bool isOpened = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(isOpened)
        {
            StartCoroutine(OpenDoorsCoroutine());
        }
        StartCoroutine(OpenDoorsCoroutine());
    }

    IEnumerator OpenDoorsCoroutine()
    {
        yield return new WaitForSeconds(2.0f);

        float elapsedTime = 0f;
        float duration = 2f;

        Vector3 targetPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

        while(elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }   
}
