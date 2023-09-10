using UnityEngine;

public class Enemy1_2Laser : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 1.0f);
        transform.localScale = new Vector3(0.5f, 100, 1);
        if (transform.GetComponentInParent<Enemy>().Elite == 1)
        {
            transform.localScale = new Vector3(5, 100, 1);
        }

    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}
