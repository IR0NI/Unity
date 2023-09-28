using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float HP = 20.0f;
    public int EnemyType = 0;
    public float MoveSpeed = 70.0f;
    public float Diff = 100.0f;

    //°ø°ÝEnemy1
    public Transform target;
    private float Boss1CurShotDelay = 0.0f;
    private float Enemy1CurShotDelay = 0.0f;
    private float Enemy2CurShotDelay = 0.0f;
    private float Enemy3CurShotDelay = 0.0f;

    private float Enemy1MaxShotDelay = 3.0f;
    private float Enemy2MaxShotDelay = 5.0f;
    private float Enemy3MaxShotDelay = 3.0f;

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
    private Animator animator;
    private bool isAttack = false;


    private void OnEnable()
    {
        animator = GetComponent<Animator>();
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
            MoveSpeed = 100;
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
            HP = 20.0f;
        }
        if (EnemyType == 5)
        {
            HP = 20.0f;
        }
        if (EnemyType == 6)
        {
            HP = 20.0f;
        }
        if (EnemyType == 7)
        {
            HP = 20.0f;
        }

    }

    private void Update()
    {
        Diff = Vector3.Distance(transform.position, target.transform.position);
        if (HP <= 0)
        {
            CancelInvoke();
            gameObject.SetActive(false);
        }
        Targetvec = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0);
        EnemyAttackDelay();
    }

    private void FixedUpdate()
    {
        float Move = MoveSpeed * 0.05f;
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
        if (Enemy1CurShotDelay >= Enemy1MaxShotDelay && Diff < 3)
        {
            MoveZero();
            animator.SetBool("Enemy1Attack", true);
            Invoke("Enemy1realattack", 0.3f);
            Enemy1CurShotDelay = 0.0f;
        }
    }

    private void Enemy1realattack()
    {
        isAttack = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("Enemy1Idle", 0.2f);
    }

    private void Enemy1Idle()
    {
        isAttack = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Enemy1Attack", false);
    }

    private void Enemy2Attack()
    {
        
        if (Enemy2CurShotDelay >= Enemy2MaxShotDelay && Diff<20)
        {
            
            MoveZero();
            Invoke("Enemy2realattack", 1.0f);
            Enemy2CurShotDelay = 0.0f;
        }
    }

    private void Enemy2realattack()
    {
        GameObject Enemy2Bullet = GameManager.instance.pool.Get(12);
        Enemy2Bullet.transform.position = ShotPos.transform.position;
        Rigidbody2D Rigid = Enemy2Bullet.GetComponent<Rigidbody2D>();
        Rigid.AddForce(Targetvec.normalized * 25.0f, ForceMode2D.Impulse);
    }

    private void Enemy3Attack()
    {
        if (Enemy3CurShotDelay >= Enemy3MaxShotDelay && Diff < 2)
        {
            MoveZero();
            animator.SetBool("Enemy3Attack", true);
            Invoke("Enemy3realattack", 0.3f);
            Enemy3CurShotDelay = 0.0f;
        }
    }

    private void Enemy3realattack()
    {
        isAttack = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("Enemy3Idle", 0.2f);
    }

    private void Enemy3Idle()
    {
        isAttack = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Enemy3Attack", false);
    }

    private void Enemy4Attack()
    {
        if (Enemy4CurShotDelay >= Enemy4MaxShotDelay)
        {
            Enemy4CurShotDelay = 0.0f;
        }
    }

    private void Enemy5Attack()
    {
        if (Enemy5CurShotDelay >= Enemy5MaxShotDelay)
        {
            Enemy5CurShotDelay = 0.0f;
        }
    }

    private void Enemy6Attack()
    {
        if (Enemy6CurShotDelay >= Enemy6MaxShotDelay)
        {

            Enemy6CurShotDelay = 0.0f;

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
        if (isAttack)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<Player>().GetDamaged();
            }
        }
    }
}
