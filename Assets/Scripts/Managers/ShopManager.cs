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
                    ItemNameText[i].text = "1";
                    ItemExplainText[i].text = "";
                    break;
                case 2:
                    ItemNameText[i].text = "2";
                    ItemExplainText[i].text = "";
                    break;
                case 3:
                    ItemNameText[i].text = "3";
                    ItemExplainText[i].text = "";
                    break;
                case 4:
                    ItemNameText[i].text = "4";
                    ItemExplainText[i].text = "";
                    break;
                case 5:
                    ItemNameText[i].text = "5";
                    ItemExplainText[i].text = "";
                    break;
                case 6:
                    ItemNameText[i].text = "6";
                    ItemExplainText[i].text = "";
                    break;
                case 7:
                    ItemNameText[i].text = "7";
                    ItemExplainText[i].text = "";
                    break;
                case 8:
                    ItemNameText[i].text = "8";
                    ItemExplainText[i].text = "";
                    break;
                case 9:
                    ItemNameText[i].text = "9";
                    ItemExplainText[i].text = "";
                    break;
                case 10:
                    ItemNameText[i].text = "10";
                    ItemExplainText[i].text = "";
                    break;
                case 11:
                    ItemNameText[i].text = "11";
                    ItemExplainText[i].text = "";
                    break;
                case 12:
                    ItemNameText[i].text = "12";
                    ItemExplainText[i].text = "";
                    break;
                case 13:
                    ItemNameText[i].text = "13";
                    ItemExplainText[i].text = "";
                    break;
                case 14:
                    ItemNameText[i].text = "14";
                    ItemExplainText[i].text = "";
                    break;
                case 15:
                    ItemNameText[i].text = "15";
                    ItemExplainText[i].text = "";
                    break;
                case 16:
                    ItemNameText[i].text = "16";
                    ItemExplainText[i].text = "";
                    break;
                case 17:
                    ItemNameText[i].text = "17";
                    ItemExplainText[i].text = "";
                    break;
                case 18:
                    ItemNameText[i].text = "18";
                    ItemExplainText[i].text = "";
                    break;
                case 19:
                    ItemNameText[i].text = "19";
                    ItemExplainText[i].text = "";
                    break;
                case 20:
                    ItemNameText[i].text = "20";
                    ItemExplainText[i].text = "";
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
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 2:
                if (GameManager.instance.Gold >= 400)
                {
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 3:
                if (GameManager.instance.Gold >= 300)
                {
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 4:
                if (GameManager.instance.Gold >= 400)
                {
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 5:
                if (GameManager.instance.Gold >= 300)
                {
                    GameManager.instance.Gold -= 300;
                    ItemBuyUI(num);
                }
                break;
            case 6:
                if (GameManager.instance.Gold >= 500)
                {
                    GameManager.instance.Gold -= 500;
                    ItemBuyUI(num);
                }
                break;
            case 7:
                if (GameManager.instance.Gold >= 200)
                {
                    GameManager.instance.Gold -= 200;
                    ItemBuyUI(num);
                }
                break;
            case 8:
                if (GameManager.instance.Gold >= 400)
                {
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 9:
                if (GameManager.instance.Gold >= 400)
                {
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 10:
                if (GameManager.instance.Gold >= 400)
                {
                    GameManager.instance.Gold -= 400;
                    ItemBuyUI(num);
                }
                break;
            case 11:
                if (GameManager.instance.Gold >= 550)
                {
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
                    GameManager.instance.Gold -= 1200;
                    ItemBuyUI(num);
                }
                break;
            case 15:
                if (GameManager.instance.Gold >= 700)
                {
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
                    ItemBuyUI(num);
                }
                break;
            case 19:
                if (GameManager.instance.Gold >= 200)
                {
                    GameManager.instance.Gold -= 200;
                    ItemBuyUI(num);
                }
                break;
            case 20:
                if (GameManager.instance.Gold >= 300)
                {
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
