using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    Vector3 startpos;
    Rigidbody2D rigid2D;
    private void OnEnable()
    {
        if (GameManager.instance.EnergyLevel > 3)
        {
            rigid2D = GetComponent<Rigidbody2D>();
            startpos = transform.position;
            Invoke("BackMove", 3.0f);
        }
        else
        {
            Invoke("Deactive", 4.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (GameManager.instance.EnergyLevel == 1)
            {
                collision.GetComponent<Enemy>().TakeDamage(15 + Player.instance.AP * 0.3f);
            }else if(GameManager.instance.EnergyLevel > 1)
            {
                collision.GetComponent<Enemy>().TakeDamage((30 + Player.instance.AP * 0.5f) * (GameManager.instance.EnergyDmgUP + 10) * 0.1f);
            }
        }
    }
    void BackMove()
    {
        Vector3 backmove;
        backmove = startpos - transform.localPosition;
        rigid2D.velocity = Vector2.zero;
        rigid2D.AddForce(backmove.normalized*20f, ForceMode2D.Impulse);
        Invoke("Deactive", 3.0f);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
