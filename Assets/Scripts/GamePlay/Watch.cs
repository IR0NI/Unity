using UnityEngine;

public class Watch : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back * 2.0f * Time.deltaTime);
    }
}
