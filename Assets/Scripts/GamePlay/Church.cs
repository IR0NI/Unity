using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church : MonoBehaviour
{
    public GameObject church;
    public GameObject outchurch;
    public GameObject dark;
    public GameObject tree;
    public GameObject darkground;
    public GameObject grass;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            church.SetActive(false);
            outchurch.SetActive(true);
            dark.SetActive(false);
            tree.SetActive(false);
            darkground.SetActive(true);
            grass.SetActive(false);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            church.SetActive(true);
            outchurch.SetActive(false);
            dark.SetActive(true);
            tree.SetActive(true);
            darkground.SetActive(false);
            grass.SetActive(true);
            
        }
    }
}
