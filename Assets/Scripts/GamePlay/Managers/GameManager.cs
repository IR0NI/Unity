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
    private float CurEnemy3BuildDelay = -9990.0f;
    private float CurEnemy4BuildDelay = -9990.0f;
    private float CurEnemy5BuildDelay = -9990.0f;
    private float CurEnemy6BuildDelay = -9990.0f;

    private float MaxEnemy1BuildDelay = 3.0f;
    private float MaxEnemy2BuildDelay = 7.0f;
    private float MaxEnemy3BuildDelay = 10.0f;
    private float MaxEnemy4BuildDelay = 10.0f;
    private float MaxEnemy5BuildDelay = 10.0f;
    private float MaxEnemy6BuildDelay = 10.0f;
    public int pos = 0;
    public float PlayTime = 0.0f;
    public int kill = 0;
    public int narrowsightstacks = 0;
    public int Upgradenum1 = 0;
    public int Upgradenum2 = 0;
    public int Upgradenum3 = 0;

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
    public Text Playtimetext;
    public Transform[] EnemyBuildPos;
    //¿ø°Å¸® ¼ÒÈ¯
    public Transform EnemyBuildPos1;
    public Transform EnemyBuildPos2;
    public Transform EnemyBuildPos3;
    //±Ù°Å¸®¼ÒÈ¯
    public Transform EnemyBuildPos4;
    public Transform EnemyBuildPos5;
    public Transform EnemyBuildPos6;
    public Transform EnemyBuildPos7;
    public Transform EnemyBuildPos8;
    public Transform EnemyBuildPos9;
    public Transform EnemyBuildPos10;
    public Transform EnemyBuildPos11;
    public Transform EnemyBuildPos12;
    public GameObject NarrowSight;
    public GameObject Axe3;
    public GameObject Axe4;
    public GameObject Axe5;
    public GameObject Axe6;
    public Text Upgrade1Text;
    public Text Upgrade2Text;
    public Text Upgrade3Text;
    public GameObject UpgradeMenuUI;

    //¿¤¸®Æ®¿¤¸®Æ® Àû¿ÀºêÁ§Æ®
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
                Axe3.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            UpgradeMenu();
            UpgradeMenuUI.SetActive(true);
            IsPause();
        }

        if ( PlayTime >= 600)
        {
            Boss1.SetActive(true);
        }
        BuildEnemy();
        Reload();
        Sight();
        PlayTimetextupgrade();
    }
    private void PlayTimetextupgrade()
    {
        Playtimetext.text = Mathf.Floor(PlayTime/60)+":"+Mathf.Floor(PlayTime- Mathf.Floor(PlayTime / 60) * 60) ;
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
            pos = Random.Range(3, 12);
            GameObject Enemy1 = pool.Get(9);
            Enemy1.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1BuildDelay = 0;
        }

        if (CurEnemy2BuildDelay > MaxEnemy2BuildDelay)
        {
            pos = Random.Range(0, 3);
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

    public void UpgradeMenu()
    {
        Upgradenum1 = Random.Range(2, 11);
        Upgradenum2 = Random.Range(2, 11);
        Upgradenum3 = Random.Range(2, 11);

        while (Upgradenum1 == Upgradenum2)
        {
            Upgradenum2 = Random.Range(2, 11);
        }

        while (Upgradenum2 == Upgradenum3 || Upgradenum3 == Upgradenum1)
        {
            Upgradenum3 = Random.Range(2, 11);
        }

        Text[] UpgradeText = { Upgrade1Text, Upgrade2Text, Upgrade3Text };
        int[] num = { Upgradenum1, Upgradenum2, Upgradenum3 };

        for (int i = 0; i < 3; i++)
        {
            switch (num[i])
            {
                case 1:
                    UpgradeText[i].text = "»ç°Å¸® +30%, Åº¼Ó +30%";
                    break;
                case 2:
                    UpgradeText[i].text = "°ø°Ý·Â +50%";
                    break;
                case 3:
                    UpgradeText[i].text = "°ø°Ý¼Óµµ +50%";
                    break;
                case 4:
                    UpgradeText[i].text = "°üÅë +1";
                    break;
                case 5:
                    UpgradeText[i].text = "ÀÌµ¿¼Óµµ +20%";
                    break;
                case 6:
                    UpgradeText[i].text = "Ã¼·Â +1";
                    break;
                case 7:
                    switch (GameReadyManager.instance.SecondWeaponNum)
                    {
                        case 1:
                            UpgradeText[i].text = "Ä®+1";
                            break;
                        case 2:
                            UpgradeText[i].text = "ÆøÅº+1";
                            break;
                        case 3:
                            UpgradeText[i].text = "ºÎ¸Þ¶û+1";
                            break;
                        case 4:
                            UpgradeText[i].text = "µµ³¢+1";
                            break;
                        case 5:
                            UpgradeText[i].text = "";
                            break;
                    }
                    break;
                case 8:
                    switch (GameReadyManager.instance.SecondWeaponNum)
                    {
                        case 1:
                            UpgradeText[i].text = "Ä® ÇÇÇØ·® »ó½Â";
                            break;
                        case 2:
                            UpgradeText[i].text = "ÆøÅº ÇÇÇØ·® »ó½Â";
                            break;
                        case 3:
                            UpgradeText[i].text = "ºÎ¸Þ¶û ÇÇÇØ·® »ó½Â";
                            break;
                        case 4:
                            UpgradeText[i].text = "µµ³¢ ÇÇÇØ·® »ó½Â";
                            break;
                        case 5:
                            UpgradeText[i].text = "";
                            break;
                    }
                    break;
                case 9:
                    switch (GameReadyManager.instance.SecondWeaponNum)
                    {
                        case 1:
                            UpgradeText[i].text = "Ä® °üÅë +1";
                            break;
                        case 2:
                            UpgradeText[i].text = "ÆøÅº Æø¹ß¹üÀ§ »ó½Â";
                            break;
                        case 3:
                            UpgradeText[i].text = "ºÎ¸Þ¶û ¼Óµµ »ó½Â";
                            break;
                        case 4:
                            UpgradeText[i].text = "µµ³¢ ¹üÀ§ »ó½Â";
                            break;
                        case 5:
                            UpgradeText[i].text = "";
                            break;
                    }
                    break;
                case 10:
                    switch (GameReadyManager.instance.SecondWeaponNum)
                    {
                        case 1:
                            UpgradeText[i].text = "Ä® ÅõÃ´½Ã°£ °¨¼Ò";
                            break;
                        case 2:
                            UpgradeText[i].text = "ÆøÅº ÅõÃ´½Ã°£ °¨¼Ò";
                            break;
                        case 3:
                            UpgradeText[i].text = "ºÎ¸Þ¶û Áö¼Ó½Ã°£ Áõ°¡";
                            break;
                        case 4:
                            UpgradeText[i].text = "µµ³¢ ÀçÀåÀü½Ã°£ °¨¼Ò";
                            break;
                        case 5:
                            UpgradeText[i].text = "";
                            break;
                    }
                    break;
            }

        }

    }

    public void Upgrade(int num)
    {
        int[] upgradenum = { Upgradenum1, Upgradenum2, Upgradenum3 };
        switch (upgradenum[num])
        {
            case 1:
                break;
            case 2:
                Player.instance.AD += Player.instance.BaseAD * 0.5f;
                break;
            case 3:
                Player.instance.AS += 50.0f;
                break;
            case 4:
                Player.instance.Bulletpeneration += 1;
                break;
            case 5:
                Player.instance.NormalSpeed += 20.0f;
                Player.instance.moveSpeed += 20.0f;
                Player.instance.ChangeSpeed += 20.0f;
                break;
            case 6:
                Player.instance.MaxHP += 1;
                Player.instance.HP += 1;
                Player.instance.Heart();
                break;
            case 7:
                switch (GameReadyManager.instance.SecondWeaponNum)
                {
                    case 1:
                        Knifenum += 1;
                        break;
                    case 2:
                        Bombnum += 1;
                        break;
                    case 3:
                        Boomerangnum += 1;
                        break;
                    case 4:
                        Axenum += 1;
                        break;
                    case 5:
                        
                        break;
                }
                break;
            case 8:
                switch (GameReadyManager.instance.SecondWeaponNum)
                {
                    case 1:
                        Knifedmg += 15.0f;
                        break;
                    case 2:
                        Bombdmg += 10.0f;
                        break;
                    case 3:
                        Boomerangdmg += 10.0f;
                        break;
                    case 4:
                        Axedmg += 10.0f;
                        break;
                    case 5:
                        
                        break;
                }
                break;
            case 9:
                switch (GameReadyManager.instance.SecondWeaponNum)
                {
                    case 1:
                        Knifepenetration += 1;
                        break;
                    case 2:
                        Bombrange += 1;
                        break;
                    case 3:
                        Boomerangspeed += 10.0f;
                        break;
                    case 4:
                        Axerange += 0.5f;
                        break;
                    case 5:

                        break;
                }
                break;
            case 10:
                switch (GameReadyManager.instance.SecondWeaponNum)
                {
                    case 1:
                        Knifetime -= 0.75f;
                        break;
                    case 2:
                        Bombtime -= 0.75f;
                        break;
                    case 3:
                        Boomerangtime += 5.0f;
                        break;
                    case 4:
                        Axetime -= 0.5f;
                        break;
                    case 5:

                        break;
                }
                break;
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
