using UnityEngine;

public class PlayerKnife : MonoBehaviour
{
    private int knifepeneration = 1;
    private void OnEnable()
    {
        knifepeneration = GameManager.instance.Knifepenetration;
        CancelInvoke();
        Invoke("Deactive", 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (knifepeneration>=1)
            {
                knifepeneration -= 1;
                collision.GetComponent<Enemy>().TakeDamage(GameManager.instance.Knifedmg);
                if (knifepeneration < 1)
                {
                    Deactive();
                }
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
