using UnityEngine;

public class Enemy1_1Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 5.0f);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CancelInvoke();
            gameObject.SetActive(false);
        }
    }
}
