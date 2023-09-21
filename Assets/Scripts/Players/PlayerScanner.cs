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
    Vector3 len2;
    Vector3 playervec;
    Vector3 targetvec;
    Vector3 fartargetvec;
    Vector3 secondtargetvec;
    float curBombDelay = 0.0f;
    float curKnifeDelay = 0.0f;
    float curBoomerangDelay = 5.0f;
    float curDragonatkDelay = 0.0f;
    int Knifenum = 0;
    public GameObject Pet1leftatk;
    public GameObject Pet1rightatk;
    public GameObject Pet2leftatk;
    public GameObject Pet2rightatk;

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
            PetAttack();
        }
    }

    void PetAttack()
    {
        if (GameManager.instance.DragonLevel > 0 && Player.instance.isPet == true)
        {
            Vector3 len_5 = Quaternion.AngleAxis(5, new Vector3(0, 0, 1)) * len;
            Vector3 len__5 = Quaternion.AngleAxis(-5, new Vector3(0, 0, 1)) * len;
            len2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playervec;
            curDragonatkDelay += Time.deltaTime;
            if (curDragonatkDelay > Player.instance.MaxFireDelay * 100.0f / (100.0f + Player.instance.AS))
            {
                if (GameManager.instance.DragonLevel >= 1 )
                {
                    GameObject PetAtk = GameManager.instance.pool.Get(18);
                    if(len2.x < 0)
                    {
                        PetAtk.transform.position = Pet1leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk.transform.position = Pet1rightatk.transform.position;
                    }
                    Rigidbody2D rigid = PetAtk.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                }

                if (GameManager.instance.DragonLevel >= 2 && (GameManager.instance.kill - GameManager.instance.killpet) >= 200)
                {
                    GameObject PetAtk = GameManager.instance.pool.Get(18);
                    if (len2.x < 0)
                    {
                        PetAtk.transform.position = Pet1leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk.transform.position = Pet1rightatk.transform.position;
                    }
                    Rigidbody2D rigid = PetAtk.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len_5.normalized * 25.0f, ForceMode2D.Impulse);
                    GameObject PetAtk2 = GameManager.instance.pool.Get(18);
                    if (len2.x < 0)
                    {
                        PetAtk2.transform.position = Pet1leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk2.transform.position = Pet1rightatk.transform.position;
                    }
                    Rigidbody2D rigid2 = PetAtk2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(len__5.normalized * 25.0f, ForceMode2D.Impulse);
                }

                if (GameManager.instance.DragonLevel >= 4 && (GameManager.instance.kill - GameManager.instance.killpet) >= 700)
                {
                    GameObject PetAtk = GameManager.instance.pool.Get(18);
                    if (len2.x < 0)
                    {
                        PetAtk.transform.position = Pet2leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk.transform.position = Pet2rightatk.transform.position;
                    }
                    Rigidbody2D rigid = PetAtk.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len_5.normalized * 25.0f, ForceMode2D.Impulse);
                    GameObject PetAtk2 = GameManager.instance.pool.Get(18);
                    if (len2.x < 0)
                    {
                        PetAtk2.transform.position = Pet2leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk2.transform.position = Pet2rightatk.transform.position;
                    }
                    Rigidbody2D rigid2 = PetAtk2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    GameObject PetAtk3 = GameManager.instance.pool.Get(18);
                    if (len2.x < 0)
                    {
                        PetAtk3.transform.position = Pet2leftatk.transform.position;
                    }
                    else if (len2.x > 0)
                    {
                        PetAtk3.transform.position = Pet2rightatk.transform.position;
                    }
                    Rigidbody2D rigid3 = PetAtk3.GetComponent<Rigidbody2D>();
                    rigid3.AddForce(len__5.normalized * 25.0f, ForceMode2D.Impulse);
                }
                curDragonatkDelay = 0.0f;
            }
            
        }

    }
    void Boomerang()
    {
        if( GameManager.instance.BoomerangLevel > 0)
        {
            curBoomerangDelay += Time.deltaTime;
            
            if (curBoomerangDelay > 5.0f)
            {
                if (GameManager.instance.BoomerangLevel >= 1)
                {
                    GameObject Boomerang = GameManager.instance.pool.Get(17);
                    Boomerang.transform.position = transform.position;
                    Rigidbody2D rigid = Boomerang.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    curBoomerangDelay = 0.0f;
                }

                if(GameManager.instance.BoomerangLevel == 4)
                {
                    GameObject Boomerang1 = GameManager.instance.pool.Get(17);
                    Boomerang1.transform.position = transform.position;
                    Rigidbody2D rigid1 = Boomerang1.GetComponent<Rigidbody2D>();
                    rigid1.AddForce(secondlen.normalized * 25.0f, ForceMode2D.Impulse);
                    GameObject Boomerang2 = GameManager.instance.pool.Get(17);
                    Boomerang2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Boomerang2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(farlen.normalized * 25.0f, ForceMode2D.Impulse);
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


                if (GameManager.instance.BombLevel >= 1)
                {
                    GameObject Bomb = GameManager.instance.pool.Get(10);
                    Bomb.transform.position = transform.position;
                    Rigidbody2D rigid = Bomb.GetComponent<Rigidbody2D>();
                    rigid.AddForce(secondlen.normalized * 25.0f, ForceMode2D.Impulse);
                    curBombDelay = 0.0f;
                }
                if (GameManager.instance.BombLevel >= 2)
                {
                    GameObject Bomb2 = GameManager.instance.pool.Get(10);
                    Bomb2.transform.position = transform.position;
                    Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                    rigid2.AddForce(farlen.normalized * 25.0f, ForceMode2D.Impulse);
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
                if (Knifenum < 5 && GameManager.instance.KnifeLevel >= 1)
                {
                    GameObject Knife = GameManager.instance.pool.Get(13);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    if (GameManager.instance.KnifeLevel >= 2)
                    {
                        GameObject Knife2 = GameManager.instance.pool.Get(13);
                        GameObject Knife3 = GameManager.instance.pool.Get(13);
                        Knife2.transform.position = new Vector3(transform.position.x + 1.0f, transform.position.y +1.0f, 0);
                        Knife2.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Knife3.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y - 1.0f, 0);
                        Knife3.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                        Rigidbody2D rigid2 = Knife2.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigid3 = Knife3.GetComponent<Rigidbody2D>();
                        rigid2.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        rigid3.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    }
                }
                else if (Knifenum == 5 && GameManager.instance.KnifeLevel >= 4)
                {
                    GameObject Knife = GameManager.instance.pool.Get(15);
                    Knife.transform.position = transform.position;
                    Knife.transform.rotation = Quaternion.Euler(0, 0, z + 270);
                    Rigidbody2D rigid = Knife.GetComponent<Rigidbody2D>();
                    rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                    Knifenum = 0;
                }
                
                    if(GameManager.instance.KnifeLevel <= 2)
                    {
                        curKnifeDelay = 0.0f;
                    }else
                    {
                        curKnifeDelay = 1.0f;
                    }
                    if(GameManager.instance.KnifeLevel >= 4)
                    {
                        Knifenum += 1;
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
