using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    //적 배열
    public string[] enemyObjs;

    //오브젝트 매니저
    public ObjectManager ObjectManager;
    float EXPimsi;
    //큐

    [SerializeField]
    private Slider EXPbar;

    
    //플레이어 데이터
    public int Gold = 0;
    public float EXP = 0.0f;
    private float MaxEXP = 15.0f;
    private int Level = 1;


    
    //게임 데이터
    public bool isPause = false;
    public bool OnMenu = false;
    private float CurEnemy1_1BuildDelay = 0.0f;
    private float CurEnemy1_2BuildDelay = -60.0f;
    private float CurEnemy1_3BuildDelay = -120.0f;
    private float MaxEnemy1_1BuildDelay = 2.0f;
    private float MaxEnemy1_2BuildDelay = 3.0f;
    private float MaxEnemy1_3BuildDelay = 4.0f;
    public int Upgradenum1;
    public int Upgradenum2;
    public int Upgradenum3;
    public int Gun1Level = 0;
    public int Gun2Level = 0;
    public int BombLevel = 0;
    public int DragonLevel = 0;
    public int ArmorLevel = 0;
    public int KnifeLevel = 0;
    public int OuraLevel = 0;
    public int AxeLevel = 0;
    public int EnergyLevel = 0;
    public int KunaiLevel = 0;
    public int Non1Level = 0;
    public int Non2Level = 0;
    public int pos = 0;

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
    public GameObject GunGun;


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
        enemyObjs = new string[] { "Enemy1_1", "Enemy1_2", "Enemy1_3" };
        EnemyBuildPos = new Transform[] {EnemyBuildPos1,EnemyBuildPos2,EnemyBuildPos3 };
        EXPbar.value = (float)EXP / (float)MaxEXP;
    }

    private void Update()
    {
        EXPimsi = (float)EXP / (float)MaxEXP;
        EXPbar.value = Mathf.Lerp(EXPbar.value, EXPimsi, Time.deltaTime * 10);

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
        BuildEnemy();
        LevelUp();
        Reload();
    }

    private void FixedUpdate()
    {
       //EXPimsi = (float)EXP / (float)MaxEXP;
       //EXPbar.value = Mathf.Lerp(EXPbar.value, EXPimsi, Time.deltaTime * 10);
    }
    private void Reload()
    {

        CurEnemy1_1BuildDelay += Time.deltaTime;
        CurEnemy1_2BuildDelay += Time.deltaTime;
        CurEnemy1_3BuildDelay += Time.deltaTime;

    }

    private void LevelUp()
    {
        if (EXP >= MaxEXP)
        {
            Level += 1;
            EXP = 0.0f;
            IsPause();
            UpgradeMenu();
            UpgradeUI.SetActive(true);
            MaxEXP += 5.0f;

        }
    }

    public void GetExp(float exp)
    {
        EXP += exp;
        
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

    public void GetGold(int gold)
    {
        Gold += gold;
        GoldText.text = Gold+" Gold";
    }

    public void GetEXP(int exp)
    {
        EXP += exp;

    }
    private void BuildEnemy()
    {
        if (CurEnemy1_1BuildDelay > MaxEnemy1_1BuildDelay)
        {
            pos = Random.Range(0, 3);
            GameObject enemy1_1 = ObjectManager.MakeObj(enemyObjs[0]);
            Enemy enemyLogic1_1 = enemy1_1.GetComponent<Enemy>();
            enemyLogic1_1.ObjectManager = ObjectManager;
            enemy1_1.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1_1BuildDelay = 0;
        }

        if (CurEnemy1_2BuildDelay > MaxEnemy1_2BuildDelay)
        {
            pos = Random.Range(0, 3);
            GameObject enemy1_2 = ObjectManager.MakeObj(enemyObjs[1]);
            Enemy enemyLogic1_2 = enemy1_2.GetComponent<Enemy>();
            enemyLogic1_2.ObjectManager = ObjectManager;
            enemy1_2.transform.position = EnemyBuildPos[pos].position;
            CurEnemy1_2BuildDelay = 0;
        }

        if (CurEnemy1_3BuildDelay > MaxEnemy1_3BuildDelay)
        {
            pos = Random.Range(0, 3);
            GameObject enemy1_3 = ObjectManager.MakeObj(enemyObjs[2]);
            Enemy enemyLogic1_3 = enemy1_3.GetComponent<Enemy>();
            enemyLogic1_3.ObjectManager = ObjectManager;
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
        int[] UpgradeLevel = { 0, Gun1Level, Gun2Level, BombLevel, DragonLevel, ArmorLevel, KnifeLevel, OuraLevel, AxeLevel, KunaiLevel, EnergyLevel, Non1Level, Non2Level };
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
        for(int i = 0; i<FullUpgrade.Count; i++)
        {
            Debug.Log(FullUpgradecopy[i]);
        }
        Upgrade();
        for(int i = 0; i<FullUpgradecopy.Length; i++)
        {
            if(Upgradenum1 == FullUpgradecopy[i] || Upgradenum2 == FullUpgradecopy[i] || Upgradenum3 == FullUpgradecopy[i])
            {
                UpgradeMenu();
            }
        }




        Text[] UpgradeText = { Upgrade1Text, Upgrade2Text, Upgrade3Text };
        Text[] UpgradeExplainText = { Upgrade1ExplainText, Upgrade2ExplainText, Upgrade3ExplainText };
        int[] num = { Upgradenum1, Upgradenum2, Upgradenum3 };
        
        for (int i = 0; i < 3; i++)
        {
            
            switch (num[i]){
                case 1:
                    UpgradeText[i].text = "총알강화";
                    switch (Gun1Level)
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
                case 2:
                    UpgradeText[i].text = "총알강화2";
                    switch (Gun2Level)
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
                case 3:
                    UpgradeText[i].text = "폭탄";
                    switch (BombLevel)
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
                case 4:
                    UpgradeText[i].text = "소환수";
                    switch (DragonLevel)
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
                case 5:
                    UpgradeText[i].text = "방어";
                    switch (ArmorLevel)
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
                case 6:
                    UpgradeText[i].text = "칼";
                    switch (KnifeLevel)
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
                case 7:
                    UpgradeText[i].text = "오우라";
                    switch (OuraLevel)
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
                case 8:
                    UpgradeText[i].text = "도끼";
                    switch (AxeLevel)
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
                case 9:
                    UpgradeText[i].text = "쿠나이";
                    switch (KunaiLevel)
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
                case 10:
                    UpgradeText[i].text = "에너지";
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
                    UpgradeText[i].text = "미정";
                    switch (Non2Level)
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
                        
                        break;
                    case 1:
                        break;
                    case 2:
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
                        
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
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
                switch (OuraLevel)
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
                OuraLevel += 1;
                break;
            case 8:
                switch (AxeLevel)
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
                AxeLevel += 1;
                break;
            case 9:
                switch (KunaiLevel)
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
                switch (Non2Level)
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
                Non2Level += 1;
                break;
        }
    }
}
