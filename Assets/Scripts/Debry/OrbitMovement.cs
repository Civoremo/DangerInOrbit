using UnityEngine;
using System.Collections;

public class OrbitMovement : MonoBehaviour {

	public float RotationAroundOrbitSpeed = 0.5f;
	public SpriteRenderer debryRenderer;
	float angle;
	Vector3 startingAngle;
	int clockWise;

	// Use this for initialization
	void Awake() {
		RotationAroundOrbitSpeed = Random.Range (0.1f, 0.3f);
		angle = Random.Range (0,360);
		startingAngle = new Vector3 (0,0,angle);
		transform.eulerAngles = startingAngle;
		clockWise = Random.Range (0, 2);
		//Debug.Log (clockWise + "  " + RotationAroundOrbitSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MovingCloser ();
	}

	public void MovingCloser()
	{
		if (DebrySpawn.alive == true) {
			if (clockWise == 0) {
				transform.Rotate (0, 0, -RotationAroundOrbitSpeed, Space.Self);
			}
			if (clockWise == 1) {
				transform.Rotate (0, 0, RotationAroundOrbitSpeed, Space.Self);
				debryRenderer.flipX = true;
			}
		}
	}
}
