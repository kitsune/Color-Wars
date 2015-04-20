using UnityEngine;
using System.Collections;

public class GreenAIController : Enemy {

	public float speed;
	public Transform player;
	public float maxRange;
	public float minRange;
	public Transform bulletSpawn;
	public float fireRate;
	public GameObject shot;
	public float angluarHold;
	public GameObject confirmBox;

	private float angle;
	private Vector2 hDirection;
	private float nextFire = 0.0f;
	private float nextMovement = 0.0f;
	private GameObject intro;

	void Start() {
		base.Start ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		intro = GameObject.FindGameObjectWithTag("Intro");
	}
	
	void FixedUpdate (){
		if (intro.activeSelf || confirmBox.activeSelf)
			return;
		var offset = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
		angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler(0, 0, angle);

		RaycastHit2D hit = Physics2D.Raycast (bulletSpawn.position, offset, 7.5f);

		if (hit.collider != null) {
			if (hit.collider.tag == "Player") {
				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate;
					Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation);
				}
				float distance = offset.magnitude;
				Vector2 direction = offset.normalized;
				if (distance > maxRange) {
					GetComponent<Rigidbody2D> ().AddForce (direction * speed);
				} else if (distance < minRange) {
					GetComponent<Rigidbody2D> ().AddForce (direction * speed * -1f);
				}
				if (Time.time > nextMovement) {
					nextMovement = Time.time + (Random.value * angluarHold);
					float hVel = Random.value - 0.5f;
					hDirection = Quaternion.AngleAxis (90, Vector3.forward) * (Vector3)(direction);
					hDirection = hDirection * hVel;
					hDirection.Normalize();
				}
				GetComponent<Rigidbody2D> ().AddForce (hDirection * speed);
			}
		}
	}
}
