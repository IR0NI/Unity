using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public GameObject BombExplosion;
    private Rigidbody2D rigid2D;
    private SpriteRenderer spriteRenderer;
    public bool isboom = false;
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("DeActive", 3.0f);
        BombExplosion.SetActive(false);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 1);
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isboom = true;
            Boom();
        }
    }
    private void Boom()
    {
        rigid2D.velocity = Vector3.zero;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        spriteRenderer.color = new Color(1, 1, 1, 0);
        BombExplosion.SetActive(true);
        switch (GameManager.instance.Bombrange)
        {
            case 1:
                BombExplosion.transform.localScale = new Vector3(2, 2, 0);
                break;
            case 2:
                BombExplosion.transform.localScale = new Vector3(4, 4, 0);
                break;
            case 3:
                BombExplosion.transform.localScale = new Vector3(6, 6, 0);
                break;
            case 4:
                BombExplosion.transform.localScale = new Vector3(8, 8, 0);
                break;
        }
        CancelInvoke();
        Invoke("DeActive", 1.2f);
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
