using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
    private Transform m_Transform;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isDie = false;//死亡状态 false活  true死
    private MissileManager m_MissileManager;
    private GameObject Smoke03;
    private GameManager m_GameManager;
    private int rewardNum = 0;
    public bool IsLeft
    {
        get{    return isLeft;}
        set{    isLeft = value;}
    }

    public bool IsRight
    {
        get {   return isRight; }
        set {   isRight = value;}
    }

    public int Rotate
    {
        get
        {
            return rotate;
        }

        set
        {
            rotate = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    private int speed;
    private int rotate;

    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_MissileManager = GameObject.Find("MissileManager").GetComponent<MissileManager>();
        Smoke03 = Resources.Load<GameObject>("Smoke03");
        m_GameManager = GameObject.Find("UI Root").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDie == false)
        {
            m_Transform.Translate(Vector3.forward * speed);
            if (IsLeft)
            {
                m_Transform.Rotate(Vector3.up * -1 * rotate);
            }

            if (IsRight)
            {
                m_Transform.Rotate(Vector3.up * 1 * rotate);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Borders")
        {
            isDie = true;
            m_GameManager.OverGame();
        }
        if (other.tag == "Missile")
        {
            isDie = true;
            m_GameManager.OverGame();
            GameObject.Instantiate(Smoke03, m_Transform.position, Quaternion.identity);
            m_MissileManager.StopCreate();
            GameObject.Destroy(other.gameObject);
            gameObject.SetActive(false);
        }

        if (other.tag == "Reward")
        {
            rewardNum++;
            m_GameManager.UpdateScoreLabel(rewardNum);
            GameObject.Destroy(other.gameObject);
        }
    }
}
