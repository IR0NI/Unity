using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public bool touch = false;
    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform NearestTarget;
    private void OnEnable()
    {
        touch = false;
        CancelInvoke();
        Invoke("Deactive", 1.5f);

    }

    private void Update()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
        if (!touch && GameManager.instance.HitBullet > 0.05f)
        {
            switch (GameManager.instance.Gun2Level)
            {
                case 0:
                    if (!touch)
                        NearestTarget.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
                    touch = true;
                    if (NearestTarget.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;
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
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            touch = false;
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
