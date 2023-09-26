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

        switch (GameManager.instance.Axerange)
        {
            case 1:
                transform.localScale = new Vector3(1, 1, 0);
                break;
            case 2:
                transform.localScale = new Vector3(0.5f, 0.5f, 0);
                break;
            case 3:
                transform.localScale = new Vector3(0.25f, 0.25f, 0);
                break;
            case 4:
                transform.localScale = new Vector3(0.125f, 0.125f, 0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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
