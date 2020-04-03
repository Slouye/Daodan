
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class ShopData {

    public List<ShopItem> ShopList = new List<ShopItem>();
    public List<int> shopState = new List<int>();
    public int goldCount = 0;
    public int heightScore = 0;

    public void ReadXmlByPath(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(path);
        XmlNode root = doc.SelectSingleNode("Shop");
        XmlNodeList nodeList = root.ChildNodes;
        foreach (XmlNode node in nodeList)
        {
            string speed = node.ChildNodes[0].InnerText;
            string rotate = node.ChildNodes[1].InnerText;
            string model = node.ChildNodes[2].InnerText;
            string price = node.ChildNodes[3].InnerText;
            string id = node.ChildNodes[4].InnerText;

            //string info = string.Format("{0}--{1}--{2}--{3}", speed, rotate, model, price);
            //Debug.Log(info);

            ShopItem item = new ShopItem(id,speed, rotate, model, price);
            ShopList.Add(item);
        }

    }

    public void ReadScoreAndGold(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;
        goldCount = int.Parse( nodeList[0].InnerText);
        heightScore = int.Parse(nodeList[1].InnerText);
        for (int i = 2; i < 6; i++)
        {
            shopState.Add(int.Parse(nodeList[i].InnerText));
        }
    }

    public void UpdateXMLData(string path,string key, string value)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;
        foreach (XmlNode node in nodeList)
        {
            if (node.Name == key)
            {
                node.InnerText = value;
                doc.Save(path);
            }
        }
    }

}
