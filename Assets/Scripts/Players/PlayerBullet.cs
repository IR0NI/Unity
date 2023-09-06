using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    /*public float distance;
    public LayerMask isLayer;*/
    //평범한총알하나가 여러명 때리는거 방지
    public bool touch = false;
    private void OnEnable()
    {
        touch = false;
        CancelInvoke();
        Invoke("Deactive", 1.5f);

    }
    /*private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "Enemy")
            {
                switch (GameManager.instance.Gun2Level)
                {
                    case 0:
                        ray.collider.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
                        Deactive();
                        break;

                    case 1:
                        Deactive();
                        break;

                    case 2:
                        Deactive();
                        break;

                    default:
                        break;
                }
            }
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            switch (GameManager.instance.Gun2Level)
            {
                case 0:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD);
                    touch = true;
                    if (collision.GetComponent<Enemy>().HP >= 0 )
                    {
                        Deactive();
                    }
                    break;

                case 1:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 100.0f + Player.instance.AP * 1.0f);
                    touch = true;
                    if (collision.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;

                case 2:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    touch = true;
                    collision.GetComponent<Enemy>().MoveZero();
                    if (collision.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;

                case 3:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    collision.GetComponent<Enemy>().MoveZero();
                    break;

                case 4:
                    collision.GetComponent<Enemy>().TakeDamage(Player.instance.AD + 200.0f + Player.instance.AP * 1.5f);
                    collision.GetComponent<Enemy>().MoveZero();
                    int ran = Random.Range(1, 2);
                    if(ran == 1)
                    {
                        collision.GetComponent<Enemy>().Explosion(this.transform);
                    }
                    break;
            }
        }
    }
    
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
