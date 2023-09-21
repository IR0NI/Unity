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
        transform.Rotate(Vector3.back * 150.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (GameManager.instance.AxeLevel == 1)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(40 + Player.instance.AP * 1.2f);
                Deactive();
            }else if(GameManager.instance.AxeLevel == 2)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(60 + Player.instance.AP * 1.8f);
                Deactive();
            }else if(GameManager.instance.AxeLevel > 2)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage((60 + Player.instance.AP * 1.8f)*(GameManager.instance.AxeDmgUp+10)*0.1f);
            }
        }
    }

    void Deactive()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 0);
        Invoke("Active", 2.0f);
    }

    void Active()
    {
        
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
