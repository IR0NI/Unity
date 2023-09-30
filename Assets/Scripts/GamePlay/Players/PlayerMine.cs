using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : MonoBehaviour
{
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactive", 15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject MineExplosion = GameManager.instance.pool.Get(1);
            MineExplosion.transform.position = transform.position;
            Deactive();
        }
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
