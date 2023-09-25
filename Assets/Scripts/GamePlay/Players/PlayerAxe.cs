using UnityEngine;

public class PlayerAxe : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Rotate(Vector3.back * GameManager.instance.Axespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(GameManager.instance.Axedmg);
                Deactive();
        }
    }

    void Deactive()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 0);
        Invoke("Active", GameManager.instance.Axetime);
    }

    void Active()
    {
        
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
