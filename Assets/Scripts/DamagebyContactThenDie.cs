using UnityEngine;
using System.Collections;

public class DamagebyContactThenDie : MonoBehaviour {

	public int damage;

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Enemy") {
			other.SendMessageUpwards("Damage", damage);
			Destroy (gameObject);
		}
		if (other.tag == "Boundry") {
			Destroy (gameObject);
		}
	}
}
