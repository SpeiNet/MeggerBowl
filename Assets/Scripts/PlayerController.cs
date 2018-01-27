﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float pullForce;
	public float jumpHeight;

    private Rigidbody rb;
	private int jumpCount = 0;

    private Vector3 GetMovementViaInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        return new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    private void PullGameBallIfFire2Pressed()
    {
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Space pressed");
            GameObject gameBall = GameObject.Find("GameBall");
            Vector3 pullDirection = (transform.position - gameBall.transform.position).normalized;

            gameBall.transform.GetComponent<Rigidbody>().velocity += pullDirection * (pullForce * Time.deltaTime);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(GetMovementViaInput() * speed);

        PullGameBallIfFire2Pressed();

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Feuer Frei");
        }

        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Feuer Zwei");
        }

		if (Input.GetButton ("Fire3")) {
			Debug.Log ("Feuer3");
		}

		if (Input.GetButtonDown ("Jump") && jumpCount < 2) {
			rb.AddForce (jumpHeight * Vector3.up);
			jumpCount++;
		}
    }

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("onCollison");
		if (collision.collider.tag == "Stadium") {
			Debug.Log ("hit rock bottom");
			jumpCount = 0;
		}
	}
}
