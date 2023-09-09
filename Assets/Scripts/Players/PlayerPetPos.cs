using UnityEngine;

public class PlayerPetPos : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * 40.0f * Time.deltaTime);
    }
}
