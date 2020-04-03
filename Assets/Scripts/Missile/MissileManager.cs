using UnityEngine;
using System.Collections;

public class MissileManager : MonoBehaviour {
    private Transform m_Transform;
    private Transform[] createPoints;
    private GameObject prefab_Missile_3;
    
    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        createPoints = GameObject.Find("CreatePoints").GetComponent<Transform>().GetComponentsInChildren<Transform>();
        prefab_Missile_3 = Resources.Load<GameObject>("Missile_3");
        InvokeRepeating("CreateMissile", 3, 5);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopCreate()
    {
        CancelInvoke();
    }

    /// <summary>
    /// 导弹生成
    /// </summary>
    private void CreateMissile()
    {
        int index = Random.Range(0, createPoints.Length);
        GameObject.Instantiate(prefab_Missile_3, createPoints[index].position, Quaternion.identity, m_Transform);
    }



}
