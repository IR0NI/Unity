using UnityEngine;

public class PlayerGun3_4 : MonoBehaviour
{
    public float time = 0.0f;
    public bool changerot = false;
    private void OnEnable()
    {
        changerot = false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            if (!changerot)
            {
                changerot = true;
                Vector3 Glassvec = new Vector3(transform.position.x, transform.position.y, -10);
                Vector3 len = Player.instance.playervec - Glassvec;
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, z + 90);
            }
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, 50.0f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (time >= 2)
        {
            if (collision.gameObject.tag == "Enemy")
            {

                collision.GetComponent<Enemy>().TakeDamage(30 + Player.instance.AP *0.5f);

            }
        }
        if (collision.gameObject.tag == "Player")
        {
            Deactive();
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
