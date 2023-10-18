using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    Vector3 pos = new Vector3();
    private float postime = 3;
    public float HP = 200;
    private bool ishor = false;
    private bool isver = false;
    private bool isnav = false;
    private float move = 3.5f;
    public GameObject normalsprite;
    public GameObject takedamagesprite;
    
    void Update()
    {
        postime += Time.deltaTime;
        if (HP <= 0)
        {
            GameObject Can = GameManager.instance.pool.Get(5);
            Can.transform.position = transform.position;
            gameObject.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        if (postime > 3)
        {
            pos = new Vector3(Random.Range(-30, 30), Random.Range(-12, 15), 0);
            postime = 0;
        }
        if (!isnav)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, move * Time.fixedDeltaTime);
        }
        else
        {
            
            if (ishor)
            {
                if(pos.x > transform.position.x)
                {
                    transform.position += new Vector3(move, 0, 0) * Time.fixedDeltaTime;
                }
                else
                {
                    transform.position += new Vector3(-move, 0, 0) * Time.fixedDeltaTime;
                }
            } 
            if (isver )
            {
                if(pos.y > transform.position.y)
                {
                    transform.position += new Vector3(0, move, 0) * Time.fixedDeltaTime;
                }
                else
                {
                    transform.position += new Vector3(0,- move, 0) * Time.fixedDeltaTime;
                }
            }
            
        }
    }

    public void takedamage(float dmg)
    {
        HP -= dmg;
        normalsprite.SetActive(false);
        takedamagesprite.SetActive(true);
        Invoke("normal", 1.0f);
    }

    public void normal()
    {
        normalsprite.SetActive(true);
        takedamagesprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isnav)
        {
            if (collision.gameObject.tag == "Horizontalnav")
            {
                isnav = true;
                ishor = true;
            }

            if (collision.gameObject.tag == "Verticalnav")
            {
                isnav = true;
                isver = true;
            }
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            takedamage(Player.instance.AD);
        }

        if (collision.gameObject.tag == "PlayerAttack")
        {
            switch (GameReadyManager.instance.SecondWeaponNum)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Horizontalnav")
        {
            isnav = false;
            ishor = false;
        }

        if (collision.gameObject.tag == "Verticalnav")
        {
            isnav = false;
            isver = false;
        }
    }
}
