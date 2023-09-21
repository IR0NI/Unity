using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_3Bullet : MonoBehaviour
{
    public GameObject NarrowSightPot;
    private Rigidbody2D rigid;
    public bool EliteElite = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Invoke("Boom", 0.7f);

    }

    private void DeActive()
    {
        EliteElite = false;
        NarrowSightPot.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Boom()
    {
        Invoke("DeActive", 5.0f);
        rigid.velocity = Vector2.zero;
        NarrowSightPot.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke();
            Boom();

        }
    }
}
