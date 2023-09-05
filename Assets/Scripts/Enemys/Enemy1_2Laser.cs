using UnityEngine;

public class Enemy1_2Laser : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 1.0f);

    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}
