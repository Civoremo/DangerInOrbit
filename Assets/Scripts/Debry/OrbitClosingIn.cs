using UnityEngine;
using System.Collections;

public class OrbitClosingIn : MonoBehaviour {

	public float FallingSpeed = 0.002f;
	Vector3 posDebry;
	float distance;

	// Use this for initialization
	void Awake () {
		FallingSpeed = Random.Range (0.002f, 0.005f);
		posDebry = transform.localPosition;
		distance = Random.Range (3.2f, 5f);
		posDebry.y = distance;
		transform.position = posDebry;

		//Debug.Log (FallingSpeed + "  " + distance);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		MovingIn ();
	}

	public void MovingIn()
	{
		if (DebrySpawn.alive == true) {
			if (posDebry.y >= 0) {
				posDebry.y -= FallingSpeed;
			}
			transform.localPosition = posDebry;
		}
	}
}
