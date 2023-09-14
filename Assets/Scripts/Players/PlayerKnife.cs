using UnityEngine;

public class PlayerKnife : MonoBehaviour
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
                collision.GetComponent<Enemy>().TakeDamage(20 + Player.instance.AP);
                Deactive();
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
