using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float HP = 200.0f;
    public float AddHP = 0.0f;
    public int EnemyType = 0;

    private bool Right = false;
    private bool Left = false;
    private bool Down = false;
    private bool Up = false;
    public float MoveSpeed = 70.0f;

    //공격enemy1_1
    public Transform target;
    //public Rigidbody2D Target;
    private float Boss1CurShotDelay = 0.0f;
    private float Enemy1_1CurShotDelay = 0.0f;
    private float Enemy1_2CurShotDelay = 0.0f;
    private float Enemy1_3CurShotDelay = 0.0f;
    private float Enemy1_1MaxShotDelay = 35.0f;
    private float Enemy1_2MaxShotDelay = 15.0f;
    private float Enemy1_3MaxShotDelay = 10.0f;
    private float Randomtime = 0.0f;
    public Transform ShotPos;
    Vector3 Targetvec;
    private SpriteRenderer spriteRenderer;
    public GameObject Enemy1_2Bullet;
    GameObject Buff;
    public int Elite = 0;




    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        MoveSpeed = 70;
        target = GameManager.instance.player.transform;
        Randomtime = Random.Range(0, 30);
        AddHP = 50.0f * Mathf.Floor((GameManager.instance.kill) * 0.02f);
        HP = 150.0f + AddHP;


        if (EnemyType == 1)
        {
            HP += 850.0f;
        }

        if (EnemyType == 2)
        {
            HP += 4000.0f;
            return;
        }

        Elite = Random.Range(1, 31);
        if (GameManager.instance.isAllElite)
        {
            Elite = 1;
        }

        //엘리트오브엘리트
        //엘리트 번호는 100으로 통일
        if (EnemyType == 111)
        {
            Enemy1_1MaxShotDelay = 3.0f;
            Elite = 100;
            HP += 1050;
            MoveSpeed = 70.0f;
        }
        if (EnemyType == 112)
        {
            Elite = 100;
            HP += 1050;
        }
        if (EnemyType == 113)
        {
            Elite = 100;
            HP += 1050;
        }

        //엘리트
        if (Elite == 1)
        {

            Buff = GameManager.instance.pool.Get(14);
            //프리팹을 자식오브젝트로 생성
            Buff.transform.SetParent(gameObject.transform, false);

            if (EnemyType == 11)
            {
                Buff.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y - 0.6f, 0);
                Buff.transform.localScale = new Vector3(5, 5, 0);
                Enemy1_1MaxShotDelay = 3.0f;
                HP += 250.0f + AddHP;
                MoveSpeed = 70.0f;
            }
            if (EnemyType == 12)
            {
                Buff.transform.position = new Vector3(transform.position.x + 0.375f, transform.position.y, 0);
                Buff.transform.localScale = new Vector3(10, 10, 0);
                Enemy1_2MaxShotDelay = 8.0f;
                MoveSpeed = 110.0f;
                HP += 400.0f + AddHP;
                Enemy1_2CurShotDelay += Randomtime * 0.2f;
            }
            if (EnemyType == 13)
            {
                Buff.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                Buff.transform.localScale = new Vector3(3, 3, 0);
                HP += 400.0f + AddHP;
                Enemy1_3CurShotDelay += Randomtime * 0.2f;
            }
        }
        else
        {
            //일반몹
            if (EnemyType == 11)
            {
                MoveSpeed = 50.0f;
                Enemy1_1CurShotDelay += Randomtime;
            }
            if (EnemyType == 12)
            {
                HP += 50.0f;
                Enemy1_2CurShotDelay += Randomtime;
            }
            if (EnemyType == 13)
            {
                HP += 50.0f;
                Enemy1_3CurShotDelay += Randomtime;
            }
        }
        
    }

    private void Update()
    {
        if (HP <= 0)
        {
            if (EnemyType == 1)
            {
                GameObject Shop = GameManager.instance.pool.Get(11);
                Shop.transform.position = transform.position;
            }
            if (Elite == 1)
            {
                Buff.SetActive(false);
                GameManager.instance.KillEnemy(2);
            }else if (Elite == 100)
            {
                GameManager.instance.KillEnemy(2);
            }
            else
            {
                GameManager.instance.KillEnemy(1);
            }
            gameObject.SetActive(false);
        }

        Targetvec = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
        if (EnemyType == 11 || EnemyType == 111)
        {
            Enemy1_1Attack();
            Enemy1_1CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 12 || EnemyType == 112)
        {

            Enemy1_2Attack();
            Enemy1_2CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 13 || EnemyType == 113)
        {
            Enemy1_3Attack();
            Enemy1_3CurShotDelay += Time.deltaTime;
        }

        if (EnemyType == 2)
        {
            Boss1Attack();
            Boss1CurShotDelay += Time.deltaTime;
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

    public void TakeDamage(float Dmg)
    {
        GameManager.instance.HitBullet = 0.0f;
        GameObject hudText = GameManager.instance.pool.Get(12);
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
        GameObject Explosion = GameManager.instance.pool.Get(8);
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
    private void Enemy1_1Attack()
    {
        if (Enemy1_1CurShotDelay >= Enemy1_1MaxShotDelay)
        {
            GameObject Enemy1_1Bullet = GameManager.instance.pool.Get(1);
            Enemy1_1Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1_1Bullet.GetComponent<Rigidbody2D>();
            if (Elite == 1 || Elite == 100)
            {
                Vector3 Targetvec_3 = Quaternion.AngleAxis(3, new Vector3(0, 0, 1)) * Targetvec;
                Vector3 Targetvec__3 = Quaternion.AngleAxis(-3, new Vector3(0, 0, 1)) * Targetvec;
                GameObject Enemy1_1Bullet2 = GameManager.instance.pool.Get(1);
                Enemy1_1Bullet2.transform.position = ShotPos.transform.position;
                Rigidbody2D Rigid2 = Enemy1_1Bullet2.GetComponent<Rigidbody2D>();
                GameObject Enemy1_1Bullet3 = GameManager.instance.pool.Get(1);
                Enemy1_1Bullet3.transform.position = ShotPos.transform.position;
                Rigidbody2D Rigid3 = Enemy1_1Bullet3.GetComponent<Rigidbody2D>();
                Rigid.AddForce(Targetvec.normalized * 12.0f, ForceMode2D.Impulse);
                Rigid2.AddForce(Targetvec_3.normalized * 12.0f, ForceMode2D.Impulse);
                Rigid3.AddForce(Targetvec__3.normalized * 12.0f, ForceMode2D.Impulse);
                if(Elite == 100)
                {
                    Vector3 Targetvec_5 = Quaternion.AngleAxis(5, new Vector3(0, 0, 1)) * Targetvec;
                    Vector3 Targetvec__5 = Quaternion.AngleAxis(-5, new Vector3(0, 0, 1)) * Targetvec;
                    GameObject Enemy1_1Bullet4 = GameManager.instance.pool.Get(1);
                    Enemy1_1Bullet4.transform.position = ShotPos.transform.position;
                    GameObject Enemy1_1Bullet5 = GameManager.instance.pool.Get(1);
                    Enemy1_1Bullet5.transform.position = ShotPos.transform.position;
                    Rigidbody2D Rigid4 = Enemy1_1Bullet4.GetComponent<Rigidbody2D>();
                    Rigidbody2D Rigid5 = Enemy1_1Bullet5.GetComponent<Rigidbody2D>();
                    Rigid4.AddForce(Targetvec_5.normalized * 12.0f, ForceMode2D.Impulse);
                    Rigid5.AddForce(Targetvec__5.normalized * 12.0f, ForceMode2D.Impulse);
                    Enemy1_1Bullet.GetComponent<Enemy1_1Bullet>().EliteElite();
                    Enemy1_1Bullet2.GetComponent<Enemy1_1Bullet>().EliteElite();
                    Enemy1_1Bullet3.GetComponent<Enemy1_1Bullet>().EliteElite();
                    Enemy1_1Bullet4.GetComponent<Enemy1_1Bullet>().EliteElite();
                    Enemy1_1Bullet5.GetComponent<Enemy1_1Bullet>().EliteElite();
                }
            }
            else { Rigid.AddForce(Targetvec.normalized * 5.0f, ForceMode2D.Impulse); }

            Enemy1_1CurShotDelay = 0.0f;
        }
    }

    private void Enemy1_2Attack()
    {
        if (Enemy1_2CurShotDelay >= Enemy1_2MaxShotDelay)
        {
            MoveSpeed = 0.0f;
            Invoke("NormalSpeed", 3.0f);
            Vector3 Playervec = new Vector3(target.position.x, target.position.y, -10);
            Vector3 EnemyVec = new Vector3(transform.position.x, transform.position.y, -10);
            Vector3 len = Playervec - EnemyVec;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            Enemy1_2Bullet.SetActive(true);
            Enemy1_2Bullet.transform.position = ShotPos.transform.position;
            Enemy1_2Bullet.transform.rotation = Quaternion.Euler(0, 0, z + 90);
            Enemy1_2CurShotDelay = 0.0f;
        }
    }

    private void Enemy1_3Attack()
    {
        if (Enemy1_3CurShotDelay >= Enemy1_3MaxShotDelay)
        {
            GameObject Enemy1_3Bullet = GameManager.instance.pool.Get(5);
            Enemy1_3Bullet.transform.position = ShotPos.transform.position;
            Rigidbody2D Rigid = Enemy1_3Bullet.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Targetvec.normalized * 15.0f, ForceMode2D.Impulse);
            Enemy1_3Bullet.GetComponent<Enemy1_3Bullet>().EliteElite = true;
            if (Elite == 100)
            {
                Enemy1_3CurShotDelay = 4.0f;
            }
            else
            {
                Enemy1_3CurShotDelay = 0.0f;
            }

            if (Elite == 1)
            {
                Vector3 Targetvec_3 = Quaternion.AngleAxis(3, new Vector3(0, 0, 1)) * Targetvec;

                GameObject Enemy1_3Bullet2 = GameManager.instance.pool.Get(1);
                Enemy1_3Bullet2.transform.position = ShotPos.transform.position;
                Rigidbody2D Rigid2 = Enemy1_3Bullet2.GetComponent<Rigidbody2D>();

                Rigid2.AddForce(Targetvec_3.normalized * 12.0f, ForceMode2D.Impulse);
            }
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
        if (EnemyType == 11)
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
