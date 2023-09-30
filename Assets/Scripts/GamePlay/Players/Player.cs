using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody2D rigid2D;
    private Vector3 moveDirectionX = Vector3.zero;
    private SpriteRenderer spriteRenderer;

    //재장전시간
    public GameObject BulletReloadTime;
    public GameObject ReloadTime;
    public GameObject Reloadstartline;
    public GameObject Reloadendline;

    //플레이어 체력 UI
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject Heart6;

    //플레이어 총알 시작위치
    //권총
    public Transform PistolLefthud;
    public Transform PistolRighthud;
    //샷견
    public Transform ShotgunLefthud;
    public Transform ShotgunRighthud;
    //우지
    public Transform UziLefthud;
    public Transform UziRighthud;
    //총
    public PlayerPistol pistol;
    public PlayerShotgun shotgun;
    public PlayerUzi uzi;
    public GameObject Pistolobj;
    public GameObject Shotgunobj;
    public GameObject Uziobj;

    //애니메이터
    private Animator animator;

    public bool isDash = false;
    public bool isRevive = false;
    public bool isDmg = false;
    public bool isReload = false;
    

    //캐릭터 스탯
    public float moveSpeed = 100.0f;
    public float NormalSpeed = 100.0f;
    private float DashSpeed = 200.0f;
    public float ChangeSpeed = 100.0f;
    public int MaxHP = 3;
    public int HP = 3;
    public float BaseAD = 10.0f;
    public float AD = 10.0f;
    public float AS = 0.0f;
    public int magazine = 12;
    public int maxmagazine = 12;
    public int BulletNum = 1;
    public float BulletTime = 1.0f;
    public float BulletSpeed = 30.0f;
    public int Bulletpeneration = 1;
    public int SlowStacks = 0;

    //딜레이
    private float CurFireDelay = 5.0f;
    public float MaxFireDelay = 1.0f;
    public float CurDashDelay = 3.0f;
    private float MaxDashDelay = 3.0f;
    private float CurMineDelay = 5.0f;
    public Vector3 playervec;
    public Vector3 len;

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
        switch (GameReadyManager.instance.GunNum)
        {
            case 1:
                Pistolobj.SetActive(true);
                magazine = 12;
                maxmagazine = 12;
                break;
            case 2:
                Shotgunobj.SetActive(true);
                AS -= 50.0f;
                BulletNum = 4;
                BulletTime = 0.5f;
                BulletSpeed = 25.0f;
                magazine = 6;
                maxmagazine = 6;
                break;
            case 3:
                Uziobj.SetActive(true);
                AS += 400.0f;
                BaseAD = 2;
                AD = 2;
                magazine = 50;
                maxmagazine = 50;
                break;
        }
        GameManager.instance.Bulletupdate();
        
    }

    private void Update()
    {
        Fire();
        Dash();
        if (HP <= 0)
        {
            GameManager.instance.GameOver();
        }
        if (Input.GetKeyDown(KeyCode.R) && magazine < maxmagazine)
        {
            GunReload();
        }
        if (GameManager.instance.SecondWepon3)
        {
            CurMineDelay += Time.deltaTime;
            InstallMine();
        }
    }

    private void FixedUpdate()
    {
        playervec = new Vector3(transform.position.x, transform.position.y, -10);
        len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playervec;
        Move();
        Reload();
        if (isReload)
        {
            ReloadTime.transform.position = Vector2.MoveTowards(ReloadTime.transform.position, Reloadendline.transform.position, 50.0f * Time.fixedDeltaTime);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirectionX = new Vector3(x, y, 0).normalized;
        transform.position += moveDirectionX * moveSpeed * 0.05f * Time.fixedDeltaTime;

        if (x != 0 || y != 0)
        {
            if (isDmg)
            {
                animator.SetBool("Takedamage", false);
            }
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
                gameObject.layer = 12;
                NormalSpeed = moveSpeed;
                Invoke("ByeDash", 0.5f);
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

    public void Heart()
    {
        switch (MaxHP)
        {
            case 3:
                switch (HP)
                {
                    case 3:
                        Heart3.SetActive(true);
                        break;
                    case 2:
                        Heart3.SetActive(false);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 1:
                        Heart2.SetActive(false);
                        Heart1.SetActive(true);
                        break;
                    case 0:
                        Heart1.SetActive(false);
                        break;
                }
                break;
            case 4:
                switch (HP)
                {
                    case 4:
                        Heart4.SetActive(true);
                        break;
                    case 3:
                        Heart4.SetActive(false);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 2:
                        Heart3.SetActive(false);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 1:
                        Heart2.SetActive(false);
                        Heart1.SetActive(true);
                        break;
                    case 0:
                        Heart1.SetActive(false);
                        break;
                }
                break;
            case 5:
                switch (HP)
                {
                    case 5:
                        Heart5.SetActive(true);
                        break;
                    case 4:
                        Heart5.SetActive(false);
                        Heart4.SetActive(true);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 3:
                        Heart4.SetActive(false);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 2:
                        Heart3.SetActive(false);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 1:
                        Heart2.SetActive(false);
                        Heart1.SetActive(true);
                        break;
                    case 0:
                        Heart1.SetActive(false);
                        break;
                }
                break;
            case 6:
                switch (HP)
                {
                    case 6:
                        Heart6.SetActive(true);
                        break;
                    case 5:
                        Heart6.SetActive(false);
                        Heart5.SetActive(true);
                        Heart4.SetActive(true);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 4:
                        Heart5.SetActive(false);
                        Heart4.SetActive(true);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 3:
                        Heart4.SetActive(false);
                        Heart3.SetActive(true);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 2:
                        Heart3.SetActive(false);
                        Heart2.SetActive(true);
                        Heart1.SetActive(true);
                        break;
                    case 1:
                        Heart2.SetActive(false);
                        Heart1.SetActive(true);
                        break;
                    case 0:
                        Heart1.SetActive(false);
                        break;
                }
                break;
        }
    }

    private void Emptycartridge()
    {
        GameObject emptycartridge1 = null;
        GameObject emptycartridge2 = null;
        GameObject emptycartridge3 = null;
        GameObject emptycartridge4 = null;
        GameObject emptycartridge5 = null;
        GameObject emptycartridge6 = null;
        GameObject[] emptycartridge = { emptycartridge1, emptycartridge2, emptycartridge3, emptycartridge4, emptycartridge5, emptycartridge6 };
        for (int i = 0; i < Random.Range(3, 7); i++)
        {
            emptycartridge[i] = GameManager.instance.pool.Get(2);
            Rigidbody2D rigid = emptycartridge[i].GetComponent<Rigidbody2D>();
            emptycartridge[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            if (len.x > 0)
            {
                switch (GameReadyManager.instance.GunNum)
                {
                    case 1:
                        emptycartridge[i].transform.position = new Vector3(PistolRighthud.transform.position.x - 0.3f, PistolRighthud.transform.position.y, 0);
                        break;
                    case 2:
                        emptycartridge[i].transform.position = new Vector3(ShotgunRighthud.transform.position.x - 0.3f, ShotgunRighthud.transform.position.y, 0);
                        break;
                    case 3:
                        emptycartridge[i].transform.position = new Vector3(UziRighthud.transform.position.x - 0.3f, UziRighthud.transform.position.y, 0);
                        break;
                }
                rigid.AddForce(Vector2.left * Random.Range(1.0f, 4.0f) + Vector2.down * Random.Range(1.0f, 3.0f), ForceMode2D.Impulse);
            }
            else
            {
                switch (GameReadyManager.instance.GunNum)
                {
                    case 1:
                        emptycartridge[i].transform.position = new Vector3(PistolLefthud.transform.position.x - 0.3f, PistolLefthud.transform.position.y, 0);
                        break;
                    case 2:
                        emptycartridge[i].transform.position = new Vector3(ShotgunLefthud.transform.position.x - 0.3f, ShotgunLefthud.transform.position.y, 0);
                        break;
                    case 3:
                        emptycartridge[i].transform.position = new Vector3(UziLefthud.transform.position.x - 0.3f, UziLefthud.transform.position.y, 0);
                        break;
                }
                rigid.AddForce(Vector2.right * Random.Range(1.0f, 4.0f) + Vector2.down * Random.Range(1.0f, 3.0f), ForceMode2D.Impulse);
            }
        }
        GameManager.instance.Bulletupdate();
    }
    private void GunReload()
    {
        BulletReloadTime.SetActive(true);
        isReload = true;
        Invoke("EndReload", 2.0f);
        Invoke("Emptycartridge", 0.6f);
        switch (GameReadyManager.instance.GunNum)
        {
            case 1:
                magazine = 12;
                break;
            case 2:
                magazine = 6;
                break;
            case 3:
                magazine = 50;
                break;
        }
        
    }

    private void EndReload()
    {
        ReloadTime.transform.position = Reloadstartline.transform.position;
        BulletReloadTime.SetActive(false);
        isReload = false;
    }
    private void Fire()
    {
     
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;

        Vector3 len_1 = Quaternion.AngleAxis(1, new Vector3(0, 0, 1)) * len;
        Vector3 len_2 = Quaternion.AngleAxis(2, new Vector3(0, 0, 1)) * len;
        Vector3 len_3 = Quaternion.AngleAxis(3, new Vector3(0, 0, 1)) * len;
        Vector3 len__1 = Quaternion.AngleAxis(-1, new Vector3(0, 0, 1)) * len;
        Vector3 len__2 = Quaternion.AngleAxis(-2, new Vector3(0, 0, 1)) * len;
        Vector3 len__3 = Quaternion.AngleAxis(-3, new Vector3(0, 0, 1)) * len;

        if (CurFireDelay >= MaxFireDelay*100.0f/(100.0f + AS))
        {
            if (Input.GetMouseButton(0) && !GameManager.instance.isPause && magazine > 0 && !isReload)
            {
                switch (BulletNum)
                {
                    case 1:
                        GameObject Bul = GameManager.instance.pool.Get(1);
                        if (len.x > 0)
                        {
                            switch (GameReadyManager.instance.GunNum)
                            {
                                case 1:
                                    Bul.transform.position = PistolRighthud.transform.position;
                                    break;
                                case 2:
                                    Bul.transform.position = ShotgunRighthud.transform.position;
                                    break;
                                case 3:
                                    Bul.transform.position = UziRighthud.transform.position;
                                    break;
                            }
                            
                        }
                        else
                        {
                            switch (GameReadyManager.instance.GunNum)
                            {
                                case 1:
                                    Bul.transform.position = PistolLefthud.transform.position;
                                    break;
                                case 2:
                                    Bul.transform.position = ShotgunLefthud.transform.position;
                                    break;
                                case 3:
                                    Bul.transform.position = UziLefthud.transform.position;
                                    break;

                            }
                            
                        }
                        Bul.transform.rotation = Quaternion.Euler(0, 0, z);
                        Rigidbody2D rigid = Bul.GetComponent<Rigidbody2D>();
                        rigid.AddForce(len.normalized * BulletSpeed, ForceMode2D.Impulse);
                        break;
                    case 4:
                        GameObject bul3_1 = GameManager.instance.pool.Get(1);
                        GameObject bul3_2 = GameManager.instance.pool.Get(1);
                        GameObject bul3_3 = GameManager.instance.pool.Get(1);
                        GameObject bul3_4 = GameManager.instance.pool.Get(1);

                        if (len.x > 0)
                        {
                            switch (GameReadyManager.instance.GunNum)
                            {
                                case 1:
                                    bul3_1.transform.position = PistolRighthud.transform.position;
                                    bul3_2.transform.position = PistolRighthud.transform.position;
                                    bul3_3.transform.position = PistolRighthud.transform.position;
                                    bul3_4.transform.position = PistolRighthud.transform.position;
                                    break;
                                case 2:
                                    bul3_1.transform.position = ShotgunRighthud.transform.position;
                                    bul3_2.transform.position = ShotgunRighthud.transform.position;
                                    bul3_3.transform.position = ShotgunRighthud.transform.position;
                                    bul3_4.transform.position = ShotgunRighthud.transform.position;
                                    break;
                                case 3:
                                    bul3_1.transform.position = UziRighthud.transform.position;
                                    bul3_2.transform.position = UziRighthud.transform.position;
                                    bul3_3.transform.position = UziRighthud.transform.position;
                                    bul3_4.transform.position = UziRighthud.transform.position;
                                    break;

                            }
                        }
                        else
                        {
                            switch (GameReadyManager.instance.GunNum)
                            {
                                case 1:
                                    bul3_1.transform.position = PistolLefthud.transform.position;
                                    bul3_2.transform.position = PistolLefthud.transform.position;
                                    bul3_3.transform.position = PistolLefthud.transform.position;
                                    bul3_4.transform.position = PistolLefthud.transform.position;
                                    break;
                                case 2:
                                    bul3_1.transform.position = ShotgunLefthud.transform.position;
                                    bul3_2.transform.position = ShotgunLefthud.transform.position;
                                    bul3_3.transform.position = ShotgunLefthud.transform.position;
                                    bul3_4.transform.position = ShotgunLefthud.transform.position;
                                    break;
                                case 3:
                                    bul3_1.transform.position = UziLefthud.transform.position;
                                    bul3_2.transform.position = UziLefthud.transform.position;
                                    bul3_3.transform.position = UziLefthud.transform.position;
                                    bul3_4.transform.position = UziLefthud.transform.position;
                                    break;

                            }
                        }

                        bul3_1.transform.rotation = Quaternion.Euler(0, 0, z + 3);
                        Rigidbody2D rigid3_1 = bul3_1.GetComponent<Rigidbody2D>();
                        rigid3_1.AddForce((len_3.normalized) * BulletSpeed, ForceMode2D.Impulse);

                        bul3_2.transform.rotation = Quaternion.Euler(0, 0, z + 1);
                        Rigidbody2D rigid3_2 = bul3_2.GetComponent<Rigidbody2D>();
                        rigid3_2.AddForce((len_1.normalized) * BulletSpeed, ForceMode2D.Impulse);

                        bul3_3.transform.rotation = Quaternion.Euler(0, 0, z - 1);
                        Rigidbody2D rigid3_3 = bul3_3.GetComponent<Rigidbody2D>();
                        rigid3_3.AddForce((len__1.normalized) * BulletSpeed, ForceMode2D.Impulse);

                        bul3_4.transform.rotation = Quaternion.Euler(0, 0, z - 3);
                        Rigidbody2D rigid3_4 = bul3_4.GetComponent<Rigidbody2D>();
                        rigid3_4.AddForce((len__3.normalized) * BulletSpeed, ForceMode2D.Impulse);
                        break;
                }
                CurFireDelay = 0.0f;
                magazine -= 1;
                GameManager.instance.Bulletupdate();
                if(magazine <= 0)
                {
                    GunReload();
                }
            }
        }
    }
    private void InstallMine()
    {
        if (CurMineDelay > GameManager.instance.Minetime)
        {
            GameObject Mine = GameManager.instance.pool.Get(7);
            Mine.transform.position = transform.position;
            CurMineDelay = 0;
        }
    }
    public void GetDamaged()
    {
        if (!isDmg)
        {
            animator.SetBool("Takedamage", true);
            isDmg = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            switch (GameReadyManager.instance.GunNum)
            {
                case 1:
                    pistol.transparency();
                    break;
                case 2:
                    shotgun.transparency();
                    break;
                case 3:
                    uzi.transparency();
                    break;
            }
            
            Invoke("NormalLayer", 1.5f);
            HP -= 1;
            Heart();
        }
    }

    private void NormalLayer()
    {
        isDmg = false;
        animator.SetBool("Takedamage", false);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        switch (GameReadyManager.instance.GunNum)
        {
            case 1:
                pistol.normal();
                break;
            case 2:
                shotgun.normal();
                break;
            case 3:
                uzi.normal();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttack" )
        {
            GetDamaged();
        }
    }

    private void Reload()
    {
        CurFireDelay += Time.deltaTime;
        CurDashDelay += Time.deltaTime;
    }
}
