using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 0.7f);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(10);
        }

    }
}
