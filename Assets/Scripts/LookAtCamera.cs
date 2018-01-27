using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}

	void LateUpdate()
	{
		transform.LookAt (target.transform);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
