using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform NearestTarget;
    public Transform farthestTarget;
    public Transform SecondTarget;
    Vector3 len;
    Vector3 farlen;
    Vector3 secondlen;
    Vector3 playervec;
    Vector3 targetvec;
    Vector3 fartargetvec;
    Vector3 secondtargetvec;
    float curBombDelay = 0.0f;
    float curKnifeDelay = 0.0f;
    float curBoomerangDelay = 5.0f;
    int Knifenum = 0;

    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        if (Targets.Length >= 1)
        {
            NearestTarget = GetNearest();
            farthestTarget = GetFarthest();
            if (Targets.Length >= 1)
            {
                SecondTarget = GetSecond();
            }
        }
    }
    private void Update()
    {
        if (Targets.Length >= 1)
        {
            playervec = new Vector3(transform.position.x, transform.position.y, -10);
            targetvec = new Vector3(NearestTarget.transform.position.x, NearestTarget.transform.position.y, -10);
            fartargetvec = new Vector3(farthestTarget.transform.position.x, farthestTarget.transform.position.y, -10);
            if (Targets.Length >= 2)
            {
                secondtargetvec = new Vector3(SecondTarget.transform.position.x, SecondTarget.transform.position.y, -10);
            }

            len = targetvec - playervec;
            farlen = fartargetvec - playervec;
            secondlen = secondtargetvec - playervec;

            Bomb();
            Knife();
            Boomerang();
        }
    }

    
    void Boomerang()
    {
        if(GameManager.instance.SecondWepon3)
        {
            curBoomerangDelay += Time.deltaTime;
            
            if (curBoomerangDelay > 5.0f)
            {
                if (GameManager.instance.Boomerangnum > 0)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(7);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * GameManager.instance.Boomerangspeed, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }
                if (GameManager.instance.Boomerangnum > 1)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(7);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * GameManager.instance.Boomerangspeed, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }
                if (GameManager.instance.Boomerangnum > 2)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(7);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * GameManager.instance.Boomerangspeed, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }
                if (GameManager.instance.Boomerangnum > 3)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(7);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * GameManager.instance.Boomerangspeed, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }


            }
        }
    }
    void Bomb()
    {
        if (GameManager.instance.SecondWepon2)
        {
            curBombDelay += Time.deltaTime;
            if (curBombDelay > GameManager.instance.Bombtime)
            {
                if (GameManager.instance.Bombnum > 0)
                {
                    GameObject Bomb = GameManager.instance.pool.Get(3);
                    Bomb.transform.position = transform.position;
                    Rigidbody2D rigid = Bomb.GetComponent<Rigidbody2D>();
                    rigid.AddForce(secondlen.normalized * 40.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 1)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(farlen.normalized * 40.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 2)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(farlen.normalized * 40.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 3)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(farlen.normalized * 40.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }

            }
        }
    }

    void Knife()
    {
        if (GameManager.instance.SecondWepon1)
        {
            curKnifeDelay += Time.deltaTime;
            if (curKnifeDelay > GameManager.instance.Knifetime)
            {
                float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                if (GameManager.instance.Knifenum > 0)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 1)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 2)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 3)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                }

                if (GameManager.instance.Level <= 2)
                    {
                        curKnifeDelay = 0.0f;
                    }else
                    {
                        curKnifeDelay = 1.0f;
                    }
                
            }
        }

    }

    Transform GetNearest()
    {
        Transform[] result2 = new Transform[Targets.Length];
        float diff = 100;
        int i = 0;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;
            
            float curDiff = Vector3.Distance(mypos, targetpos);
            if(curDiff < diff)
            {
                diff = curDiff;
                result2[i] = target.transform;
                i += 1;
            }
        }

        return result2[i-1];
    }

    Transform GetFarthest()
    {
        Transform[] result2 = new Transform[Targets.Length];
        float diff = 100;
        int i = 0;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;

            float curDiff = Vector3.Distance(mypos, targetpos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result2[i] = target.transform;
                i += 1;
            }
        }
        return result2[0];
    }

    Transform GetSecond()
    {
        Transform[] result2 = new Transform[Targets.Length];
        float diff = 100;
        int i = 0;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;

            float curDiff = Vector3.Distance(mypos, targetpos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result2[i] = target.transform;
                i += 1;
            }
        }
        if (i >= 2)
        {
            return result2[i - 2];
        }
        else
        {
            return result2[0];
        }
    }


}
