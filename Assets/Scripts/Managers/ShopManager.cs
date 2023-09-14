using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Text ItemName1;
    public Text ItemName2;
    public Text ItemName3;
    public Text ItemExplain1;
    public Text ItemExplain2;
    public Text ItemExplain3;
    public GameObject ItemIcon1;
    public GameObject ItemIcon2;
    public GameObject ItemIcon3;
    public Text ItemSelled1;
    public Text ItemSelled2;
    public Text ItemSelled3;
    public int Item1;
    public int Item2;
    public int Item3;
    

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
    }
    private void ItemShuffle()
    {
        Item1 = Random.Range(1, 21);
        Item2 = Random.Range(1, 21);
        Item3 = Random.Range(1, 21);

        while (Item1 == Item2)
        {
            Item2 = Random.Range(1, 21);
        }

        while (Item2 == Item3 || Item3 == Item1)
        {
            Item3 = Random.Range(1, 21);
        }
    }
    public void ItemNumShuffle()
    {
        ItemShuffle();
        ItemSelled1.text = "";
        ItemSelled2.text = "";
        ItemSelled3.text = "";
        Text[] ItemNameText = { ItemName1, ItemName2, ItemName3 };
        Text[] ItemExplainText = { ItemExplain1, ItemExplain2, ItemExplain3 };
        int[] Item = { Item1, Item2, Item3 };
        for (int i = 0; i < 3; i++)
        {
            switch (Item[i])
            {
                case 1:
                    ItemNameText[i].text = "1 (300골드)";
                    ItemExplainText[i].text = "공격력 +3";
                    break;
                case 2:
                    ItemNameText[i].text = "2 (400골드)";
                    ItemExplainText[i].text = "공격력 +5, 손재주 -2 ";
                    break;
                case 3:
                    ItemNameText[i].text = "3 (300골드)";
                    ItemExplainText[i].text = "공격속도 +25%";
                    break;
                case 4:
                    ItemNameText[i].text = "4 (400골드)";
                    ItemExplainText[i].text = "공격속도 +40%, 공격력 -1";
                    break;
                case 5:
                    ItemNameText[i].text = "5 (300골드)";
                    ItemExplainText[i].text = "손재주 +5";
                    break;
                case 6:
                    ItemNameText[i].text = "6 (500골드)";
                    ItemExplainText[i].text = "손재주 +10, 공격력 -2";
                    break;
                case 7:
                    ItemNameText[i].text = "7 (200골드)";
                    ItemExplainText[i].text = "이동속도 +20";
                    break;
                case 8:
                    ItemNameText[i].text = "8 (400골드)";
                    ItemExplainText[i].text = "이동속도 +40";
                    break;
                case 9:
                    ItemNameText[i].text = "9 (400골드)";
                    ItemExplainText[i].text = "손재주 +4, 공격속도 +20%";
                    break;
                case 10:
                    ItemNameText[i].text = "10 (400골드)";
                    ItemExplainText[i].text = "체력 1회복";
                    break;
                case 11:
                    ItemNameText[i].text = "11 (550골드)";
                    ItemExplainText[i].text = "공격력 +3, 공격속도 +30%";
                    break;
                case 12:
                    ItemNameText[i].text = "12 (350골드)";
                    ItemExplainText[i].text = "골드획득량 2배";
                    break;
                case 13:
                    ItemNameText[i].text = "13 (444골드)";
                    ItemExplainText[i].text = "지금부터 444킬 달성시 공격력 +44, 손재주 +44, 공격속도 +44%";
                    break;
                case 14:
                    ItemNameText[i].text = "14 (1200골드)";
                    ItemExplainText[i].text = "공격력 +10, 손재주 +13";
                    break;
                case 15:
                    ItemNameText[i].text = "15 (700골드)";
                    ItemExplainText[i].text = "체력 2회복";
                    break;
                case 16:
                    ItemNameText[i].text = "16 (300골드)미구현클릭x!!";
                    ItemExplainText[i].text = "강화종류가 11개이상일때 공격력 +15, 손재주 +20";
                    break;
                case 17:
                    ItemNameText[i].text = "17 (900골드)미구현클릭x!!";
                    ItemExplainText[i].text = "레벨 +1";
                    break;
                case 18:
                    ItemNameText[i].text = "18 (0골드)";
                    ItemExplainText[i].text = "골드 +100";
                    break;
                case 19:
                    ItemNameText[i].text = "19 (200골드)";
                    ItemExplainText[i].text = "골드 +(100 - 600)";
                    break;
                case 20:
                    ItemNameText[i].text = "20 (300골드)";
                    ItemExplainText[i].text = "공격속도 +20%, 이동속도 +10";
                    break;
            }
        }
    }

    public void ItemBuy(int num)
    {
        int[] Item = { Item1, Item2, Item3 };
        switch (Item[num])
        {
            case 1:
                if (GameManager.instance.Gold >= 300)
                {
                    Player.instance.AD += 3;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 2:
                if (GameManager.instance.Gold >= 400)
                {
                    Player.instance.AD += 5;
                    Player.instance.AP -= 2;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 3:
                if (GameManager.instance.Gold >= 300)
                {
                    Player.instance.AS += 25;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 4:
                if (GameManager.instance.Gold >= 400)
                {
                    Player.instance.AP += 4;
                    Player.instance.AD -= 1;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 5:
                if (GameManager.instance.Gold >= 300)
                {
                    Player.instance.AP += 5;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 6:
                if (GameManager.instance.Gold >= 500)
                {
                    Player.instance.AP += 10;
                    Player.instance.AD -= 2;
                    GameManager.instance.Gold -= 500;
                    ItemBuyUI(num);
                }
                break;
            case 7:
                if (GameManager.instance.Gold >= 200)
                {
                    Player.instance.ChangeSpeed += 20;
                    Player.instance.moveSpeed += 20;
                    Player.instance.NormalSpeed += 20;
                    GameManager.instance.Gold -= 200;
                    ItemBuyUI(num);
                }
                break;
            case 8:
                if (GameManager.instance.Gold >= 400)
                {
                    Player.instance.ChangeSpeed += 20;
                    Player.instance.moveSpeed += 40;
                    Player.instance.NormalSpeed += 40;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 9:
                if (GameManager.instance.Gold >= 400)
                {
                    Player.instance.AP += 4;
                    Player.instance.AS += 20;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 10:
                if (GameManager.instance.Gold >= 400 && Player.instance.MaxHP > Player.instance.HP)
                {
                    Player.instance.HP += 1;
                    Player.instance.Heart();
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 11:
                if (GameManager.instance.Gold >= 550)
                {
                    Player.instance.AD += 3;
                    Player.instance.AS += 30;
                    GameManager.instance.Gold -= 550;
                    ItemBuyUI(num);
                }
                break;
            case 12:
                if (GameManager.instance.Gold >= 350)
                {
                    GameManager.instance.Gold -= 350;
                    GameManager.instance.doublemoney = true;
                    ItemBuyUI(num);
                }
                break;
            case 13:
                if (GameManager.instance.Gold >= 444)
                {
                    GameManager.instance.getkilled444 = true;
                    GameManager.instance.killed444 = GameManager.instance.kill;
                    GameManager.instance.Gold -= 444;
                    ItemBuyUI(num);
                }
                break;
            case 14:
                if (GameManager.instance.Gold >= 1200)
                {
                    Player.instance.AD += 10;
                    Player.instance.AP += 13;
                    GameManager.instance.Gold -= 1200;
                    ItemBuyUI(num);
                }
                break;
            case 15:
                if (GameManager.instance.Gold >= 700 && Player.instance.MaxHP > Player.instance.HP)
                {
                    Player.instance.HP += 2;
                    Player.instance.Heart();
                    GameManager.instance.Gold -= 700;
                    ItemBuyUI(num);
                }
                break;
            case 16:
                if (GameManager.instance.Gold >= 300)
                {
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 17:
                if (GameManager.instance.Gold >= 900)
                {
                    
                    GameManager.instance.Gold -= 900;
                    ItemBuyUI(num);
                }
                break;
            case 18:
                if (GameManager.instance.Gold >= 0)
                {
                    GameManager.instance.Gold += 100;
                    ItemBuyUI(num);
                }
                break;
            case 19:
                if (GameManager.instance.Gold >= 200)
                {
                    int ran = Random.Range(100,601);
                    GameManager.instance.Gold += ran;
                    GameManager.instance.Gold -= 200;
                    ItemBuyUI(num);
                }
                break;
            case 20:
                if (GameManager.instance.Gold >= 300)
                {
                    Player.instance.AS += 20;
                    Player.instance.ChangeSpeed += 10;
                    Player.instance.moveSpeed += 10;
                    Player.instance.NormalSpeed += 10;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
        }
        GameManager.instance.GetGold(0);
    }
    public void ItemBuyUI(int num)
    {
        switch (num)
        {
            case 0: 
                ItemName1.text = "";
                ItemExplain1.text = "";
                ItemIcon1.SetActive(false);
                ItemSelled1.text = "품절";
                break;
            case 1:
                ItemName2.text = "";
                ItemExplain2.text = "";
                ItemIcon2.SetActive(false);
                ItemSelled2.text = "품절";
                break;
            case 2:
                ItemName3.text = "";
                ItemExplain3.text = "";
                ItemIcon3.SetActive(false);
                ItemSelled3.text = "품절";
                break;
        }
    }
}
