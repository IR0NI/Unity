using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public GameObject BombExplosion;
    private Rigidbody2D rigid2D;
    private SpriteRenderer spriteRenderer;

    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform NearestTarget;
    public bool isboom = false;
    private void OnEnable()
    {
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
    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
        if (Targets.Length >= 1 && !isboom)
        {
            transform.position = Vector2.MoveTowards(transform.position, NearestTarget.transform.position, 10.0f * Time.deltaTime);
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
        CancelInvoke();
        Invoke("DeActive", 1.2f);
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;
        int i = 0;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;

            float curDiff = Vector3.Distance(mypos, targetpos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
                i += 1;
            }
        }

        return result;
    }
}
