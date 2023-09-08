using UnityEngine;

public class PlayerAxePivot : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.AxeLevel == 4)
        {
            transform.Rotate(Vector3.back * 200.0f * Time.deltaTime);
        }
        else if(GameManager.instance.AxeLevel < 4)
        {
            transform.Rotate(Vector3.back * 100.0f * Time.deltaTime);
        }
    }
}
