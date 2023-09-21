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
                if (GameManager.instance.KunaiLevel == 1)
                {
                    touch = true;
                    collision.GetComponent<Enemy>().TakeDamage(10 + Player.instance.AP * 0.3f);
                    Deactive();
                }else if (GameManager.instance.KunaiLevel >= 2)
                {
                    touch = true;
                    collision.GetComponent<Enemy>().TakeDamage((15 + Player.instance.AP * 0.5f)*(GameManager.instance.KunaiDmgUp+10)*0.1f);
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
