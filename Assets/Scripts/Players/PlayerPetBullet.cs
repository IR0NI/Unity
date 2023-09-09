using UnityEngine;

public class PlayerPetBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD+Player.instance.AP);
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
