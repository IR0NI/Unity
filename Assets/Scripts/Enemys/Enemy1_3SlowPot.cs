using UnityEngine;

public class Enemy1_3SlowPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Player.instance.isSlow)
        {
            Player.instance.isSlow = true;
            Player.instance.moveSpeed = Player.instance.ChangeSpeed -50;
            Player.instance.NormalSpeed = Player.instance.ChangeSpeed - 50;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Player.instance.isSlow)
        {
            Player.instance.isSlow = false;
            Player.instance.moveSpeed = Player.instance.ChangeSpeed;
            Player.instance.NormalSpeed = Player.instance.ChangeSpeed;
        }
    }
}
