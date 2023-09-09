using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform NearestTarget;
    public Transform SecondTarget;
    Vector3 len;
    Vector3 playervec;
    Vector3 targetvec;
    float curBombDelay = 0.0f;
    float curKnifeDelay = 0.0f;
    float curBoomerangDelay = 0.0f;
    int Knifenum = 0;

    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
    }
    private void Update()
    {
        playervec = new Vector3(transform.position.x, transform.position.y, -10);
        targetvec = new Vector3(NearestTarget.transform.position.x, NearestTarget.transform.position.y, -10);
        len = targetvec - playervec;

        Bomb();
        Knife();
        Boomerang();
    }
    void Boomerang()
    {
        if( GameManager.instance.BoomerangLevel > 0)
        {
            curBoomerangDelay += Time.deltaTime;
            if (curBoomerangDelay > 5.0f)
            {
                if (GameManager.instance.BoomerangLevel == 1)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(17);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }
            }
        }
    }
    void Bomb()
    {
        if (GameManager.instance.BombLevel > 0)
        {
            curBombDelay += Time.deltaTime;
            if (curBombDelay > 2.0f)
            {


                if (GameManager.instance.BombLevel == 1)
                {
                    GameObject Bomb = GameManager.instance.pool.Get(10);
                    Bomb.transform.position = transform.position;
                    Rigidbody2D rigid = Bomb.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.BombLevel > 1)
                {
                    //Vector3 target2vec = new Vector3(SecondTarget.transform.position.x, SecondTarget.transform.position.y, -10);
                    //Vector3 len2 = target2vec - playervec;
                    GameObject Bomb1 = GameManager.instance.pool.Get(10);
                    GameObject Bomb2 = GameManager.instance.pool.Get(10);
                    Bomb1.transform.position = transform.position;
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid1 = Bomb1.GetComponent<Rigidbody2D>();
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid1.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    rigid2.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                
            }
        }
    }

    void Knife()
    {
        if (GameManager.instance.KnifeLevel > 0)
        {
            curKnifeDelay += Time.deltaTime;
            if (curKnifeDelay > 2.0f)
            {
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                if (GameManager.instance.KnifeLevel == 1)
                {
                    GameObject Knife = GameManager.instance.pool.Get(13);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    curKnifeDelay = 0.0f;
                }
                else if (GameManager.instance.KnifeLevel > 1 && GameManager.instance.KnifeLevel <= 4)
                {
                    if (Knifenum == 5 && GameManager.instance.KnifeLevel == 4)
                    {
                        GameObject Knife = GameManager.instance.pool.Get(15);
                        Knife.transform.position = transform.position;
                        Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        Knifenum = 0;
                    }
                    else
                    {
                        GameObject Knife1 = GameManager.instance.pool.Get(13);
                        GameObject Knife2 = GameManager.instance.pool.Get(13);
                        GameObject Knife3 = GameManager.instance.pool.Get(13);
                        Knife1.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, 0);
                        Knife1.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Knife2.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                        Knife2.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Knife3.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0);
                        Knife3.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Rigidbody2D rigid1 = Knife1.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigid2 = Knife2.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigid3 = Knife3.GetComponent<Rigidbody2D>();
                        rigid1.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        rigid2.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        rigid3.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    }
                    if(GameManager.instance.KnifeLevel == 2)
                    {
                        curKnifeDelay = 0.0f;
                    }else
                    {
                        curKnifeDelay = 1.0f;
                    }
                    if(GameManager.instance.KnifeLevel == 4)
                    {
                        Knifenum += 1;
                    }
                }
            }
        }

    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;
            float curDiff = Vector3.Distance(mypos, targetpos);
            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
