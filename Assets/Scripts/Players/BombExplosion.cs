using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DeActive", 0.3f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (GameManager.instance.BombLevel <= 2)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(100.0f + 0.5f * Player.instance.AP);
            }
            else
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(200.0f + 0.8f * Player.instance.AP);
            }
        }
    }
    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
