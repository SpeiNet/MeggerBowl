using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSouth	 : MonoBehaviour {

	public GameObject ball;

	public int scoreNorth;

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
			scoreNorth += 1;
		}
	}

	public void Update()
	{
		GameObject.Find ("Points_North_Site").GetComponent<TextMesh> ().text = scoreNorth + "";
	}
}
