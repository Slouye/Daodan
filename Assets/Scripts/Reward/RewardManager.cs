using UnityEngine;
using System.Collections;

public class RewardManager : MonoBehaviour {
    private GameObject prefab_reward;
    private Transform m_Transform;

    private int rewardCount = 0;
    private int rewardMaxCount = 3;
    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        prefab_reward = Resources.Load<GameObject>("reward");
        InvokeRepeating("CreateReward", 5, 5);
    }

    public void StopCreate()
    {
        CancelInvoke();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateReward()
    {
        if (rewardCount < rewardMaxCount)
        {
            Vector3 pos = new Vector3(Random.Range(550,-390),0, Random.Range(-600,530));
            GameObject.Instantiate(prefab_reward, pos, Quaternion.identity, m_Transform);
            rewardCount++;
            Debug.Log("目前"+ rewardCount);
        }
    }

    public void RewardCountDown()
    {
        rewardCount--;
        Debug.Log("可以生成新对了");
    }
}
