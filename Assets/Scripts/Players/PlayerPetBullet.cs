using UnityEngine;

public class PlayerPetBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD * 0.5f + Player.instance.AP * 0.5f) * (GameManager.instance.Pet1DmgUp + 10) * 0.1f);
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
