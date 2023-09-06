using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float HP = 200.0f;
    public int EnemyType = 0;

    private bool Right = true;
    private bool Left = false;
    private bool Down = false;
    private bool Up = false;
    private float MoveSpeed = 70.0f;

    //°ø°Ýenemy1_1
    public Transform target;
    //public Rigidbody2D Target;
    private float Enemy1_1CurShotDelay = 0.0f;
    private float Enemy1_2CurShotDelay = 0.0f;
    private float Enemy1_3CurShotDelay = 0.0f;
    public Transform ShotPos;
    Vector3 Targetvec;
    private SpriteRenderer spriteRenderer;
    //shopui
    public GameObject ShopUI;


    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        MoveSpeed = 70;
        //Target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.transform;
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (EnemyType == 1)
        {
            HP = 1000.0f;
        }
        if (EnemyType == 11)
        {
            HP = 200.0f;
        }
        if (EnemyType == 12)
        {
            HP = 200.0f;
        }
        if (EnemyType == 13)
        {
            HP = 200.0f;
        }

    }

    private void Update()
    {
        if (HP <= 0)
        {
            if(EnemyType == 1)
            {
                ShopManager.instance.ItemNumShuffle();
                GameManager.instance.IsPause();
                ShopUI.SetActive(true);
            }
            GameManager.instance.GetGold(1);
            GameManager.instance.GetEXP(1);
            gameObject.SetActive(false);
        }

        Targetvec = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
        if (EnemyType == 11)
        {
            Enemy1_1Attack();
            Enemy1_1CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 12)
        {
            Enemy1_2Attack();
            Enemy1_2CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 13)
        {
            Enemy1_3Attack();
            Enemy1_3CurShotDelay += Time.deltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        float Move = MoveSpeed * 0.05f;

        if (Right && Down || Left && Down || Left && Up || Right && Up)
        {
            Move -= 1.0f;
        }

        if (Right)
        {
            transform.position += new Vector3(Move, 0, 0) * Time.deltaTime;
            spriteRenderer.flipX = false;
        }

        if (Left)
        {
            transform.position += new Vector3(-Move, 0, 0) * Time.deltaTime;
            spriteRenderer.flipX = true;
        }

        if (Down)
        {
            transform.position += new Vector3(0, -Move, 0) * Time.deltaTime;
            spriteRenderer.flipX = true;
        }

        if (Up)
        {
            transform.position += new Vector3(0, Move, 0) * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
    }

    public  void TakeDamage(float Dmg)
    {
        HP -= Dmg;
    }

    public void Explosion(Transform pos)
    {
        GameObject Explosion = GameManager.instance.pool.Get(8);
        Explosion.transform.position = pos.transform.position;
    }
    private void Enemy1_1Attack()
    {
        if (Enemy1_1CurShotDelay >= 8.0f)
        {
            GameObject Enemy1_1Bullet = GameManager.instance.pool.Get(1);
            Enemy1_1Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1_1Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 5.0f, ForceMode2D.Impulse);
            Enemy1_1CurShotDelay = 0.0f;
        }
    }

    private void Enemy1_2Attack()
    {
        if (Enemy1_2CurShotDelay >= 8.0f)
        {
            MoveSpeed = 0.0f;
            Invoke("NormalSpeed", 2.0f);
            Vector3 Playervec = new Vector3(target.position.x, target.position.y, -10);
            Vector3 EnemyVec = new Vector3(transform.position.x, transform.position.y, -10);
            Vector3 len = Playervec - EnemyVec;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            GameObject Enemy1_2Bullet = GameManager.instance.pool.Get(3);
            Enemy1_2Bullet.transform.position = ShotPos.transform.position;
            Enemy1_2Bullet.transform.rotation = Quaternion.Euler(0, 0, z+270);
            Enemy1_2CurShotDelay = 0.0f;
        }
    }

    private void Enemy1_3Attack()
    {
        if (Enemy1_3CurShotDelay >= 8.0f)
        {
            GameObject Enemy1_3Bullet = GameManager.instance.pool.Get(5);
            Enemy1_3Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1_3Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 15.0f, ForceMode2D.Impulse);
            Enemy1_3CurShotDelay = 0.0f;
        }
    }

    public void MoveZero()
    {
        MoveSpeed = 0.0f;
        CancelInvoke();
        Invoke("NormalSpeed", 2.0f);
    }
    private void NormalSpeed()
    {
        MoveSpeed = 70.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RightGround")
        {
            Right = true;
        }

        if (collision.tag == "LeftGround")
        {
            Left = true;
        }

        if (collision.tag == "DownGround")
        {
            Down = true;
        }

        if (collision.tag == "UpGround")
        {
            Up = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "RightGround")
        {
            Right = false;
        }

        if (collision.tag == "LeftGround")
        {
            Left = false;
        }

        if (collision.tag == "DownGround")
        {
            Down = false;
        }

        if (collision.tag == "UpGround")
        {
            Up = false;
        }
    }
}
