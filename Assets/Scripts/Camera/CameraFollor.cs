using UnityEngine;
using System.Collections;

public class CameraFollor : MonoBehaviour {
    private Transform m_Transform;
    private Transform m_PlayerTransform;
    // Use this for initialization
    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        m_Transform.position = m_PlayerTransform.position + new Vector3(0, 50, 0);

    }
}
