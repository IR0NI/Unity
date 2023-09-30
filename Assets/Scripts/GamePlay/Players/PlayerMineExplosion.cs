using UnityEngine;

public class PlayerMineExplosion : MonoBehaviour
{
    private void OnEnable()
    {

        transform.localScale = new Vector3(2 * GameManager.instance.Minerange, 2 * GameManager.instance.Minerange, 0);
        CancelInvoke();
        Invoke("Deactive", 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(GameManager.instance.Minedmg);
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
