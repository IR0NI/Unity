using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_2BulletPivot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject laser;
    private void OnEnable()
    {
        Bullet.SetActive(true);
        Invoke("DeActive", 3.5f);
        Invoke("Laser", 2.0f);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

    private void Laser()
    {
        laser.SetActive(true);
    }
}
