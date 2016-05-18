using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public float cloudSpeed;
	Vector3 rotationSpeed = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		rotationSpeed.z = cloudSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		MoveClouds ();
	}

	public void MoveClouds()
	{
		transform.Rotate (rotationSpeed, Space.Self);
	}
}
