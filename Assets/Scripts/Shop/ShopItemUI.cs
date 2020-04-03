using UnityEngine;
using System.Collections;

public class ShopItemUI : MonoBehaviour {
    private Transform m_Transform;
    private UILabel ui_Speed;
    private UILabel ui_Rotate;
    private UILabel ui_Price;
    private GameObject shipParent;
    private GameObject BuyButton;
    private GameObject itemState;

    public int itemPrice;
    public int itemId;
    // Use this for initialization

    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        ui_Speed = m_Transform.FindChild("Speed/Speed_Num").GetComponent<UILabel>();
        ui_Rotate = m_Transform.FindChild("Rotate/Rotate_Num").GetComponent<UILabel>();
        ui_Price = m_Transform.FindChild("BuyButton/Price").GetComponent<UILabel>();
        BuyButton = m_Transform.FindChild("BuyButton/Bg").gameObject;
        shipParent = m_Transform.FindChild("Model").gameObject;
        itemState = m_Transform.FindChild("BuyButton").gameObject;

        UIEventListener.Get(BuyButton).onClick = BuyButtonClick;
    }

    public void SetUIValue(string id, string speed, string rotate, string price,GameObject model,int state)
    {
        ui_Speed.text = speed;
        ui_Rotate.text = rotate;
        ui_Price.text = price;

        itemPrice = int.Parse(price);
        itemId = int.Parse(id);
        if (state ==1)
        {
            itemState.SetActive(false);
        }
        GameObject ship = NGUITools.AddChild(shipParent, model);
        ship.layer = 8;
        Transform ship_Transform = ship.GetComponent<Transform>();
        ship_Transform.FindChild("Mesh").gameObject.layer = 8;
        if (model.name == "Ship_4")
        {
            ship_Transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else
        {
            ship_Transform.localScale = new Vector3(8, 8, 8);
        }
        ship_Transform.localPosition = new Vector3(0, -110, 86);
        Vector3 rot = new Vector3(-90, 0, 0);
        ship_Transform.localRotation = Quaternion.Euler(rot);
    }
        
        


   

    private void BuyButtonClick(GameObject go)
    {
        SendMessageUpwards("CalcItemPrice",this);
    }

    public void BuyEnd()
    {
        itemState.SetActive(false);
    }

}
