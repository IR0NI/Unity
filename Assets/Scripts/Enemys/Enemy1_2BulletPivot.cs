using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_2BulletPivot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject laser;
    private void OnEnable()
    {
        laser.SetActive(false);
        Bullet.SetActive(true);
        CancelInvoke();
        Invoke("DeActive", 3.5f);
        Invoke("Laser", 2.0f);
    }

    private void Update()
    {
        if (transform.GetComponentInParent<Enemy>().Elite == 100)
        {
            transform.Rotate(Vector3.back * 150.0f * Time.deltaTime);
        }
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
