using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalNorth : MonoBehaviour {

	public GameObject ball;

	public int scoreSouth;

	Vector3 originalPosition;

	void Start()
	{
		originalPosition = ball.transform.position;
	}

	void OnTriggerEnter(Collider other) 
	{
		//Debug.Log (ball.gameObject.tag);
		if (other.gameObject.tag == "SpielBall") {
			ball.transform.position = originalPosition;
			scoreSouth += 1;
		}
	}

	public void Update()
	{
		GameObject.Find ("Points_South_Site").GetComponent<TextMesh> ().text = scoreSouth + "";
	}
}
