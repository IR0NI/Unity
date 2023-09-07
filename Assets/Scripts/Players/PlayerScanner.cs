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
    float curBombDelay = 0.0f;
    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
        if(GameManager.instance.BombLevel >1)
        SecondTarget = GetSecond();
    }
    private void Update()
    {
        if (GameManager.instance.BombLevel > 0)
        {
            curBombDelay += Time.deltaTime;
            if (curBombDelay > 2.0f)
            {
                Vector3 playervec = new Vector3(transform.position.x, transform.position.y, -10);
                Vector3 targetvec = new Vector3(NearestTarget.transform.position.x, NearestTarget.transform.position.y, -10);

                Vector3 len = targetvec - playervec;

                switch (GameManager.instance.BombLevel)
                {
                    case 1:
                        GameObject Bomb = GameManager.instance.pool.Get(10);
                        Bomb.transform.position = transform.position;
                        Rigidbody2D rigid = Bomb.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        curBombDelay = 0.0f;
                        break;
                    case 2:
                        Vector3 target2vec = new Vector3(SecondTarget.transform.position.x, SecondTarget.transform.position.y, -10);
                        Vector3 len2 = target2vec - playervec;
                        GameObject Bomb1 = GameManager.instance.pool.Get(10);
                        GameObject Bomb2 = GameManager.instance.pool.Get(10);
                        Bomb1.transform.position = transform.position;
                        Bomb2.transform.position = transform.position;
                        Rigidbody2D rigid1 = Bomb1.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigid2 = Bomb2.GetComponent<Rigidbody2D>();
                        rigid1.AddForce(len.normalized * 25.0f, ForceMode2D.Impulse);
                        rigid2.AddForce(len2.normalized * 25.0f, ForceMode2D.Impulse);
                        curBombDelay = 0.0f;
                        break;

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

    Transform GetSecond()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in Targets)
        {
            Vector3 mypos = transform.position;
            Vector3 targetpos = target.transform.position;
            float curDiff = Vector3.Distance(mypos, targetpos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
