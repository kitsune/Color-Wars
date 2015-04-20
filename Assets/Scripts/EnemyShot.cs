using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {
	public int damage;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Player") {
			other.SendMessageUpwards("Damage", damage);
			Destroy (gameObject);
		}
		if (other.tag == "Boundry") {
			Destroy (gameObject);
		}
	}
}
