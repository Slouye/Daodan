using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    private Transform m_Transform;
    private Transform play_Transform;
    private Vector3 normalForward = Vector3.forward;
    private GameObject Smoke03;
    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        play_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Smoke03 = Resources.Load<GameObject>("Smoke03");
    }
	
	// Update is called once per frame
	void Update () {
        m_Transform.Translate(Vector3.forward);

        //导弹跟踪飞机
        Vector3 dir = play_Transform.position - m_Transform.position;
        normalForward = Vector3.Lerp(normalForward, dir, Time.deltaTime);
        m_Transform.rotation = Quaternion.LookRotation(normalForward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Missile")
        {
            GameObject.Instantiate(Smoke03, m_Transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
