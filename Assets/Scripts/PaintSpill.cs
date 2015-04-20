using UnityEngine;
using System.Collections;

public class PaintSpill : MonoBehaviour {

	public float ammoRate;
	public int maxAmmo;
	public MovementController player;

	private float nextAmmo = 0f;
	private float nextHealth = 0f;
	private int curAmmo;
	private int curHealth;
	private bool active = false;

	// Use this for initialization
	void Start () {
		curAmmo = maxAmmo;
		curHealth = maxAmmo / 2;
		player = (MovementController)FindObjectOfType (typeof(MovementController));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAmmo && active && curAmmo > 0) {
			nextAmmo = Time.time + ammoRate;
			if (player.AddAmmo()) {
				curAmmo--;
			}
		}
		if (Time.time > nextHealth && active && curHealth > 0) {
			nextHealth = Time.time + (ammoRate * 2);
			if (player.AddHealth()) {
				curHealth--;
			}
		}
		if (curAmmo <= 0 && curHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			active = false;
		}
	}
}
