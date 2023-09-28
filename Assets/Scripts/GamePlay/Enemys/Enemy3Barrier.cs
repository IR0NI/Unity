using UnityEngine;

public class Enemy3Barrier : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back * 150 * Time.deltaTime);
    }
}
