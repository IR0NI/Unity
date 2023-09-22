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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.instance.HitBullet > 0.01f)
            if (GameManager.instance.Gun3Level >= 4)
                {
                    GameObject Glass = GameManager.instance.pool.Get(19);
                    Glass.transform.position = transform.position;
                    Glass.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 90);
                }
            switch (GameManager.instance.Gun2Level)
            {
                case 0:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD)*(GameManager.instance.BulletDmgUp+10)*0.1f);
                    touch = true;
                    if (collision.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;

                case 1:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD + 10.0f + Player.instance.AP * 0.3f) * (GameManager.instance.BulletDmgUp + 10) * 0.1f);
                    touch = true;
                    if (collision.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;

                case 2:
                    if(!touch)
                    collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD + 20.0f + Player.instance.AP * 0.7f) * (GameManager.instance.BulletDmgUp + 10) * 0.1f);
                    touch = true;
                    collision.GetComponent<Enemy>().MoveZero();
                    if (collision.GetComponent<Enemy>().HP >= 0)
                    {
                        Deactive();
                    }
                    break;

                case 3:
                    collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD + 20.0f + Player.instance.AP * 0.7f) * (GameManager.instance.BulletDmgUp + 10) * 0.1f);
                    collision.GetComponent<Enemy>().MoveZero();
                    break;

                default :
                    collision.GetComponent<Enemy>().TakeDamage((Player.instance.AD + 20.0f + Player.instance.AP * 0.7f) * (GameManager.instance.BulletDmgUp + 10) * 0.1f);
                    collision.GetComponent<Enemy>().MoveZero();
                    int ran = Random.Range(1, 6);
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
