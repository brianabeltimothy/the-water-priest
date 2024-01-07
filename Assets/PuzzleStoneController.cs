// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PuzzleStoneController : MonoBehaviour
// {
//     public GameObject wheelOne;
//     public GameObject wheelTwo;
//     private int[] result, correctCombination;
//     private bool isOpened;
//     public GameObject[] wheels;
//     private int currentWheelId = 0;
//     private bool coroutineAllowed;
//     private int numberShown;
//     private bool wheelIsSelected;
    
//     private void Start() {
//         result = new int[]{0, 0};
//         correctCombination = new int[] {1, 6};

//         coroutineAllowed = true;
//         numberShown = 0;
//     }

// // private void Update() {
        
// //         if (Input.GetKeyDown(KeyCode.W))
// //         {   
// //             if(currentWheelId > wheels.Length)
// //             {
// //                 currentWheelId = 0;
// //             }else{
// //                 currentWheelId++;
// //             }
// //         }
// //         else if (Input.GetKeyDown(KeyCode.S))
// //         {
// //             if(currentWheelId < wheels.Length)
// //             {
// //                 currentWheelId = wheels.Length - 1;
// //             }else{
// //                 currentWheelId--;
// //             }
// //         }
    
// //     }
//     private void Update() {
//         if (coroutineAllowed &&)
//         {
//             if (Input.GetKeyDown(KeyCode.A))
//             {
//                 Debug.Log("rightkey works");
//                 StartCoroutine(RotateWheel(60.0f));
//             }
//             else if (Input.GetKeyDown(KeyCode.D))
//             {
//                 Debug.Log("left key works");
//                 StartCoroutine(RotateWheel(-60.0f));
//             }
//         }
//     }

//     float totalRotation = 0f;
//     private IEnumerator RotateWheel(float rotateDirection)
//     {
//         coroutineAllowed = false;
        
//         float elapsedTime = 0f;
//         float rotationDuration = 1f; // Adjust the duration of rotation as needed
//         Quaternion startRotation = transform.rotation;

//         while (elapsedTime < rotationDuration)
//         {
//             transform.rotation *= Quaternion.Euler(0f, rotateDirection * Time.deltaTime / rotationDuration, 0f);
//             totalRotation += rotateDirection * Time.deltaTime / rotationDuration;
//             elapsedTime += Time.deltaTime;
//             yield return null;
//         }

//         coroutineAllowed = true;

//         numberShown += 1;

//         if (numberShown > 6)
//         {
//             numberShown = 1;
//         }
//     }
// }
