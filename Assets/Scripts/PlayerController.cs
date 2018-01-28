using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	public string horizontalCtrl;
	public string verticalCtrl;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis (horizontalCtrl);
		float moveVertical = Input.GetAxis (verticalCtrl);

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//transform.Translate (Time.deltaTime * movement);

		rb.AddForce (movement * speed);
	}
}
