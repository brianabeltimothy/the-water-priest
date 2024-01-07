using UnityEngine;

public class CameraAngleController : MonoBehaviour
{
    public Camera[] cameras;
    private int cameraCount;
    private Camera currentActiveCamera;

    public float zoomSpeed = 5f;
    public float minFOV = 10f;
    public float maxFOV = 60f;

    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        currentActiveCamera = cameras[0];
    }

    void FixedUpdate()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                foreach (var cam in cameras)
                {
                    cam.gameObject.SetActive(false);
                }
                cameras[i].gameObject.SetActive(true);
                currentActiveCamera = cameras[i];
            }
        }

        ZoomIn(currentActiveCamera);
    }

    void ZoomIn(Camera cam)
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (zoomSpeed * Time.deltaTime), minFOV, maxFOV);
        }
        else
            cam.fieldOfView = 60;
    }
}
