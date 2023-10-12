using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5attackready : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Attack", 1.0f);
    }

    void Attack()
    {
        GameObject Enemy5Bullet = GameManager.instance.pool.Get(21);
        Enemy5Bullet.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
