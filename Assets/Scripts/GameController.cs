using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Vector3 offset;
	public GameObject player;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		ball.transform.position = transform.position;
		player.transform.position = transform.position - offset;
	}
}
