using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPet2 : MonoBehaviour
{
    public GameObject Attack;
    private float MoveTime = 0.0f;
    private void OnEnable()
    {
        float ran = Random.Range(0, 3);
        Invoke("Active", ran);
        MoveTime = Random.Range(0, 6);
    }
    private void FixedUpdate()
    {
        MoveTime += Time.fixedDeltaTime;
        if (MoveTime < 1.5f)
        {
            transform.position += new Vector3(2, 0, 0) * Time.fixedDeltaTime;
        }else if(MoveTime >= 1.5f && MoveTime < 3.0f)
        {
            transform.position += new Vector3(0, -2, 0) * Time.fixedDeltaTime;
            
        }else if(MoveTime >= 3.0f && MoveTime < 4.5f)
        {
            transform.position += new Vector3(-2, 0, 0) * Time.fixedDeltaTime;
        }
        else if(MoveTime >= 4.5f)
        {
            transform.position += new Vector3(0, 2, 0) * Time.fixedDeltaTime;
            if (MoveTime > 6.0f)
            {
                MoveTime = 0.0f;
            }
        }
    }

    void Active()
    {
        if (GameManager.instance.Pet2Level > 2)
        {
            Attack.transform.localScale = new Vector3(4, 4, 0);
        }
        Attack.SetActive(true);
        Invoke("Deactive", 1.0f);
    }

    void Deactive()
    {
        Attack.SetActive(false);
        Invoke("Active", 2.0f);
    }
}
