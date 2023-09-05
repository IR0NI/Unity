using UnityEngine;

public class Enemy1_3Bullet : MonoBehaviour
{
    public GameObject SlowPot;
    private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Invoke("Boom", 0.7f);
        
    }

    private void DeActive()
    {
        SlowPot.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Boom()
    {
        Invoke("DeActive", 5.0f);
        rigid.velocity = Vector2.zero;
        SlowPot.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke();
            Boom();
            
        }
    }
}
