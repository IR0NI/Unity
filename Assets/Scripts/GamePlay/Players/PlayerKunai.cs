using UnityEngine;

public class PlayerKunai : MonoBehaviour
{
    public bool touch = false;
    private void OnEnable()
    {
        touch = false;
        CancelInvoke();
        Invoke("Deactive", 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!touch)
            {
                
                    touch = true;
                    collision.GetComponent<Enemy>().TakeDamage(10);
                    Deactive();
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
