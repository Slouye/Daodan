using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {
    private GameObject Left;
    private GameObject Right;
    private Ship m_Ship;

   
    // Use this for initialization
    void Start () {
        Left = GameObject.Find("Left");
        Right = GameObject.Find("Right");
        m_Ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
        UIEventListener.Get(Left).onPress = LeftPress;
        UIEventListener.Get(Right).onPress = RightPress;
    }

    private void LeftPress(GameObject go,bool isPress)
    {
        if (isPress)
        {
            Debug.Log("左");
            m_Ship.IsLeft = true;
        }
        else
        {
            Debug.Log("左结束");
            m_Ship.IsLeft = false;
        }
    }

    private void RightPress(GameObject go, bool isPress)
    {
        if (isPress)
        {
            Debug.Log("右");
            m_Ship.IsRight = true;
        }
        else
        {
            Debug.Log("右结束");
            m_Ship.IsRight = false;
        }
    }

 
}
