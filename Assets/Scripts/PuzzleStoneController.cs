using System;
using System.Collections;
using UnityEngine;

public class StoneLockController : MonoBehaviour
{
  public static event Action<string, int, int> Rotated = delegate { };
  [SerializeField] private GameObject[] wheels;
  public GameObject[] wheelControllers;
  private int selectedWheelId;
  private bool coroutineAllowed;
  private int numberShownWheel0;
  private int numberShownWheel1;

  //selection highlight
  public Material highlightMaterial;
  private Material originalMaterial;
  public Color originalColour; 
  Color highlightColour;
  Color targetColour; // can be originalColour or highlightColour
  float highlightDuration = 2.0f;
  float elapsedTime;
  float totalRotation = 0f;

  private void Start()
  {
      coroutineAllowed = true;
      numberShownWheel0 = 1;
      numberShownWheel1 = 1;

      selectedWheelId = 0;

      // selection highlight
      Renderer renderer = GetComponent<Renderer>();
      originalMaterial = wheels[selectedWheelId].GetComponent<Renderer>().material;

      originalColour = originalMaterial.color;
      highlightColour = new Color(highlightMaterial.color.r, highlightMaterial.color.g, highlightMaterial.color.b, 1);

      targetColour = highlightColour;
  }
  public int previousWheelId = 0;
  private void Update() 
  {
    SelectWheel();
    
    if (selectedWheelId != previousWheelId)
    {
      wheelControllers[previousWheelId].GetComponent<Renderer>().material.color =  originalColour;
      previousWheelId = selectedWheelId;
    }
    GraduallyHighlight(wheelControllers[selectedWheelId]);

    if (coroutineAllowed)
    {
      if (Input.GetKeyDown(KeyCode.A))
      {
        StartCoroutine(RotateWheel(60.0f, wheels[selectedWheelId]));
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
        StartCoroutine(RotateWheel(-60.0f, wheels[selectedWheelId]));
      }
    }
  }

  void SelectWheel()
  {
      if (Input.GetKeyDown(KeyCode.W))
      {
        selectedWheelId -= 1;
        if (selectedWheelId < 0)
        {
          selectedWheelId = 1;
        }
      }
      else if (Input.GetKeyDown(KeyCode.S))
      {
        selectedWheelId += 1;
        
        if (selectedWheelId > 1)
        {
          selectedWheelId = 0;
        }
      }
  }

  private IEnumerator RotateWheel(float rotateDirection, GameObject wheel)
  {
      coroutineAllowed = false;
      
      float elapsedTime = 0f;
      float rotationDuration = 1f;

      while (elapsedTime < rotationDuration)
      {
          wheel.transform.rotation *= Quaternion.Euler(0f, rotateDirection * Time.deltaTime / rotationDuration, 0f);
          totalRotation += rotateDirection * Time.deltaTime / rotationDuration;
          elapsedTime += Time.deltaTime;
          yield return null;
      }

      coroutineAllowed = true;

      if(selectedWheelId == 0)
      {
        if(rotateDirection > 0)
        {
          numberShownWheel0 += 1;

          if (numberShownWheel0 > 6)
          {
            numberShownWheel0 = 1;
          }
        }
        else{
          numberShownWheel0 -= 1;
          if (numberShownWheel0 < 1)
          {
            numberShownWheel0 = 6;
          }
        }
        Rotated(name, selectedWheelId, numberShownWheel0);
        Debug.Log("name: " + name);
        Debug.Log("selectedWheelId: " + selectedWheelId);
        Debug.Log("numberShown: " + numberShownWheel0);
      }
      else{
        if(rotateDirection > 0)
        {
          numberShownWheel1 += 1;

          if (numberShownWheel1 > 6)
          {
            numberShownWheel1 = 1;
          }
        }
        else{
          numberShownWheel1 -= 1;
          if (numberShownWheel1 < 1)
          {
            numberShownWheel1 = 6;
          }
        }
        Rotated(name, selectedWheelId, numberShownWheel1);
        Debug.Log("name: " + name);
        Debug.Log("selectedWheelId: " + numberShownWheel1);
        Debug.Log("numberShown: " + numberShownWheel1);
      }
  }

  void GraduallyHighlight(GameObject wheel)
  {
    originalMaterial = wheel.GetComponent<Renderer>().material;

    elapsedTime += Time.deltaTime/highlightDuration;

    originalMaterial.color = Color.Lerp(originalMaterial.color, targetColour, elapsedTime);
    if(originalMaterial.color == targetColour)
    {
      elapsedTime = 0;
      if(originalMaterial.color == originalColour)
      {
        targetColour = highlightColour;
      }
      else{
        targetColour = originalColour;
      }
    }
  }
}
