using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_4Summon : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 2.0f);
    }

    void Deactive()
    {
        GameObject Enemy2_4 = GameManager.instance.pool.Get(19);
        Enemy2_4.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
