using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour {
    private GameObject m_StartPanel;
    private GameObject m_SetingPanel;
    private GameObject m_ButtonSeting;
    private GameObject m_ButtonSprite;
    private GameObject m_ButtonPlay;

    // Use this for initialization
    void Start () {
        m_StartPanel = GameObject.Find("StartPanel");
        m_SetingPanel = GameObject.Find("SetingPanel");

        m_ButtonSeting = GameObject.Find("Seting");
        m_ButtonSprite = GameObject.Find("Sprite");
        m_ButtonPlay = GameObject.Find("Play");
       
        UIEventListener.Get(m_ButtonSeting).onClick = buttonSetingClick;
        UIEventListener.Get(m_ButtonSprite).onClick = buttonSpriteClick;
        UIEventListener.Get(m_ButtonPlay).onClick = buttonPlayClick;


        m_SetingPanel.SetActive(false);
    }

    private void buttonSetingClick(GameObject go)
    {
        if (m_SetingPanel.activeSelf == false)
        {
            m_SetingPanel.SetActive(true);
        }
    }

    private void buttonSpriteClick(GameObject go)
    {
        m_SetingPanel.SetActive(false);
        
    }

    private void buttonPlayClick(GameObject go)
    {
        SceneManager.LoadScene("Game");

    }
   
    public void SetButtonPlayClick(int state)
    {
        if (state == 1)
        {
            m_ButtonPlay.SetActive(true);
        }
        else
        {
            m_ButtonPlay.SetActive(false);
        }
    }




}
