using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float HP = 20.0f;
    public int EnemyType = 0;

    private bool Right = false;
    private bool Left = false;
    private bool Down = false;
    private bool Up = false;
    public float MoveSpeed = 70.0f;

    //°ø°ÝEnemy1
    public Transform target;
    private float Boss1CurShotDelay = 0.0f;
    private float Enemy1CurShotDelay = 0.0f;
    private float Enemy2CurShotDelay = 0.0f;
    private float Enemy3CurShotDelay = 0.0f;

    private float Enemy1MaxShotDelay = 40.0f;
    private float Enemy2MaxShotDelay = 15.0f;
    private float Enemy3MaxShotDelay = 10.0f;

    private float Enemy4CurShotDelay = 0.0f;
    private float Enemy5CurShotDelay = 0.0f;
    private float Enemy6CurShotDelay = 0.0f;

    private float Enemy4MaxShotDelay = 40.0f;
    private float Enemy5MaxShotDelay = 5.0f;
    private float Enemy6MaxShotDelay = 10.0f;

    public Transform ShotPos;
    Vector3 Targetvec;
    private SpriteRenderer spriteRenderer;
    public GameObject Enemy2Bullet;




    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        MoveSpeed = 70;
        target = GameManager.instance.player.transform;
        HP = 15.0f;

        if (EnemyType == 100)
        {
            HP = 10000.0f;
            return;
        }

        if (EnemyType == 1)
        {
            MoveSpeed = 50.0f;
        }
        if (EnemyType == 2)
        {
            HP += 5.0f;
        }
        if (EnemyType == 3)
        {
            HP += 5.0f;
        }
        if (EnemyType == 4)
        {
            HP = 20.0f ;
        }
        if (EnemyType == 5)
        {
            HP = 20.0f ;
        }
        if (EnemyType == 6)
        {
            HP = 20.0f ;
        }
        if (EnemyType == 7)
        {
            HP = 20.0f ;
        }

    }

    private void Update()
    {
        if (HP <= 0)
        {
            GameManager.instance.KillEnemy(1);
            gameObject.SetActive(false);
        }
        Targetvec = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
        EnemyAttackDelay();
    }

    private void FixedUpdate()
    {
        float Move = MoveSpeed * 0.05f;
        if (EnemyType != 7)
        {
            if (Right && Down || Left && Down || Left && Up || Right && Up)
            {
                Move -= 1.0f;
                if (MoveSpeed == 0)
                {
                    Move = 0.0f;
                }
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
        else if (EnemyType == 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * 0.05f * Time.fixedDeltaTime);
            if (target.transform.position.x - transform.position.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (target.transform.position.x - transform.position.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    void EnemyAttackDelay()
    {
        if (EnemyType == 1)
        {
            Enemy1Attack();
            Enemy1CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 2)
        {

            Enemy2Attack();
            Enemy2CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 3)
        {
            Enemy3Attack();
            Enemy3CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 100)
        {
            Boss1Attack();
            Boss1CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 4)
        {
            Enemy4Attack();
            Enemy4CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 5)
        {

            Enemy5Attack();
            Enemy5CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 6)
        {
            Enemy6Attack();
            Enemy6CurShotDelay += Time.deltaTime;
        }
    }
    public void TakeDamage(float Dmg)
    {
        GameManager.instance.HitBullet = 0.0f;
        GameObject hudText = GameManager.instance.pool.Get(0);
        float ran = Random.Range(-0.25f, 0.25f);
        hudText.transform.position = new Vector3(transform.position.x + ran, transform.position.y + ran, 0);
        hudText.GetComponent<DamagedText>().damage = Mathf.Floor(Dmg);
        if (HP > Dmg)
        {
            HP -= Dmg;
        }
        else if (HP <= Dmg)
        {

            HP = 0.0f;
        }
    }

    public void Explosion(Transform pos)
    {
        GameObject Explosion = GameManager.instance.pool.Get(2);
        Explosion.transform.position = pos.transform.position;
    }

    private void Boss1Attack()
    {
        if (Boss1CurShotDelay >= 0.5f)
        {
            GameObject BossBul1 = GameManager.instance.pool.Get(1);
            GameObject BossBul2 = GameManager.instance.pool.Get(1);
            GameObject BossBul3 = GameManager.instance.pool.Get(1);
            GameObject BossBul4 = GameManager.instance.pool.Get(1);
            GameObject BossBul5 = GameManager.instance.pool.Get(1);
            GameObject BossBul6 = GameManager.instance.pool.Get(1);
            GameObject BossBul7 = GameManager.instance.pool.Get(1);
            GameObject BossBul8 = GameManager.instance.pool.Get(1);
            GameObject BossBul9 = GameManager.instance.pool.Get(1);
            GameObject BossBul10 = GameManager.instance.pool.Get(1);
            GameObject BossBul11 = GameManager.instance.pool.Get(1);
            GameObject BossBul12 = GameManager.instance.pool.Get(1);
            BossBul1.transform.position = ShotPos.transform.position;
            BossBul2.transform.position = ShotPos.transform.position;
            BossBul3.transform.position = ShotPos.transform.position;
            BossBul4.transform.position = ShotPos.transform.position;
            BossBul5.transform.position = ShotPos.transform.position;
            BossBul6.transform.position = ShotPos.transform.position;
            BossBul7.transform.position = ShotPos.transform.position;
            BossBul8.transform.position = ShotPos.transform.position;
            BossBul9.transform.position = ShotPos.transform.position;
            BossBul10.transform.position = ShotPos.transform.position;
            BossBul11.transform.position = ShotPos.transform.position;
            BossBul12.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid1 = BossBul1.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid2 = BossBul2.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid3 = BossBul3.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid4 = BossBul4.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid5 = BossBul5.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid6 = BossBul6.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid7 = BossBul7.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid8 = BossBul8.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid9 = BossBul9.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid10 = BossBul10.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid11 = BossBul11.GetComponent<Rigidbody2D>();
            Rigidbody2D Rigid12 = BossBul12.GetComponent<Rigidbody2D>();
            Rigid1.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            Rigid2.AddForce(Vector2.right * 7, ForceMode2D.Impulse);
            Rigid3.AddForce(Vector2.down * 7, ForceMode2D.Impulse);
            Rigid4.AddForce(Vector2.left * 7, ForceMode2D.Impulse);
            Rigid5.AddForce((Vector2.right + Vector2.right + Vector2.up).normalized * 7, ForceMode2D.Impulse);
            Rigid6.AddForce((Vector2.right + Vector2.right + Vector2.down).normalized * 7, ForceMode2D.Impulse);
            Rigid7.AddForce((Vector2.left + Vector2.left + Vector2.down).normalized * 7, ForceMode2D.Impulse);
            Rigid8.AddForce((Vector2.left + Vector2.left + Vector2.up).normalized * 7, ForceMode2D.Impulse);
            Rigid9.AddForce((Vector2.right + Vector2.up + Vector2.up).normalized * 7, ForceMode2D.Impulse);
            Rigid10.AddForce((Vector2.right + Vector2.down + Vector2.down).normalized * 7, ForceMode2D.Impulse);
            Rigid11.AddForce((Vector2.left + Vector2.down + Vector2.down).normalized * 7, ForceMode2D.Impulse);
            Rigid12.AddForce((Vector2.left + Vector2.down + Vector2.down).normalized * 7, ForceMode2D.Impulse);
            Boss1CurShotDelay = 0.0f;
        }
    }
    private void Enemy1Attack()
    {
        if (Enemy1CurShotDelay >= Enemy1MaxShotDelay)
        {
            GameObject Enemy1Bullet = GameManager.instance.pool.Get(10);
            Enemy1Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 5.0f, ForceMode2D.Impulse);
            Enemy1CurShotDelay = 0.0f;
        }
    }

    private void Enemy2Attack()
    {
        if (Enemy2CurShotDelay >= Enemy2MaxShotDelay)
        {
            MoveSpeed = 0.0f;
            CancelInvoke();
            Invoke("NormalSpeed", 3.0f);
            Vector3 Playervec = new Vector3(target.position.x, target.position.y, -10);
            Vector3 EnemyVec = new Vector3(transform.position.x, transform.position.y, -10);
            Vector3 len = Playervec - EnemyVec;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;

            Enemy2Bullet.transform.position = ShotPos.transform.position;
            Enemy2Bullet.transform.rotation = Quaternion.Euler(0, 0, z + 90);
            Enemy2Bullet.SetActive(true);
            Enemy2CurShotDelay = 0.0f;
        }
    }

    private void Enemy3Attack()
    {
        if (Enemy3CurShotDelay >= Enemy3MaxShotDelay)
        {
            GameObject Enemy3Bullet = GameManager.instance.pool.Get(14);
            Enemy3Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy3Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 15.0f, ForceMode2D.Impulse);
            Enemy3CurShotDelay = 0.0f;
        }
    }

    private void Enemy4Attack()
    {
        if (Enemy4CurShotDelay >= Enemy4MaxShotDelay)
        {
            GameObject Enemy1Bullet = GameManager.instance.pool.Get(10);
            Enemy1Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 5.0f, ForceMode2D.Impulse);

            Enemy4CurShotDelay = 0.0f;
        }
    }

    private void Enemy5Attack()
    {
        if (Enemy5CurShotDelay >= Enemy5MaxShotDelay)
        {
            GameObject Enemy2_4Summon = GameManager.instance.pool.Get(20);
            Enemy2_4Summon.transform.position = ShotPos.transform.position;
            Enemy5CurShotDelay = 0.0f;
        }
    }

    private void Enemy6Attack()
    {
        if (Enemy6CurShotDelay >= Enemy6MaxShotDelay)
        {
            GameObject Enemy6Bullet = GameManager.instance.pool.Get(10);
            Enemy6Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy6Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 15.0f, ForceMode2D.Impulse);
            Enemy6CurShotDelay = 0.0f;

        }
    }

    public void MoveZero()
    {
        if (EnemyType > 10)
        {
            MoveSpeed = 0.0f;
            CancelInvoke();
            Invoke("NormalSpeed", 2.0f);
        }
    }
    private void NormalSpeed()
    {
        MoveSpeed = 70.0f;
        if (EnemyType == 1)
        {
            MoveSpeed = 50.0f;
        }
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
