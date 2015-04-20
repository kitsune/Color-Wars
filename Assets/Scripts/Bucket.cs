using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject spill;

	private int state = 0;
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}

	void Update() {
		spriteRenderer.sprite = sprites [state];
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && state == 0) {
			state = 1;
			Instantiate(spill, transform.position, transform.rotation);
		}
	}
}
