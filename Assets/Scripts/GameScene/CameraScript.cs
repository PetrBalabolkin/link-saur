using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public float smoothing;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothing);
    }
}
