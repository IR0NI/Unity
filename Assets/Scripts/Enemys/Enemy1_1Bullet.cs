using UnityEngine;

public class Enemy1_1Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 7.0f);
        transform.localScale = new Vector3(0.25f, 0.25f, 0);

    }
    public void EliteElite()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke();
            DeActive();
        }

        if (collision.gameObject.tag == "PlayerBarrier")
        {
            CancelInvoke();
            DeActive();
        }
    }
}
