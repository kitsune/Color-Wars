using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{
	public float maxHealth;

	private float curHealth;

	public void Start() {
		curHealth = maxHealth;
	}

	public void Damage(int damageTaken) {
		curHealth -= damageTaken;
		if (curHealth <= 0) {
			Kill();
		}
	}

	public void Kill() {
		Destroy (gameObject);
	}
}

