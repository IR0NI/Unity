using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 4.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(15 + Player.instance.AP * 0.3f);
        }
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
