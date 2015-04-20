using UnityEngine;
using System.Collections;

public class LinearMover : MonoBehaviour {

	public float speed;
	public float timeToLive;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		Destroy (gameObject, timeToLive);
	}
}