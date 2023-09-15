using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPet2Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameManager.instance.Pet2Level == 1)
            {
                collision.GetComponent<Enemy>().TakeDamage(5 + Player.instance.AP * 0.3f);
            }else if(GameManager.instance.Pet2Level > 1)
            {
                collision.GetComponent<Enemy>().TakeDamage(15 + Player.instance.AP * 0.5f);
            }

        }
    }
}
