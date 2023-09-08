using UnityEngine;

public class PlayerAxePivot : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back * 100.0f * Time.deltaTime);
    }
}
