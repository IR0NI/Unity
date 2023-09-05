using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public static Gun2 instance;
    private Animator animator;
    public Transform GunHud;
    public SpriteRenderer spriteRenderer;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        Vector3 playervec = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, -10);
        Vector3 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playervec;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        transform.position = GunHud.transform.position + len.normalized;
        if (len.x > 0)
        {
            spriteRenderer.flipY = false;
        }
        else if (len.x < 0)
        {
            spriteRenderer.flipY = true;
        }
    }

    public void Shot()
    {
        animator.SetTrigger("Shot");
    }
    public void Idle()
    {
        animator.SetTrigger("Idle");
    }

}
