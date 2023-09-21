using UnityEngine;

public class PlayerKnife : MonoBehaviour
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
        Invoke("Deactive", 4.0f);
    }

    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
        if (Targets.Length >= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, NearestTarget.transform.position, 10.0f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!touch)
            {
                touch = true;
                collision.GetComponent<Enemy>().TakeDamage((20 + Player.instance.AP)*(GameManager.instance.KnifeDmgUp+10)*0.1f);
                Deactive();
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }

    Transform GetNearest()
    {
        Transform result = null;
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
                result = target.transform;
                i += 1;
            }
        }

        return result;
    }
}
