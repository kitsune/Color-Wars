using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = player.position;
		temp.z = transform.position.z;
		transform.position = temp;
	}
}
