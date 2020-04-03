using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLTest : MonoBehaviour {
    private string xmlUrl = "Assets/Datas/web.xml";
	// Use this for initialization
	void Start () {
        IXmlLineInfo(xmlUrl);
	}
    private void IXmlLineInfo(string xmlurl)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlurl);    //加载xml
        XmlNode root = doc.SelectSingleNode("Web");  //获取xml最外层
        XmlNodeList nodeList = root.ChildNodes;//获取所有第二层
        foreach (XmlNode node in nodeList)
        {
            int id = int.Parse(node.Attributes["id"].Value);//获取第二层属性id对值
            string name = node.ChildNodes[0].InnerText;//获取第三层中的第一个信息
            string url = node.ChildNodes[1].InnerText;//获取第三层中的第二个信息

            Debug.Log(id + "--" + name + "--" + url);
        }
    }
}
