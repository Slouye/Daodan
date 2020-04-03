using UnityEngine;
using System.Collections;

public class ShipManager : MonoBehaviour {
    private GameObject model;
    private GameObject player;
	// Use this for initialization
	void Awake() {
        string ship = PlayerPrefs.GetString("PlayerName");
        int speed = PlayerPrefs.GetInt("PlayerSpeed");
        int rotate = PlayerPrefs.GetInt("PlayerRotate");

        model = Resources.Load<GameObject>(ship);
        player = GameObject.Instantiate(model, Vector3.zero, Quaternion.identity) as GameObject;
        Ship myShip = player.AddComponent<Ship>();
        myShip.Speed = speed;
        myShip.Rotate = rotate;
        player.tag = "Player";
        player.GetComponent<Transform>().localScale = new Vector3(2, 2,2);

    }
	
}
