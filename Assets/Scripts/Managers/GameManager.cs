using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    public PoolManager pool;
    public Player player;
    float EXPimsi;
    float Dashimsi;
    [SerializeField]
    private Slider EXPbar;
    [SerializeField]
    private Slider Dashbar;

    //플레이어 데이터
    public int Gold = 0;
    public float EXP = 0.0f;
    private float MaxEXP = 10.0f;
    private int Level = 1;

    //게임 데이터
    public bool isPause = false;
    public bool isGameover = false;
    public bool OnMenu = false;
    private float CurShopEnemyBuildDelay = 0.0f;
    private float CurEnemy1_1BuildDelay = 0.0f;
    private float CurEnemy1_2BuildDelay = -60.0f;
    private float CurEnemy1_3BuildDelay = -120.0f;
    private float MaxShopEnemyBuildDelay = 300.0f;
    public float MaxEnemy1_1BuildDelay = 2.5f;
    private float MaxEnemy1_2BuildDelay = 10.0f;
    private float MaxEnemy1_3BuildDelay = 10.0f;
    public int Upgradenum1;
    public int Upgradenum2;
    public int Upgradenum3;
    public int Gun1Level = 0;
    public int Gun2Level = 0;
    public int BombLevel = 0;
    public int DragonLevel = 0;
    public int ArmorLevel = 0;
    public int KnifeLevel = 0;
    public int BoomerangLevel = 0;
    public int AxeLevel = 0;
    public int EnergyLevel = 0;
    public int KunaiLevel = 0;
    public int Non1Level = 0;
    public int Gun3Level = 0;
    public int pos = 0;
    public float HitBullet = 0.0f;
    public int kill = 0;
    public int killpet = 10000;
    public int killed444 = 0;
    public bool doublemoney = false;
    public bool isKilled444 = false;
    public bool getkilled444 = false;
    public float PlusBuildEnemy = 0.0f;
    //특수 이벤트
    public bool isAllElite = false;
    public bool isManyEnemy = false;
    public bool isEliteofElite = false;
    public bool isEventMany = false;
    public bool isEventAllElite = false;
    public bool isEventEliteofElite = false;


    //게임 오브젝트
    public Text GoldText;
    public Text[] UpgradeText;
    public Text Upgrade1Text;
    public Text Upgrade2Text;
    public Text Upgrade3Text;
    public Text Upgrade1ExplainText;
    public Text Upgrade2ExplainText;
    public Text Upgrade3ExplainText;
    public GameObject UpgradeUI;
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
    public GameObject ShopUI;
    public Text LevelText;
    public GameObject PlayerBarrier;
    public GameObject PlayerAxe;
    public GameObject PlayerFinalAxe;
    public GameObject KunaiPos1;
    public GameObject KunaiPos2;
    public GameObject KunaiPos3;
    public GameObject KunaiPos4;
    public GameObject KunaiPos5;
    public GameObject KunaiPos6;
    //엘리트엘리트 적오브젝트
    public GameObject EliteEliteEnemy1_1;
    public GameObject EliteEliteEnemy1_2;
    public GameObject EliteEliteEnemy1_3;
    public Text BonusStat1;
    public Text BonusStat2;
    public Text BonusStat3;
    public Text KillText;
    int[] BonusStatnum;
    int BonusStatnum1 = 0;
    int BonusStatnum2 = 0;
    int BonusStatnum3 = 0;
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
        EXPbar.value = (float)EXP / (float)MaxEXP;
        Dashbar.value = (float)player.CurDashDelay / (float)3.0f;
    }

    private void Update()
    {
        EXPimsi = (float)EXP / (float)MaxEXP;
        Dashimsi = (float)player.CurDashDelay / (float)3.0f;
        EXPbar.value = Mathf.Lerp(EXPbar.value, EXPimsi, Time.deltaTime * 10);
        Dashbar.value = Mathf.Lerp(Dashbar.value, Dashimsi, Time.deltaTime * 10);

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
            //Player.instance.MaxHP += 1;
            Player.instance.HP += 1;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GetEXP(20);
        }
        if(!isEventMany && kill >= 150)
        {
            isEventMany = true;
            ManyEnemy();
        }
        if (!isEventAllElite && kill >= 350)
        {
            isEventAllElite = true;
            AllElite();
        }
        if (!isEventEliteofElite && kill >=550)
        {
            isEventEliteofElite = true;
            EliteEliteEnemy1_1.SetActive(true);
            EliteEliteEnemy1_2.SetActive(true);
            EliteEliteEnemy1_3.SetActive(true);
            EliteOfElite();
        }

        if (!Boss1.activeSelf && kill >= 700)
        {
            Boss1.SetActive(true);
        }
        BuildEnemy();
        LevelUp();
        Reload();
        Kill444();
    }
    private void FixedUpdate()
    {
        HitBullet += Time.fixedDeltaTime;
    }
    private void Reload()
    {
        CurShopEnemyBuildDelay += Time.deltaTime;
        CurEnemy1_1BuildDelay += Time.deltaTime;
        CurEnemy1_2BuildDelay += Time.deltaTime;
        CurEnemy1_3BuildDelay += Time.deltaTime;
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

    private void LevelUp()
    {
        if (EXP >= MaxEXP)
        {
            Level += 1;
            LevelText.text = "LV. " + Level;
            EXP = EXP-MaxEXP;
            IsPause();
            UpgradeMenu();
            UpgradeUI.SetActive(true);
            if (MaxEXP <= 95)
            {
                MaxEXP += 5.0f;
            }
        }
    }
    public void LevelUPItem()
    {
        Level += 1;
        IsPause();
        UpgradeMenu();
        UpgradeUI.SetActive(true);
        if (MaxEXP <= 95)
        {
            MaxEXP += 5.0f;
        }
    }

    private void GetExp(float exp)
    {
        EXP += exp;
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
        switch (num)
        {
            case 1:
                GetEXP(1);
                GetGold(1);
                break;
            case 2:
                int ran = Random.Range(5, 11);
                GetEXP(ran);
                GetGold(ran);
                break;
        }
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
    public void ShopOpen()
    {
        ShopUI.SetActive(true);
    }

    public void GetGold(int gold)
    {
        if (!doublemoney)
        {
            Gold += gold * 2;
        }
        else if (doublemoney)
        {
            Gold += gold * 4;
        }
        GoldText.text = Gold + " Gold";
    }
    public void GetEXP(int exp)
    {
        EXP += exp;
    }
    
    //적 생성
    private void BuildEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            if (kill >= (i + 1) * 20 && PlusBuildEnemy == i)
            {
                PlusBuildEnemy = i + 1;
            }
        }
        if (isManyEnemy)
        {
            PlusBuildEnemy = 0.0f;
            MaxEnemy1_1BuildDelay = 0.1f;
            MaxEnemy1_2BuildDelay = 0.3f;
            MaxEnemy1_3BuildDelay = 0.2f;
        }
        if (CurShopEnemyBuildDelay > MaxShopEnemyBuildDelay)
        {
            pos = Random.Range(0, 12);
            GameObject ShopEnemy = pool.Get(9);
            ShopEnemy.transform.position = EnemyBuildPos[pos].position;
            CurShopEnemyBuildDelay = 0;
        }
        if (CurEnemy1_1BuildDelay > MaxEnemy1_1BuildDelay-PlusBuildEnemy*0.2f)
        {
            pos = Random.Range(0, 12);
            GameObject enemy1_1 = pool.Get(0);
            enemy1_1.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1_1BuildDelay = 0;
        }

        if (CurEnemy1_2BuildDelay > MaxEnemy1_2BuildDelay-PlusBuildEnemy*0.1f)
        {
            pos = Random.Range(0, 12);
            GameObject enemy1_2 = pool.Get(2);
            enemy1_2.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1_2BuildDelay = 0;
        }

        if (CurEnemy1_3BuildDelay > MaxEnemy1_3BuildDelay-PlusBuildEnemy*0.2f)
        {
            pos = Random.Range(0, 12);
            GameObject enemy1_3 = pool.Get(4);
            Enemy enemyLogic1_3 = enemy1_3.GetComponent<Enemy>();
            enemy1_3.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1_3BuildDelay = 0;
        }
    }

    private void Upgrade()
    {
        Upgradenum1 = Random.Range(1, 13);
        Upgradenum2 = Random.Range(1, 13);
        Upgradenum3 = Random.Range(1, 13);

        while (Upgradenum1 == Upgradenum2)
        {
            Upgradenum2 = Random.Range(1, 13);
        }

        while (Upgradenum2 == Upgradenum3 || Upgradenum3 == Upgradenum1)
        {
            Upgradenum3 = Random.Range(1, 13);
        }
    }

    public void UpgradeMenu()
    {
        int[] UpgradeLevel = { 0, Gun1Level, Gun2Level, BombLevel, DragonLevel, ArmorLevel, KnifeLevel, BoomerangLevel, AxeLevel, KunaiLevel, EnergyLevel, Non1Level, Gun3Level };
        Queue<int> FullUpgrade = new Queue<int>();

        for (int i = 1; i < 13; i++)
        {
            if (UpgradeLevel[i] > 3)
            {
                FullUpgrade.Enqueue(i);
            }
        }
        //큐FullUpgrade를 배열FullUpgradecopy로 복사
        int[] FullUpgradecopy = FullUpgrade.ToArray();

        for (int i = 0; i < FullUpgrade.Count; i++)
        {
            Debug.Log(FullUpgradecopy[i]);
        }

        Upgrade();

        for (int i = 0; i < FullUpgradecopy.Length; i++)
        {
            if (Upgradenum1 == FullUpgradecopy[i] || Upgradenum2 == FullUpgradecopy[i] || Upgradenum3 == FullUpgradecopy[i])
            {
                UpgradeMenu();
            }
        }

        Text[] UpgradeText = { Upgrade1Text, Upgrade2Text, Upgrade3Text };
        Text[] UpgradeExplainText = { Upgrade1ExplainText, Upgrade2ExplainText, Upgrade3ExplainText };
        Text[] BonusStat = { BonusStat1, BonusStat2, BonusStat3 };
        string[] BonusStatKind = { "공격력 ", "공격력 ", "손재주 ", "손재주 ", "공격속도 ", "공격속도 ", "이동속도 ", "이동속도 " };
        int[] num = { Upgradenum1, Upgradenum2, Upgradenum3 };
        BonusStatnum1 = Random.Range(0, 8);
        BonusStatnum2 = Random.Range(0, 8);
        BonusStatnum3 = Random.Range(0, 8);
        int[] BonusStatValue = { +2, -2, +3, -3, +5, -5, +3, -3 };
        BonusStatnum = new int[] { BonusStatnum1, BonusStatnum2, BonusStatnum3 };
        for (int i = 0; i < 3; i++)
        {

            BonusStat[i].text = "추가 스탯 : " + BonusStatKind[BonusStatnum[i]] + BonusStatValue[BonusStatnum[i]] * (UpgradeLevel[num[i]] + 1);

            switch (num[i])
            {
                case 1:
                    UpgradeText[i].text = "사격강화";
                    switch (Gun1Level)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "2발로 증가, 공격력 -2";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "3발로 증가";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "4발로 증가, 공격속도 +10%";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "총을 하나 더 든다";
                            break;
                    }
                    break;
                case 2:
                    UpgradeText[i].text = "사격강화 2";
                    switch (Gun2Level)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "총알이 추가피해를 준다";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "총알이 적을 속박하고 추가피해량이 상승한다";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "총알이 적을 관통한다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "총알이 적을 타격시 일정확률로 폭발한다";
                            break;
                    }
                    break;
                case 3:
                    UpgradeText[i].text = "폭탄";
                    switch (BombLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "폭탄을 던진다";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "폭탄을 두개 던진다";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "폭탄의 피해량이 상승한다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "폭탄의 폭발범위가 늘어난다";
                            break;
                    }
                    break;
                case 4:
                    UpgradeText[i].text = "소환수";
                    switch (DragonLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "100킬시 소환수 소환";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "200킬시 소환수 투사체 +2";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "400킬시 적의 투사체를 방어하고 300번막을때마다 체력1회복";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "700킬시 소환수한마리 추가소환";
                            break;
                    }
                    break;
                case 5:
                    UpgradeText[i].text = "방어";
                    switch (ArmorLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "체력 +1";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "캐릭터 주위를 도는 방어막 생성 ";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "캐릭터의 크기가 작아진다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "체력 +1, 사망시 부활하며 체력을 전부 회복한다";
                            break;
                    }
                    break;
                case 6:
                    UpgradeText[i].text = "칼";
                    switch (KnifeLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "칼을 던진다";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "칼을 3개 던진다";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "더 짧은 간격으로 공격한다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "3번 던질때 마다 거대칼로 공격한다";
                            break;
                    }
                    break;
                case 7:
                    UpgradeText[i].text = "부메랑";
                    switch (BoomerangLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "튕기는 부메랑으로 공격";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "부메랑 피해량 상승";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "부메랑 지속시간 증가";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "부메랑 +2";
                            break;
                    }
                    break;
                case 8:
                    UpgradeText[i].text = "도끼";
                    switch (AxeLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "캐릭터의 주변을 돌며 공격하는 도끼 생성";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "도끼의 피해량이 상승한다";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "도끼가 적과 충돌해도 사라지지 않는다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "도끼의 범위가 늘어나고 회전 속도가 빨라진다, 도끼 +2";
                            break;
                    }
                    break;
                case 9:
                    UpgradeText[i].text = "수리검";
                    switch (KunaiLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "총을 쏠때마다 수리검이 같이 공격한다";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "수리검의 피해량의 상승한다, 수리검 +1";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "5번 공격할 때마다 사방으로 수리검을 던진다";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "수리검 +4";
                            break;
                    }
                    break;
                case 10:
                    UpgradeText[i].text = "미정";
                    switch (EnergyLevel)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "";
                            break;
                    }
                    break;
                case 11:
                    UpgradeText[i].text = "미정";
                    switch (Non1Level)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "";
                            break;
                    }
                    break;
                case 12:
                    UpgradeText[i].text = "사격강화 3";
                    switch (Gun3Level)
                    {
                        case 0:
                            UpgradeExplainText[i].text = "탄속 +30%, 공격속도 +30%";
                            break;
                        case 1:
                            UpgradeExplainText[i].text = "5초마다 5초동안 공격속도 +100%";
                            break;
                        case 2:
                            UpgradeExplainText[i].text = "8번 공격할 때마다 전방향으로 공격";
                            break;
                        case 3:
                            UpgradeExplainText[i].text = "총알로 적 타격시 파편을 남기고 잠시후 파편을 잡아당겨서 공격";
                            break;
                    }
                    break;
            }
        }
    }
    public void Upgrade(int num)
    {
        int[] up = { Upgradenum1, Upgradenum2, Upgradenum3 };

        switch (up[num])
        {
            case 1:
                switch (Gun1Level)
                {
                    case 0:
                        Player.instance.AD -= 2;
                        break;
                    case 1:
                        break;
                    case 2:
                        Player.instance.AS += 10;
                        break;
                    case 3:
                        GunGun.SetActive(true);
                        break;
                }
                Gun1Level += 1;
                break;
            case 2:
                switch (Gun2Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                Gun2Level += 1;
                break;
            case 3:
                switch (BombLevel)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                BombLevel += 1;
                break;
            case 4:
                switch (DragonLevel)
                {
                    case 0:
                        killpet = kill;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                DragonLevel += 1;
                break;
            case 5:
                switch (ArmorLevel)
                {
                    case 0:
                        Player.instance.HP += 1;
                        Player.instance.MaxHP += 1;
                        Player.instance.Heart();
                        break;
                    case 1:
                        PlayerBarrier.SetActive(true);
                        break;
                    case 2:
                        Player.instance.transform.localScale = new Vector3(0.2f, 0.2f, 0);
                        break;
                    case 3:
                        Player.instance.HP += 1;
                        Player.instance.MaxHP += 1;
                        Player.instance.Heart();
                        break;
                }
                ArmorLevel += 1;
                break;
            case 6:
                switch (KnifeLevel)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                KnifeLevel += 1;
                break;
            case 7:
                switch (BoomerangLevel)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                BoomerangLevel += 1;
                break;
            case 8:
                switch (AxeLevel)
                {
                    case 0:
                        PlayerAxe.SetActive(true);
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        PlayerAxe.SetActive(false);
                        PlayerFinalAxe.SetActive(true);
                        break;
                }
                AxeLevel += 1;
                break;
            case 9:
                switch (KunaiLevel)
                {
                    case 0:
                        KunaiPos1.SetActive(true);
                        break;
                    case 1:
                        KunaiPos2.SetActive(true);
                        break;
                    case 2:
                        break;
                    case 3:
                        KunaiPos3.SetActive(true);
                        KunaiPos4.SetActive(true);
                        KunaiPos5.SetActive(true);
                        KunaiPos6.SetActive(true);
                        break;
                }
                KunaiLevel += 1;
                break;
            case 10:
                switch (EnergyLevel)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                EnergyLevel += 1;
                break;
            case 11:
                switch (Non1Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                Non1Level += 1;
                break;
            case 12:
                switch (Gun3Level)
                {
                    case 0:
                        Player.instance.BulletSpeed += 4.5f;
                        Player.instance.AS += 30.0f;
                        break;
                    case 1:
                        Player.instance.FiveSecondASUp();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                Gun3Level += 1;
                break;
        }
    }
    public void BonusStatUpgrade(int btnnum)
    {
        int[] UpgradeLevel = { 0, Gun1Level, Gun2Level, BombLevel, DragonLevel, ArmorLevel, KnifeLevel, BoomerangLevel, AxeLevel, KunaiLevel, EnergyLevel, Non1Level, Gun3Level };
        int[] num = { Upgradenum1, Upgradenum2, Upgradenum3 };
        BonusStatnum = new int[] { BonusStatnum1, BonusStatnum2, BonusStatnum3 };
        string[] BonusStatKind = { "공격력 ", "공격력 ", "손재주 ", "손재주 ", "공격속도 ", "공격속도 ", "이동속도 ", "이동속도 " };
        int[] BonusStatValue = { 2, -2, 3, -3, 5, -5, 3, -3 };
        if (BonusStatnum[btnnum] == 0 || BonusStatnum[btnnum] == 1)
        {
            Player.instance.AD += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
        }
        else if (BonusStatnum[btnnum] == 2 || BonusStatnum[btnnum] == 3)
        {
            Player.instance.AP += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
        }
        else if (BonusStatnum[btnnum] == 4 || BonusStatnum[btnnum] == 5)
        {
            Player.instance.AS += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
        }
        else if (BonusStatnum[btnnum] == 6 || BonusStatnum[btnnum] == 7)
        {
            Player.instance.moveSpeed += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
            Player.instance.NormalSpeed += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
            Player.instance.ChangeSpeed += BonusStatValue[BonusStatnum[btnnum]] * (UpgradeLevel[num[btnnum]]);
        }
    }

    void Kill444()
    {
        if (kill - killed444 >= 444 && isKilled444 == false && getkilled444 == true)
        {
            isKilled444 = true;
            Player.instance.AD += 44;
            Player.instance.AP += 44;
            Player.instance.AS += 44;
        }
    }

    //적 이벤트
    public void AllElite()
    {
        isAllElite = true;
        Invoke("EventOff", 6.0f);
    }

    public void EliteOfElite()
    {
        isEliteofElite = true;
        Invoke("EventOff", 10.0f);
    }

    public void ManyEnemy()
    {
        isManyEnemy = true;
        Invoke("EventOff", 3.0f);
    }
    void EventOff()
    {
        isAllElite = false;
        isEliteofElite = false;
        isManyEnemy = false;
        MaxEnemy1_1BuildDelay = 2.5f;
        MaxEnemy1_2BuildDelay = 10.0f;
        MaxEnemy1_3BuildDelay = 10.0f;
    }
}
