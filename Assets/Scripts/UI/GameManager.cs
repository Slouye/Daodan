using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private GameObject m_GamePanel;
    private GameObject m_OverPanel;
    private GameObject m_ButtonControl;
    private GameObject m_ButtonReset;
    private UILabel m_StarNum;
    private UILabel label_Time;
    private int time;

    public int Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
            UpdateTimeAndStars(Time);
        }
    }

    private UILabel hieghtScore;
    private UILabel starNum;
    private UILabel timeNum;
    // Use this for initialization
    void Start () {
        m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");
        m_ButtonControl = GameObject.Find("ButtonControl");
        m_ButtonReset = GameObject.Find("Reset");
        m_StarNum = GameObject.Find("StarNum1").GetComponent<UILabel>();
        label_Time = GameObject.Find("Time1").GetComponent<UILabel>();
        label_Time.text = "0:0";

        hieghtScore = GameObject.Find("Score/ScoreNum").GetComponent<UILabel>();
        starNum = GameObject.Find("Star/StarNum").GetComponent<UILabel>();
        timeNum = GameObject.Find("Time/TimeNum").GetComponent<UILabel>();


        UIEventListener.Get(m_ButtonReset).onClick = ButtonResetClick;
        m_StarNum.text = "0";
        StartCoroutine("AddTime");
        m_OverPanel.SetActive(false);
    }

    private void ButtonResetClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }

    public void UpdateScoreLabel(int score)
    {
        m_StarNum.text = score.ToString();
    }



    public void OverGame()
    {
        m_OverPanel.SetActive(true);
        m_ButtonControl.SetActive(false);
        ShopAddTime();
        SetOverPaneInfo();
    }

    IEnumerator AddTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Time++;
        }
    }

    private void UpdateTimeAndStars(int t)
    {
        if (t < 60)
        {
            label_Time.text = "0:" + t;
        }
        else
        {
            label_Time.text = t / 60+ ":" + t % 60;
        }
    }

    private void ShopAddTime()
    {
        StopCoroutine("AddTime");
    }

    private void SetOverPaneInfo()
    {
        int t = int.Parse(m_StarNum.text);
        starNum.text = "+" + t * 10;
        timeNum.text = "+" + time;
        int tempHeightScore = t * 10 + time;
        hieghtScore.text = tempHeightScore.ToString();

        PlayerPrefs.SetInt("HeightScore", tempHeightScore);
        PlayerPrefs.SetInt("GoldNum", t * 10);
    }

}
