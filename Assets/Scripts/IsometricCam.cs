using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour {
	public GameObject target;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.transform.position;
	}

	void LateUpdate()
	{
		Vector3 desiredPosition = target.transform.position + offset;
		transform.position = desiredPosition;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
