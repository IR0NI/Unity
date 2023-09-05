using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    public float ScanRange;
    public LayerMask TargetLayer;
    public RaycastHit2D[] Targets;
    public Transform NearestTarget;

    private void FixedUpdate()
    {
        Targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, TargetLayer);
        NearestTarget = GetNearest();
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
