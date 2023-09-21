using UnityEngine;

public class PlayerBigKnife : MonoBehaviour
{
    public bool touch = false;
    private void OnEnable()
    {
        touch = false;
        Invoke("Deactive", 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!touch)
            {
                touch = true;
                collision.GetComponent<Enemy>().TakeDamage(80 + Player.instance.AP*1.2f);
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
