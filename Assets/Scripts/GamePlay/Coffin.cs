using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("OpenCoffin", 600f);
    }

    private void OpenCoffin()
    {
        animator.SetBool("Open", true);
        Invoke("Deactive", 1.5f);
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }
}
