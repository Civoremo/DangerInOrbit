using UnityEngine;
using System.Collections;

public class OrbitClosingIn : MonoBehaviour {

	public float minFallSpeed = 0.0005f;
	public float maxFallSpeed = 0.0015f;
	public float minDistanceAway = 5.5f;
	public float maxDistanceAway = 7f;
	public float FallingSpeed;
	public SpriteRenderer signRenderer;
	public Transform center;
	Vector3 posDebry;
	public float distance;
	bool alive = true;

	// Use this for initialization
	void Start () {
		FallingSpeed = Random.Range (minFallSpeed, maxFallSpeed);
		posDebry = transform.localPosition;
		distance = Random.Range (minDistanceAway, maxDistanceAway);
		posDebry.y = distance;
		transform.position = posDebry;
		signRenderer.enabled = false;
		//Debug.Log (FallingSpeed + "  " + distance);
	}
	
	// Update is called once per frame
	void Update () {
	
		MovingIn ();
		ClosingSignIndicator ();
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

	public void ClosingSignIndicator()
	{
		if (posDebry.y < 4f) {
			if (alive == true) {				
				signRenderer.enabled = true;
				alive = false;
			}
		}
	}
}

