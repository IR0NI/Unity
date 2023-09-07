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
        Text[] ItemNameText = { ItemName1, ItemName2, ItemName3 };
        Text[] ItemExplainText = { ItemExplain1, ItemExplain2, ItemExplain3 };
        int[] Item = { Item1, Item2, Item3 };
        for (int i = 0; i < 3; i++)
        {
            switch (Item[i])
            {
                case 1:
                    ItemNameText[i].text = "1 (300���)";
                    ItemExplainText[i].text = "���ݷ� +30";
                    break;
                case 2:
                    ItemNameText[i].text = "2 (400���)";
                    ItemExplainText[i].text = "���ݷ� +50, ������ -20 ";
                    break;
                case 3:
                    ItemNameText[i].text = "3 (300���)";
                    ItemExplainText[i].text = "���ݼӵ� +25%";
                    break;
                case 4:
                    ItemNameText[i].text = "4 (400���)";
                    ItemExplainText[i].text = "���ݼӵ� +40%, ���ݷ� -10";
                    break;
                case 5:
                    ItemNameText[i].text = "5 (300���)";
                    ItemExplainText[i].text = "������ +50";
                    break;
                case 6:
                    ItemNameText[i].text = "6 (500���)";
                    ItemExplainText[i].text = "������ +100, ���ݷ� -20";
                    break;
                case 7:
                    ItemNameText[i].text = "7 (200���)";
                    ItemExplainText[i].text = "�̵��ӵ� +20";
                    break;
                case 8:
                    ItemNameText[i].text = "8 (400���)";
                    ItemExplainText[i].text = "�̵��ӵ� +40";
                    break;
                case 9:
                    ItemNameText[i].text = "9 (400���)";
                    ItemExplainText[i].text = "������ +40, ���ݼӵ� +20%";
                    break;
                case 10:
                    ItemNameText[i].text = "10 (400���)";
                    ItemExplainText[i].text = "ü�� 1ȸ��";
                    break;
                case 11:
                    ItemNameText[i].text = "11 (550���)";
                    ItemExplainText[i].text = "���ݷ� +30, ���ݼӵ� +30%";
                    break;
                case 12:
                    ItemNameText[i].text = "12 (350���)";
                    ItemExplainText[i].text = "���ȹ�淮 2��";
                    break;
                case 13:
                    ItemNameText[i].text = "13 (444���)";
                    ItemExplainText[i].text = "���ݺ��� 444ų �޼��� ���ݷ� +44, ������ +44, ���ݼӵ� +44%";
                    break;
                case 14:
                    ItemNameText[i].text = "14 (1200���)";
                    ItemExplainText[i].text = "���ݷ� +100, ������ +130";
                    break;
                case 15:
                    ItemNameText[i].text = "15 (700���)";
                    ItemExplainText[i].text = "ü�� 2ȸ��";
                    break;
                case 16:
                    ItemNameText[i].text = "16 (300���)";
                    ItemExplainText[i].text = "��ȭ������ 11���̻��϶� ���ݷ� +150, ������ +200";
                    break;
                case 17:
                    ItemNameText[i].text = "17 (900���)";
                    ItemExplainText[i].text = "���� +1";
                    break;
                case 18:
                    ItemNameText[i].text = "18 (0���)";
                    ItemExplainText[i].text = "��� +100";
                    break;
                case 19:
                    ItemNameText[i].text = "19 (200���)";
                    ItemExplainText[i].text = "��� +(100 - 600)";
                    break;
                case 20:
                    ItemNameText[i].text = "20 (300���)";
                    ItemExplainText[i].text = "���ݼӵ� +20%, �̵��ӵ� +10";
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
                    Player.instance.AD += 30;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 2:
                if (GameManager.instance.Gold >= 400)
                {
                    Player.instance.AD += 50;
                    Player.instance.AP -= 20;
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
                    Player.instance.AP += 40;
                    Player.instance.AD -= 10;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 5:
                if (GameManager.instance.Gold >= 300)
                {
                    Player.instance.AP += 50;
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 6:
                if (GameManager.instance.Gold >= 500)
                {
                    Player.instance.AP += 100;
                    Player.instance.AD -= 20;
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
                    Player.instance.AP += 40;
                    Player.instance.AS += 20;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 10:
                if (GameManager.instance.Gold >= 400 && Player.instance.MaxHP > Player.instance.HP)
                {
                    Player.instance.HP += 1;
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 11:
                if (GameManager.instance.Gold >= 550)
                {
                    Player.instance.AD += 30;
                    Player.instance.AS += 30;
                    GameManager.instance.Gold -= 550;
                    ItemBuyUI(num);
                }
                break;
            case 12:
                if (GameManager.instance.Gold >= 350)
                {
                    GameManager.instance.Gold -= 350;
                    ItemBuyUI(num);
                }
                break;
            case 13:
                if (GameManager.instance.Gold >= 444)
                {
                    GameManager.instance.Gold -= 444;
                    ItemBuyUI(num);
                }
                break;
            case 14:
                if (GameManager.instance.Gold >= 1200)
                {
                    Player.instance.AD += 100;
                    Player.instance.AP += 130;
                    GameManager.instance.Gold -= 1200;
                    ItemBuyUI(num);
                }
                break;
            case 15:
                if (GameManager.instance.Gold >= 700 && Player.instance.MaxHP > Player.instance.HP)
                {
                    Player.instance.HP += 2;
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
    }
    public void ItemBuyUI(int num)
    {
        switch (num)
        {
            case 0: 
                ItemName1.text = "";
                ItemExplain1.text = "";
                ItemIcon1.SetActive(false);
                ItemSelled1.text = "ǰ��";
                break;
            case 1:
                ItemName2.text = "";
                ItemExplain2.text = "";
                ItemIcon2.SetActive(false);
                ItemSelled2.text = "ǰ��";
                break;
            case 2:
                ItemName3.text = "";
                ItemExplain3.text = "";
                ItemIcon3.SetActive(false);
                ItemSelled3.text = "ǰ��";
                break;
        }
    }
}
