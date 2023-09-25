using UnityEngine;

public class PlayerAxePivot : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.Level >= 4)
        {
            transform.Rotate(Vector3.back * 200.0f * Time.deltaTime);
        }
        else if(GameManager.instance.Level < 4)
        {
            transform.Rotate(Vector3.back * 150.0f * Time.deltaTime);
        }
    }
}
