using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public float minWait;
	public GameObject postMessage;

	public float end;
	// Use this for initialization
	void Start () {
		end = Time.time + minWait;
	}

	void setEnd() {
		end = Time.time + minWait;
	}

	// Update is called once per frame
	void Update () {
		if (!postMessage.activeSelf && Time.time > end) {
			postMessage.SetActive(true);
		}
		if (Input.GetButton ("Fire1") && Time.time > end) {
			Application.LoadLevel(0);
		}
	}
}
