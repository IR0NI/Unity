using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnEnable()
    {
        
        CancelInvoke();
        Invoke("Deactive", 1.5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            switch (GameManager.instance.Gun2Level)
            {
                case 0:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
                    Deactive();
                    break;

                case 1:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 100.0f + Player.instance.AP * 1.0f);
                    Deactive();
                    break;

                case 2:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    collision.GetComponent<Enemy>().MoveZero();
                    Deactive();
                    break;

                case 3:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    collision.GetComponent<Enemy>().MoveZero();
                    break;

                case 4:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    collision.GetComponent<Enemy>().MoveZero();
                    int ran = Random.Range(1, 2);
                    if(ran == 1)
                    {
                        collision.GetComponent<Enemy>().Explosion(this.transform);
                    }
                    break;
            }
        }
    }
    private void Deactive()
    {
        gameObject.SetActive(false);
    }
}
