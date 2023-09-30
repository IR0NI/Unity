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
    public Transform ThirdTarget;
    public Transform FourthTarget;
    Vector3 len;
    Vector3 farlen;
    Vector3 secondlen;
    Vector3 thirdlen;
    Vector3 fourthlen;
    Vector3 playervec;
    Vector3 targetvec;
    Vector3 fartargetvec;
    Vector3 secondtargetvec;
    Vector3 thirdtargetvec;
    Vector3 fourthtargetvec;
    float curBombDelay = 0.0f;
    float curKnifeDelay = 0.0f;

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
            if (Targets.Length >= 2)
            {
                ThirdTarget = GetThird();
            }
            if (Targets.Length >= 3)
            {
                FourthTarget = GetFourth();
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
            if (Targets.Length >= 3)
            {
                thirdtargetvec = new Vector3(ThirdTarget.transform.position.x, ThirdTarget.transform.position.y, -10);
            }
            if (Targets.Length >= 4)
            {
                fourthtargetvec = new Vector3(FourthTarget.transform.position.x, FourthTarget.transform.position.y, -10);
            }
            len = targetvec - playervec;
            farlen = fartargetvec - playervec;
            secondlen = secondtargetvec - playervec;
            thirdlen = thirdtargetvec - playervec;
            fourthlen = fourthtargetvec - playervec;

            Bomb();
            Knife();
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
                    rigid.AddForce(len.normalized * 60.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 1)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(secondlen.normalized * 60.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 2)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(thirdlen.normalized * 60.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.Bombnum > 3)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(3);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(fourthlen.normalized * 60.0f, ForceMode2D.Impulse);
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
                float z1 = Mathf.Atan2(secondlen.y, secondlen.x) * Mathf.Rad2Deg;
                float z2 = Mathf.Atan2(thirdlen.y, thirdlen.x) * Mathf.Rad2Deg;
                float z3 = Mathf.Atan2(fourthlen.y, fourthlen.x) * Mathf.Rad2Deg;

                if (GameManager.instance.Knifenum > 0)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 40.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 1)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z1 + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(secondlen.normalized * 40.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 2)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z2 + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(thirdlen.normalized * 40.0f, ForceMode2D.Impulse);
                }
                if (GameManager.instance.Knifenum > 3)
                {
                    GameObject Knife = GameManager.instance.pool.Get(4);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z3 + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(fourthlen.normalized * 40.0f, ForceMode2D.Impulse);
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
    Transform GetThird()
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
        if (i >= 3)
        {
            return result2[i - 3];
        }
        else
        {
            return result2[0];
        }
    }
    Transform GetFourth()
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
        if (i >= 4)
        {
            return result2[i - 4];
        }
        else
        {
            return result2[0];
        }
    }


}
