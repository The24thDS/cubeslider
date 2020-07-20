using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        Vector3 playerZVector = new Vector3(0, 0, playerTransform.position.z);
        Vector3 offsetVector = new Vector3(0, 2, -4);
        transform.position = playerZVector + offsetVector;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
