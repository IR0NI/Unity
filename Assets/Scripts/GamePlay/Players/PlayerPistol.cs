using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
    public Transform GunHud;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        Vector3 playervec = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, -10);
        Vector3 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playervec;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        transform.position = GunHud.transform.position + len.normalized * 1f;
        if (len.x > 0)
        {
            spriteRenderer.flipY = false;
        }
        else if (len.x < 0)
        {
            spriteRenderer.flipY = true;
        }
    }
    public void transparency()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
    }

    public void normal()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1.0f);
    }
}
