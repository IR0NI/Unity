using UnityEngine;

public class Enemy1_3SlowPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.moveSpeed = 50.0f;
            Player.instance.NormalSpeed = 50.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.moveSpeed = 100.0f;
            Player.instance.NormalSpeed = 100.0f;
        }
    }
}
