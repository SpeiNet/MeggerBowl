using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fallMultiplyer = 2.5f;
    public float lowJumpMultiplyer = 2f;

    public float speed;
    public float pullForce;

    [Range(0, 10)]
    public float jumpHeight;

    private Rigidbody rb;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       
        if (Input.GetButtonDown ("Jump") && jumpCount < 2) {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            jumpCount++;
        }

        if (isPlayerFalling ()) {
            // we are falling
            rb.AddForce (Vector3.up * Physics.gravity.y * (fallMultiplyer - 1) * Time.deltaTime);
        }

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
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log ("onCollison");
        if (collision.collider.tag == "Stadium") {
            Debug.Log ("hit rock bottom");
            jumpCount = 0;
        }
    }

    private bool isPlayerFalling ()
    {
        return rb.velocity.y < 0;
    }

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
}
