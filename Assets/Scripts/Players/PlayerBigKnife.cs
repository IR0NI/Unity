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
                collision.GetComponent<Enemy>().TakeDamage(400 + Player.instance.AP*2.0f);
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
