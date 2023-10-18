using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InChurch : MonoBehaviour
{
    public GameObject church;
    public GameObject outchurch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            church.SetActive(false);
            outchurch.SetActive(true);
        }
    }
}
