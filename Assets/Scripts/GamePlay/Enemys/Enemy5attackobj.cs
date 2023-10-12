using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5attackobj : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Deactive", 1.0f);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
