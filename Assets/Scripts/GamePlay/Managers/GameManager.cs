using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    //½Ì±ÛÅæ
    public static GameManager instance;

    public PoolManager pool;
    public Player player;
    float Dashimsi;
    [SerializeField]
    private Slider Dashbar;

    //ÇÃ·¹ÀÌ¾î µ¥ÀÌÅÍ
    public int Level = 0;

    //°ÔÀÓ µ¥ÀÌÅÍ
    public bool isPause = false;
    public bool isGameover = false;
    public bool OnMenu = false;
    public bool SecondWepon1 = false;
    public bool SecondWepon2 = false;
    public bool SecondWepon3 = false;
    public bool SecondWepon4 = false;
    public bool SecondWepon5 = false;
    private float CurEnemy1BuildDelay = 0.0f;
    private float CurEnemy2BuildDelay = 0.0f;
    private float CurEnemy3BuildDelay = 0.0f;
    private float CurEnemy4BuildDelay = 0.0f;
    private float CurEnemy5BuildDelay = 0.0f;
    private float CurEnemy6BuildDelay = 0.0f;

    private float MaxEnemy1BuildDelay = 10.0f;
    private float MaxEnemy2BuildDelay = 10.0f;
    private float MaxEnemy3BuildDelay = 10.0f;
    private float MaxEnemy4BuildDelay = 10.0f;
    private float MaxEnemy5BuildDelay = 10.0f;
    private float MaxEnemy6BuildDelay = 10.0f;
    public int pos = 0;
    public float HitBullet = 0.0f;
    public float PlayTime = 0.0f;
    public int kill = 0;
    public int narrowsightstacks = 0;

    //Ä® 
    public int Knifenum = 1;
    public float Knifetime = 3.0f;
    public float Knifedmg = 20.0f;
    public int Knifepenetration = 1;

    //ÆøÅº
    public int Bombnum = 1;
    public float Bombdmg = 10.0f;
    public float Bombtime = 5.0f;
    public int Bombrange = 1;

    //µµ³¢
    public int Axenum = 1;
    public float Axedmg = 15.0f;
    public float Axerange = 1;
    public float Axespeed = 150.0f;
    public float Axetime = 2.0f;

    //ºÎ¸Þ¶û
    public int Boomerangnum = 1;
    public float Boomerangdmg = 10.0f;
    //ºÎ¸Þ¶ûÁö¼Ó½Ã°£
    public float Boomerangtime = 5.0f;
    public float Boomerangspeed = 25.0f;

    //ÆÄÆí



    //°ÔÀÓ ¿ÀºêÁ§Æ®
    public GameObject MenuUI;
    public Transform[] EnemyBuildPos;
    public Transform EnemyBuildPos1;
    public Transform EnemyBuildPos2;
    public Transform EnemyBuildPos3;
    public Transform EnemyBuildPos4;
    public Transform EnemyBuildPos5;
    public Transform EnemyBuildPos6;
    public Transform EnemyBuildPos7;
    public Transform EnemyBuildPos8;
    public Transform EnemyBuildPos9;
    public Transform EnemyBuildPos10;
    public Transform EnemyBuildPos11;
    public Transform EnemyBuildPos12;
    public GameObject GunGun;
    public GameObject NarrowSight;

    //¿¤¸®Æ®¿¤¸®Æ® Àû¿ÀºêÁ§Æ®
    public Text KillText;
    public GameObject GameoverUI;
    public GameObject Boss1;
 
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
        EnemyBuildPos = new Transform[] { EnemyBuildPos1, EnemyBuildPos2, EnemyBuildPos3, EnemyBuildPos4, EnemyBuildPos5, EnemyBuildPos6, EnemyBuildPos7, EnemyBuildPos8, EnemyBuildPos9, EnemyBuildPos10, EnemyBuildPos11, EnemyBuildPos12 };
        Dashbar.value = (float)player.CurDashDelay / (float)3.0f;
        
        switch (GameReadyManager.instance.SecondWeaponNum)
        {
            case 1:
                SecondWepon1 = true;
                break;
            case 2:
                SecondWepon2 = true;
                break;
            case 3:
                SecondWepon3 = true;
                break;
            case 4:
                SecondWepon4 = true;
                break;
            case 5:
                SecondWepon5 = true;
                break;
        }
    }

    private void Update()
    {
        Dashimsi = (float)player.CurDashDelay / (float)3.0f;
        Dashbar.value = Mathf.Lerp(Dashbar.value, Dashimsi, Time.deltaTime * 10);
        PlayTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape) && OnMenu == false && isPause == false)
        {
            OnMenu = true;
            MenuUI.SetActive(true);
            IsPause();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && OnMenu == true)
        {
            OnMenu = false;
            MenuUI.SetActive(false);
            IsPause();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Player.instance.HP += 1;
        }

        if ( kill >= 700)
        {
            Boss1.SetActive(true);
        }
        BuildEnemy();
        Reload();
        Sight();
    }
    private void FixedUpdate()
    {
        HitBullet += Time.fixedDeltaTime;
    }
    private void Reload()
    {
            CurEnemy1BuildDelay += Time.deltaTime;
            CurEnemy2BuildDelay += Time.deltaTime;
            CurEnemy3BuildDelay += Time.deltaTime;
            CurEnemy4BuildDelay += Time.deltaTime;
            CurEnemy5BuildDelay += Time.deltaTime;
            CurEnemy6BuildDelay += Time.deltaTime;
    }

    public void GameOver()
    {
        if (!isGameover)
        {
            isGameover = true;
            GameoverUI.SetActive(true);
            IsPause();
        }
    }
    public void MenuOff()
    {
        OnMenu = false;
        IsPause();
    }

    public void KillEnemy(int num)
    {
        kill += 1;
        KillText.text = kill + " Kill";
    }
    public void IsPause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    
    //Àû »ý¼º
    private void BuildEnemy()
    {
        if (CurEnemy1BuildDelay > MaxEnemy1BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy1 = pool.Get(9);
            Enemy1.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1BuildDelay = 0;
        }

        if (CurEnemy2BuildDelay > MaxEnemy2BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy2 = pool.Get(11);
            Enemy2.transform.position = EnemyBuildPos[pos].position;
            CurEnemy2BuildDelay = 0;
        }

        if (CurEnemy3BuildDelay > MaxEnemy3BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy3 = pool.Get(13);
            Enemy enemyLogic1_3 = Enemy3.GetComponent<Enemy>();
            Enemy3.transform.position = EnemyBuildPos[pos].position;
            CurEnemy3BuildDelay = 0;
        }

        if (CurEnemy4BuildDelay > MaxEnemy4BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy4 = pool.Get(16);
            Enemy4.transform.position = EnemyBuildPos[pos].position;
            CurEnemy4BuildDelay = 0;
        }

        if (CurEnemy5BuildDelay > MaxEnemy5BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy5 = pool.Get(17);
            Enemy5.transform.position = EnemyBuildPos[pos].position;
            CurEnemy5BuildDelay = 0;
        }

        if (CurEnemy6BuildDelay > MaxEnemy6BuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject Enemy6 = pool.Get(18);
            Enemy enemyLogic2_3 = Enemy6.GetComponent<Enemy>();
            Enemy6.transform.position = EnemyBuildPos[pos].position;
            CurEnemy6BuildDelay = 0;
        }
    }


    void Sight()
    {
        if(narrowsightstacks > 0)
        {
            NarrowSight.SetActive(true);
        }else if(narrowsightstacks == 0)
        {
            NarrowSight.SetActive(false);
        }
    }
}
