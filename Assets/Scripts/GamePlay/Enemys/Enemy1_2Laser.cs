using UnityEngine;

public class Enemy1_2Laser : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 1.0f);
        transform.localScale = new Vector3(0.5f, 100, 1);

    }
    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}
