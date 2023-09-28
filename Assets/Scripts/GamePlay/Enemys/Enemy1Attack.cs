using UnityEngine;

public class Enemy1Attack : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 0.5f);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
