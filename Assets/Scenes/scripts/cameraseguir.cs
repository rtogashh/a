using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = target.position;
            newPos.z = transform.position.z; // keep camera's z
            transform.position = Vector3.Lerp(transform.position, newPos, smoothing * Time.deltaTime);
        }
    }
}