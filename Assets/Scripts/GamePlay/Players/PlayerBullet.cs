using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int bulletpeneration = 1;


    private void OnEnable()
    {
        bulletpeneration = Player.instance.Bulletpeneration;
        CancelInvoke();
        Invoke("Deactive", Player.instance.BulletTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetComponent<Enemy>().HP > 0)
            {
                if (bulletpeneration > 0)
                {
                    bulletpeneration -= 1;
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
                    if (bulletpeneration < 1)
                    {
                        Deactive();
                    }
                }
            }
        }

    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
