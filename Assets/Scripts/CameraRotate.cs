using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public static float angle;
	public static Vector3 direction;
	public static Vector3 rotateSpeed = new Vector3 (0, 0, 0.4f);

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
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) ) {
			transform.Rotate (rotateSpeed, Space.Self);
			angle = transform.eulerAngles.z;
			direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
			//Debug.Log (direction + "  " + angle);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (-rotateSpeed, Space.Self);
			angle = transform.eulerAngles.z;
			direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
			//Debug.Log (direction + "  " + angle);
		}
	}
}
