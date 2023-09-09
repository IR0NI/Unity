using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody2D rigid2D;
    private Vector3 moveDirectionX = Vector3.zero;
    private SpriteRenderer spriteRenderer;

    //플레이어 체력 UI
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;

    //플레이어 총알 시작위치
    public Transform GunLefthud;
    public Transform GunRighthud;
    public Transform Gun2Lefthud;
    public Transform Gun2Righthud;

    //총
    public Gun1 Gun1;
    public Gun2 Gun2;
    // 수리검 
    public GameObject KunaiPos1;
    public GameObject KunaiPos2;
    public GameObject KunaiPos3;
    public GameObject KunaiPos4;
    public GameObject KunaiPos5;
    public GameObject KunaiPos6;

    //애니메이터
    private Animator animator;

    public bool isDash = false;
    public bool isSlow = false;
    public bool isRevive = false;
    

    //캐릭터 스탯
    public float moveSpeed = 100.0f;
    public float NormalSpeed = 100.0f;
    private float DashSpeed = 200.0f;
    public float ChangeSpeed = 100.0f;
    public int MaxHP = 3;
    public int HP = 3;
    public float AD = 100.0f;
    public float AP = 0.0f;
    public float AS = 0.0f;

    //딜레이
    private float CurFireDelay = 0.0f;
    private float MaxFireDelay = 1.0f;
    private float CurDashDelay = 3.0f;
    private float MaxDashDelay = 3.0f;

    private Vector3 playervec;
    public Vector3 len;

    private int atknum = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Fire();
        Dash();
        Revive();
        if (HP <= 0)
        {
            //gameover
        }
    }

    private void FixedUpdate()
    {
        playervec = new Vector3(transform.position.x, transform.position.y, -10);
        len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playervec;
        Move();
        Reload();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirectionX = new Vector3(x, y, 0).normalized;
        transform.position += moveDirectionX * moveSpeed * 0.05f * Time.fixedDeltaTime;

        if (x != 0 || y != 0)
        {
            animator.SetBool("Walk", true);
        }
        if (x == 0 && y == 0)
        {
            animator.SetBool("Walk", false);
        }

        if (len.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (len.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Dash()
    {
        if (CurDashDelay >= MaxDashDelay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.layer = 9;
                NormalSpeed = moveSpeed;
                Invoke("ByeDash", 0.3f);
                isDash = true;
                CurDashDelay = 0.0f;
            }

            if (isDash)
            {
                moveSpeed = DashSpeed;
            }
        }
    }

    private void ByeDash()
    {
        gameObject.layer = 7;
        moveSpeed = NormalSpeed;
        isDash = false;
    }

    private void NormalLayer()
    {
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        Gun1.normal();
        if (GameManager.instance.Gun1Level == 4)
        {
            Gun2.normal();
        }
    }
    public void Revive()
    {
        if(GameManager.instance.ArmorLevel == 4 && isRevive == false)
        {
            isRevive = true;
            HP = 5;
            Heart();
        }
    }
    public void Heart()
    {
        if (MaxHP == 3)
        {
            if (HP == 3)
            {
                Heart3.SetActive(true);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 2)
            {
                Heart3.SetActive(false);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 1)
            {
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(true);
            }
            else
            {
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(false);
            }
        }else if(MaxHP == 4)
        {
            if( HP == 4)
            {
                Heart4.SetActive(true);
                Heart3.SetActive(true);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            if (HP == 3)
            {
                Heart4.SetActive(false);
                Heart3.SetActive(true);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 2)
            {
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 1)
            {
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(true);
            }
            else
            {
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(false);
            }
        }else if(MaxHP == 5)
        {
            if (HP == 4)
            {
                Heart5.SetActive(true);
                Heart4.SetActive(true);
                Heart3.SetActive(true);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            if (HP == 3)
            {
                Heart5.SetActive(false);
                Heart4.SetActive(false);
                Heart3.SetActive(true);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 2)
            {
                Heart5.SetActive(false);
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(true);
                Heart1.SetActive(true);
            }
            else if (HP == 1)
            {
                Heart5.SetActive(false);
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(true);
            }
            else
            {
                Heart5.SetActive(false);
                Heart4.SetActive(false);
                Heart3.SetActive(false);
                Heart2.SetActive(false);
                Heart1.SetActive(false);
            }
        }
    }

    private void Fire()
    {
     
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;

        Vector3 len_1 = Quaternion.AngleAxis(1, new Vector3(0, 0, 1)) * len;
        Vector3 len_2 = Quaternion.AngleAxis(2, new Vector3(0, 0, 1)) * len;
        Vector3 len_3 = Quaternion.AngleAxis(3, new Vector3(0, 0, 1)) * len;
        Vector3 len_4 = Quaternion.AngleAxis(4, new Vector3(0, 0, 1)) * len;
        Vector3 len__1 = Quaternion.AngleAxis(-1, new Vector3(0, 0, 1)) * len;
        Vector3 len__2 = Quaternion.AngleAxis(-2, new Vector3(0, 0, 1)) * len;
        Vector3 len__3 = Quaternion.AngleAxis(-3, new Vector3(0, 0, 1)) * len;
        Vector3 len__4 = Quaternion.AngleAxis(-4, new Vector3(0, 0, 1)) * len;

        if (CurFireDelay >= MaxFireDelay*100.0f/(100.0f + AS))
        {
            if (Input.GetMouseButton(0))
            {
                switch (GameManager.instance.Gun1Level)
                {
                    case 0:
                        GameObject Bul = GameManager.instance.pool.Get(7);
                        if (len.x > 0)
                        {
                            Bul.transform.position = GunRighthud.transform.position;
                        }
                        else
                        {
                            Bul.transform.position = GunLefthud.transform.position;
                        }
                        Bul.transform.rotation = Quaternion.Euler(0, 0, z);
                        Rigidbody2D rigid = Bul.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                        break;
                    case 1:
                        GameObject bul1_1 = GameManager.instance.pool.Get(7);
                        GameObject bul1_2 = GameManager.instance.pool.Get(7);

                        if (len.x > 0)
                        {
                            bul1_1.transform.position = GunRighthud.transform.position;
                            bul1_2.transform.position = GunRighthud.transform.position;
                        }
                        else
                        {
                            bul1_1.transform.position = GunLefthud.transform.position;
                            bul1_2.transform.position = GunLefthud.transform.position;
                        }
                        bul1_1.transform.rotation = Quaternion.Euler(0, 0, z - 2);
                        Rigidbody2D rigid1 = bul1_1.GetComponent<Rigidbody2D>();
                        rigid1.AddForce((len__2.normalized) * 15.0f, ForceMode2D.Impulse);
                        bul1_2.transform.rotation = Quaternion.Euler(0, 0, z + 2);
                        Rigidbody2D rigid2 = bul1_2.GetComponent<Rigidbody2D>();
                        rigid2.AddForce((len_2.normalized) * 15.0f, ForceMode2D.Impulse);
                        break;
                    case 2:
                        GameObject bul2_1 = GameManager.instance.pool.Get(7);
                        GameObject bul2_2 = GameManager.instance.pool.Get(7);
                        GameObject bul2_3 = GameManager.instance.pool.Get(7);

                        if (len.x > 0)
                        {
                            bul2_1.transform.position = GunRighthud.transform.position;
                            bul2_2.transform.position = GunRighthud.transform.position;
                            bul2_3.transform.position = GunRighthud.transform.position;
                        }
                        else
                        {
                            bul2_1.transform.position = GunLefthud.transform.position;
                            bul2_2.transform.position = GunLefthud.transform.position;
                            bul2_3.transform.position = GunLefthud.transform.position;
                        }

                        bul2_1.transform.rotation = Quaternion.Euler(0, 0, z - 2);
                        Rigidbody2D rigid2_1 = bul2_1.GetComponent<Rigidbody2D>();
                        rigid2_1.AddForce((len__2.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul2_2.transform.rotation = Quaternion.Euler(0, 0, z);
                        Rigidbody2D rigid2_2 = bul2_2.GetComponent<Rigidbody2D>();
                        rigid2_2.AddForce((len.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul2_3.transform.rotation = Quaternion.Euler(0, 0, z + 2);
                        Rigidbody2D rigid2_3 = bul2_3.GetComponent<Rigidbody2D>();
                        rigid2_3.AddForce((len_2.normalized) * 15.0f, ForceMode2D.Impulse);
                        break;
                    case 3:
                        GameObject bul3_1 = GameManager.instance.pool.Get(7);
                        GameObject bul3_2 = GameManager.instance.pool.Get(7);
                        GameObject bul3_3 = GameManager.instance.pool.Get(7);
                        GameObject bul3_4 = GameManager.instance.pool.Get(7);

                        if (len.x > 0)
                        {
                            bul3_1.transform.position = GunRighthud.transform.position;
                            bul3_2.transform.position = GunRighthud.transform.position;
                            bul3_3.transform.position = GunRighthud.transform.position;
                            bul3_4.transform.position = GunRighthud.transform.position;
                        }
                        else
                        {
                            bul3_1.transform.position = GunLefthud.transform.position;
                            bul3_2.transform.position = GunLefthud.transform.position;
                            bul3_3.transform.position = GunLefthud.transform.position;
                            bul3_4.transform.position = GunLefthud.transform.position;
                        }

                        bul3_1.transform.rotation = Quaternion.Euler(0, 0, z + 3);
                        Rigidbody2D rigid3_1 = bul3_1.GetComponent<Rigidbody2D>();
                        rigid3_1.AddForce((len_3.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul3_2.transform.rotation = Quaternion.Euler(0, 0, z + 1);
                        Rigidbody2D rigid3_2 = bul3_2.GetComponent<Rigidbody2D>();
                        rigid3_2.AddForce((len_1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul3_3.transform.rotation = Quaternion.Euler(0, 0, z - 1);
                        Rigidbody2D rigid3_3 = bul3_3.GetComponent<Rigidbody2D>();
                        rigid3_3.AddForce((len__1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul3_4.transform.rotation = Quaternion.Euler(0, 0, z - 3);
                        Rigidbody2D rigid3_4 = bul3_4.GetComponent<Rigidbody2D>();
                        rigid3_4.AddForce((len__3.normalized) * 15.0f, ForceMode2D.Impulse);
                        break;
                    case 4:
                        GameObject bul4_1 = GameManager.instance.pool.Get(7);
                        GameObject bul4_2 = GameManager.instance.pool.Get(7);
                        GameObject bul4_3 = GameManager.instance.pool.Get(7);
                        GameObject bul4_4 = GameManager.instance.pool.Get(7);
                        GameObject bul4_5 = GameManager.instance.pool.Get(7);
                        GameObject bul4_6 = GameManager.instance.pool.Get(7);
                        GameObject bul4_7 = GameManager.instance.pool.Get(7);
                        GameObject bul4_8 = GameManager.instance.pool.Get(7);

                        if (len.x > 0)
                        {
                            bul4_1.transform.position = GunRighthud.transform.position;
                            bul4_2.transform.position = GunRighthud.transform.position;
                            bul4_3.transform.position = GunRighthud.transform.position;
                            bul4_4.transform.position = GunRighthud.transform.position;
                            bul4_5.transform.position = Gun2Righthud.transform.position;
                            bul4_6.transform.position = Gun2Righthud.transform.position;
                            bul4_7.transform.position = Gun2Righthud.transform.position;
                            bul4_8.transform.position = Gun2Righthud.transform.position;
                        }
                        else
                        {
                            bul4_1.transform.position = GunLefthud.transform.position;
                            bul4_2.transform.position = GunLefthud.transform.position;
                            bul4_3.transform.position = GunLefthud.transform.position;
                            bul4_4.transform.position = GunLefthud.transform.position;
                            bul4_5.transform.position = Gun2Lefthud.transform.position;
                            bul4_6.transform.position = Gun2Lefthud.transform.position;
                            bul4_7.transform.position = Gun2Lefthud.transform.position;
                            bul4_8.transform.position = Gun2Lefthud.transform.position;
                        }

                        bul4_1.transform.rotation = Quaternion.Euler(0, 0, z + 3);
                        Rigidbody2D rigid4_1 = bul4_1.GetComponent<Rigidbody2D>();
                        rigid4_1.AddForce((len_3.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_2.transform.rotation = Quaternion.Euler(0, 0, z + 1);
                        Rigidbody2D rigid4_2 = bul4_2.GetComponent<Rigidbody2D>();
                        rigid4_2.AddForce((len_1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_3.transform.rotation = Quaternion.Euler(0, 0, z - 1);
                        Rigidbody2D rigid4_3 = bul4_3.GetComponent<Rigidbody2D>();
                        rigid4_3.AddForce((len__1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_4.transform.rotation = Quaternion.Euler(0, 0, z - 3);
                        Rigidbody2D rigid4_4 = bul4_4.GetComponent<Rigidbody2D>();
                        rigid4_4.AddForce((len__3.normalized) * 15.0f, ForceMode2D.Impulse);
                       
                        bul4_5.transform.rotation = Quaternion.Euler(0, 0, z + 3);
                        Rigidbody2D rigid4_5 = bul4_5.GetComponent<Rigidbody2D>();
                        rigid4_5.AddForce((len_3.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_6.transform.rotation = Quaternion.Euler(0, 0, z + 1);
                        Rigidbody2D rigid4_6 = bul4_6.GetComponent<Rigidbody2D>();
                        rigid4_6.AddForce((len_1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_7.transform.rotation = Quaternion.Euler(0, 0, z - 1);
                        Rigidbody2D rigid4_7 = bul4_7.GetComponent<Rigidbody2D>();
                        rigid4_7.AddForce((len__1.normalized) * 15.0f, ForceMode2D.Impulse);

                        bul4_8.transform.rotation = Quaternion.Euler(0, 0, z - 3);
                        Rigidbody2D rigid4_8 = bul4_8.GetComponent<Rigidbody2D>();
                        rigid4_8.AddForce((len__3.normalized) * 15.0f, ForceMode2D.Impulse);

                        Gun2.Shot();
                        Gun2.Idle();

                        break;

                }
                
                CurFireDelay = 0.0f;
                Gun1.Shot();
                Gun1.Shot();
                if (GameManager.instance.KunaiLevel >= 1)
                {
                    if (GameManager.instance.KunaiLevel >= 1)
                    {
                        GameObject Kunai1 = GameManager.instance.pool.Get(16);
                        Kunai1.transform.position = KunaiPos1.transform.position;
                        Kunai1.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid = Kunai1.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                    }
                    if (GameManager.instance.KunaiLevel >= 2)
                    {
                        GameObject Kunai2 = GameManager.instance.pool.Get(16);
                        Kunai2.transform.position = KunaiPos2.transform.position;
                        Kunai2.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid = Kunai2.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                    }
                    if (GameManager.instance.KunaiLevel >= 3)
                    {
                        atknum += 1;
                        GameObject[] kunai = new GameObject[12];
                        Rigidbody2D[] rigid = new Rigidbody2D[12];
                        Vector3[] len = new Vector3[12];
                        len[0] = new Vector3(0,2,0);
                        len[1] = new Vector3(1,Mathf.Sqrt(3),0);
                        len[2] = new Vector3(Mathf.Sqrt(3),1,0);
                        len[3] = new Vector3(2,0,0);
                        len[4] = new Vector3(Mathf.Sqrt(3),-1,0);
                        len[5] = new Vector3(1,-Mathf.Sqrt(3), 0);
                        len[6] = new Vector3(0,-2,0);
                        len[7] = new Vector3(-1,-Mathf.Sqrt(3), 0);
                        len[8] = new Vector3(-Mathf.Sqrt(3),-1,0);
                        len[9] = new Vector3(-2,0,0);
                        len[10] = new Vector3(-Mathf.Sqrt(3),1,0);
                        len[11] = new Vector3(-1, Mathf.Sqrt(3), 0);
                        if (atknum == 5)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                kunai[i] = GameManager.instance.pool.Get(16);
                                kunai[i].transform.position = transform.position;
                                kunai[i].transform.rotation = Quaternion.Euler(0, 0, -30 * i);
                                rigid[i] = kunai[i].GetComponent<Rigidbody2D>();
                                rigid[i].AddForce(len[i].normalized * 15.0f, ForceMode2D.Impulse);
                            }
                            atknum = 0;
                        }

                    }
                    if (GameManager.instance.KunaiLevel == 4)
                    {
                        GameObject Kunai3 = GameManager.instance.pool.Get(16);
                        Kunai3.transform.position = KunaiPos3.transform.position;
                        Kunai3.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid3 = Kunai3.GetComponent<Rigidbody2D>();
                        rigid3.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                        GameObject Kunai4 = GameManager.instance.pool.Get(16);
                        Kunai4.transform.position = KunaiPos4.transform.position;
                        Kunai4.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid4 = Kunai4.GetComponent<Rigidbody2D>();
                        rigid4.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                        GameObject Kunai5 = GameManager.instance.pool.Get(16);
                        Kunai5.transform.position = KunaiPos5.transform.position;
                        Kunai5.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid5 = Kunai5.GetComponent<Rigidbody2D>();
                        rigid5.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                        GameObject Kunai6 = GameManager.instance.pool.Get(16);
                        Kunai6.transform.position = KunaiPos6.transform.position;
                        Kunai6.transform.rotation = Quaternion.Euler(0, 0, z + 270.0f);
                        Rigidbody2D rigid6 = Kunai6.GetComponent<Rigidbody2D>();
                        rigid6.AddForce(len.normalized * 15.0f, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttack")
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            Gun1.transparency();
            if (GameManager.instance.Gun1Level == 4)
            {
                Gun2.transparency();
            }
            gameObject.layer = 9;
            Invoke("NormalLayer", 1.0f);
            HP -= 1;
            Heart();
        }
    }

    private void Reload()
    {
        CurFireDelay += Time.deltaTime;
        CurDashDelay += Time.deltaTime;
    }
}
