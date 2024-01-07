using UnityEngine;

public class BoulderRockController : MonoBehaviour
{
    public GameObject rock;
    public bool addForceRock = false;
    public float forceMagnitude = 1000f;
    Vector3 forceDirection = new Vector3(-1f, 0f, 0f);

    private void Start()
    {
        GameEvents.current.BoulderEvent += MoveBoulderRock;
    }

    private void MoveBoulderRock()
    {
        if (rock.GetComponent<Rigidbody>() == null)
        {
            addForceRock = true;
            Rigidbody rb = rock.AddComponent<Rigidbody>();

            rb.mass = 10000f;
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }

    private void OnDestroy() {
        GameEvents.current.BoulderEvent -= MoveBoulderRock;
    }
}
