using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back * 50.0f * Time.deltaTime);
    }
}
