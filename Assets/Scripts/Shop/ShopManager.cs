using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class ShopManager : MonoBehaviour
{
    private ShopData shopData;

    private string xmlPath;
    private string SavePath = Application.persistentDataPath + "/SaveData.xml";
    private string content = "<SaveData><GoldCount>40</GoldCount><HeightScore>38</HeightScore><ID0>1</ID0><ID1>1</ID1><ID2>0</ID2><ID3>0</ID3></SaveData>";


    private GameObject ui_ShopItem;
    private GameObject LeftButtpn;
    private GameObject RightButtpn;
    private UILabel StarNum;
    private UILabel ScoreNum;
    private StartManager m_StartManager;
    private List<GameObject> shopUI = new List<GameObject>();
    private int index = 0;
    private Transform m_Transform;
    // Use this for initialization
    void Start()
    {
        xmlPath = Resources.Load("ShopData").ToString();
        if (!File.Exists(SavePath))
        {
            File.WriteAllText(SavePath, content);
        }
        shopData = new ShopData();
        shopData.ReadXmlByPath(xmlPath);
        shopData.ReadScoreAndGold(SavePath);
        Debug.Log(shopData.goldCount);
        Debug.Log(shopData.heightScore);
      
        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");
        LeftButtpn = GameObject.Find("LeftButton");
        RightButtpn = GameObject.Find("RightButton");
        StarNum = GameObject.Find("Star/StarNum").GetComponent<UILabel>();
        ScoreNum = GameObject.Find("Score/ScoreNum").GetComponent<UILabel>();
        m_StartManager = GameObject.Find("UI Root").GetComponent<StartManager>();

        int tempHeightScore = PlayerPrefs.GetInt("HeightScore", 0);
        if (tempHeightScore > shopData.heightScore)
        {
            UpdateUIHeightScore(tempHeightScore);
            shopData.UpdateXMLData(SavePath, "HeightScore", tempHeightScore.ToString());
            PlayerPrefs.SetInt("HeightScore", 0);

        }
        else
        {
            UpdateUIHeightScore(shopData.heightScore);
        }

        int tempGold = PlayerPrefs.GetInt("GoldNum", 0);
        if (tempGold > 0)
        {
            int gold = shopData.goldCount + tempGold;
            UpdateUIGold(gold);
            shopData.UpdateXMLData(SavePath, "GoldCount", gold.ToString());
            PlayerPrefs.SetInt("GoldNum", 0);
        }
        else
        {
            UpdateUIGold(shopData.goldCount);
        }
        
        UIEventListener.Get(LeftButtpn).onClick = leftButtpnClick;
        UIEventListener.Get(RightButtpn).onClick = rightButtpnClick;
        SetPlayerInfo(shopData.ShopList[0]);
        CreateAllShopUI();

    }

    private void UpdateUIHeightScore(int heightScore)
    {
        ScoreNum.text = heightScore.ToString();
    }

    private void UpdateUIGold(int gold)
    {
        StarNum.text = gold.ToString();
    }

    private void UpdateUI()
    {
        StarNum.text = shopData.goldCount.ToString();
        ScoreNum.text = shopData.heightScore.ToString();
    }

    private void CreateAllShopUI()
    {
        for (int i = 0; i < shopData.ShopList.Count; i++)
        {
            GameObject item = NGUITools.AddChild(gameObject, ui_ShopItem);
            GameObject ship = Resources.Load<GameObject>(shopData.ShopList[i].Model);
            item.GetComponent<ShopItemUI>().SetUIValue(shopData.ShopList[i].Id, shopData.ShopList[i].Speed, shopData.ShopList[i].Rotate, shopData.ShopList[i].Price, ship,shopData.shopState[i]);
            shopUI.Add(item);
        }
        ShopUIHideAndShop(index);
    }

    private void leftButtpnClick(GameObject go)
    {
        if (index > 0)
        {
            Debug.Log("左");
            index--;
            int item = shopData.shopState[index];
            SetPlayerInfo(shopData.ShopList[index]);
            m_StartManager.SetButtonPlayClick(item);
            ShopUIHideAndShop(index);
        }

    }
    private void rightButtpnClick(GameObject go)
    {
        if (index < shopUI.Count-1)
        {
            Debug.Log("右");
            index++;
            int item = shopData.shopState[index];
            SetPlayerInfo(shopData.ShopList[index]);
            m_StartManager.SetButtonPlayClick(item);
            ShopUIHideAndShop(index);
        }
    }

    private void ShopUIHideAndShop(int index)
    {
        for (int i = 0; i < shopUI.Count; i++)
        {
            shopUI[i].SetActive(false);
        }
        shopUI[index].SetActive(true);
    }

    private void CalcItemPrice(ShopItemUI item)
    {
        if (shopData.goldCount >= item.itemPrice)
        {
            Debug.Log("购买成功");
            item.BuyEnd();
            shopData.goldCount -= item.itemPrice;
            UpdateUI();
            shopData.UpdateXMLData(SavePath, "GoldCount", shopData.goldCount.ToString());
            shopData.UpdateXMLData(SavePath, "ID" + item.itemId, "1");
        }
        else
        {
            Debug.Log("购买失败");
        }
    }

    private void SetPlayerInfo(ShopItem item)
    {
        PlayerPrefs.SetString("PlayerName", item.Model);
        PlayerPrefs.SetInt("PlayerSpeed", int.Parse(item.Speed));
        PlayerPrefs.SetInt("PlayerRotate", int.Parse(item.Rotate));
    }
}