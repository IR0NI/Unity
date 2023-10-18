using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutChurch : MonoBehaviour
{
    public GameObject church;
    public GameObject outchurch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            church.SetActive(true);
            outchurch.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            church.SetActive(true);
            outchurch.SetActive(false);
        }
    }
}
