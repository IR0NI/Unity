using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public PlayerPetPos playerpetpos;
    public int Blocknum = 0;

    private void OnEnable()
    {
       // transform.rotation = playerpetpos.transform.rotation;
    }
    private void Awake()
    {
        transform.rotation = Quaternion.AngleAxis(0,new Vector3(playerpetpos.transform.rotation.x, playerpetpos.transform.rotation.y, -playerpetpos.transform.rotation.z));
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * 40.0f * Time.deltaTime);
        if (Player.instance.len.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (Player.instance.len.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        if(GameManager.instance.DragonLevel >= 3 && (GameManager.instance.kill - GameManager.instance.killpet) >= 400)
        {
            gameObject.layer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyAttack")
        {
            Blocknum += 1;
            if (Blocknum >= 300)
            {
                if (Player.instance.MaxHP > Player.instance.HP) { }
                Player.instance.HP += 1;
                Player.instance.Heart();
            }
                Blocknum = 0;

            }
        }
    }

