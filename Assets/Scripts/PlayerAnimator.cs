using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;

	private float activeTime;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		activeTime = 0;
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D> ().velocity.magnitude > 1) {
			activeTime += Time.deltaTime;
		} else {
			activeTime = 0;
		}
		int index = (int)(activeTime * framesPerSecond );
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites [index];
	}
}
