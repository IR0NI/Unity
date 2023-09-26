using UnityEngine;

public class Enemy1_3SlowPot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {

            Player.instance.SlowStacks += 1;
            if (Player.instance.SlowStacks == 1)
            {
                Player.instance.moveSpeed = Player.instance.ChangeSpeed - 50;
                Player.instance.NormalSpeed = Player.instance.ChangeSpeed - 50;
            }
        }
    }

    public void Update()
    {
            transform.localScale = new Vector3(6, 4, 0);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.SlowStacks -= 1;
            if (Player.instance.SlowStacks == 0)
            {
                Player.instance.moveSpeed = Player.instance.ChangeSpeed;
                Player.instance.NormalSpeed = Player.instance.ChangeSpeed;
            }
        }
    }
}
