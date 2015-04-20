using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour, IDamageable {

	//Public variables
	public float moveSpeed;
	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate = 0.5f;
	public float ammoRate = 1f;
	public int maxAmmo = 10;
	public int maxHealth;
	public GameObject[] healthIcons;
	public GameObject[] ammoIcons;

	//Private Variables
	private Vector3 moveDirection;
	private float angle;
	private float nextFire = 0.0f;
	private float nextAmmo = 0.0f;
	private int ammo = 0;
	private int curHealth;
	private GameObject intro;
	private GameObject gameover;
	private GameObject victory;
	private GameObject confirmBox;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
		intro = GameObject.FindGameObjectWithTag("Intro");
		gameover = GameObject.FindGameObjectWithTag("End");
		victory = GameObject.FindGameObjectWithTag ("Finish");
		confirmBox = GameObject.FindGameObjectWithTag ("Quit");
		victory.SetActive (false);
		confirmBox.SetActive (false);
		gameover.SetActive (false);
		foreach (GameObject brush in ammoIcons) {
			brush.SetActive(false);
		}
	}

	void Update() {
		if (victory.activeSelf || confirmBox.activeSelf) {
			return; //We are done here
		}
		if (Time.time > nextAmmo) {
			nextAmmo = Time.time + ammoRate;
			if (ammo < maxAmmo) {
				AddAmmo();
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("escape"))
			confirmBox.SetActive (true);
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			victory.SetActive(true);
			victory.SendMessageUpwards ("setEnd");
		}
		if (victory.activeSelf || confirmBox.activeSelf) {
			return; //We are done here
		}
		if (intro.activeSelf) {
			if (Input.GetButton ("Fire1")) {
				intro.SetActive(false);
			}
			return;
		}
		Rotate ();
		HandleInput ();
	}

	public void Damage(int damageTaken) {
		curHealth -= damageTaken;
		healthIcons [curHealth].SetActive (false);
		Debug.Log (curHealth);
		if (curHealth <= 0) {
			curHealth = 0;
			Kill();
		}
	}

	public bool AddHealth() {
		if (curHealth < maxHealth) {
			healthIcons[curHealth].SetActive(true);
			curHealth ++;
			return true;
		}
		return false;
	}

	public bool AddAmmo () {
		if (ammo < maxAmmo) {
			ammoIcons[ammo].SetActive(true);
			ammo++;
			return true;
		}
		return false;
	}

	public bool SubAmmo () {
		if (ammo > 0) {
			ammoIcons[ammo - 1].SetActive(false);
			ammo--;
			return true;
		}
		return false;
	}

	public void Kill() {
		gameover.SetActive (true);
		gameObject.SetActive (false);
		gameover.SendMessageUpwards ("setEnd");
	}

	private void HandleInput() {
		Vector2 direction = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		direction.Normalize ();
		GetComponent<Rigidbody2D>().AddForce (direction * moveSpeed);

		if (Input.GetButton ("Fire1") && Time.time > nextFire && ammo > 0) {
			SubAmmo();
			nextFire = Time.time + fireRate;
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}

	private void Rotate () {
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
