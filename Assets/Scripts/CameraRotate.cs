using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public static float angle;
	public static Vector3 direction;

	// Use this for initialization
	void Start () {
		angle = transform.eulerAngles.z;
		direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		RotateCamera ();
	}

	public void RotateCamera()
	{
		if (Input.GetButton ("Fire1")) {
			transform.Rotate (0, 0, 1, Space.Self);
			angle = transform.eulerAngles.z;
			direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
			//Debug.Log (direction + "  " + angle);
		}
		if (Input.GetButton ("Fire2")) {
			transform.Rotate (0, 0, -1, Space.Self);
			angle = transform.eulerAngles.z;
			direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
			//Debug.Log (direction + "  " + angle);
		}
	}
}
