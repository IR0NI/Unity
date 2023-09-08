using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public GameObject BombExplosion;
    private Rigidbody2D rigid2D;
    private SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        Invoke("DeActive", 3.0f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 1);
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Boom();
        }
    }
    private void Boom()
    {
        rigid2D.velocity = Vector3.zero;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 0);
        BombExplosion.SetActive(true);
        if(GameManager.instance.BombLevel == 4)
        {
            BombExplosion.transform.localScale = new Vector3(5, 5, 0);
        }
        Invoke("DeActive", 1.2f);
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
