using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;

    void FixedUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, -10);
        transform.position = pos;
    }

}
