using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
	void OnCollisionEnter(Collision other) {
		Debug.Log ("Collision");
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Spielball") {
			Vector3 offset = new Vector3 (0, 0, 3);
			other.transform.position = other.transform.position - offset;
		}
	}
}
