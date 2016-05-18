using UnityEngine;
using System.Collections;

public class WarningSignPointer : MonoBehaviour {

	public float minDistance = 4f;
	OrbitClosingIn closingDistance;
	public bool showWarning = false;
	SpriteRenderer render;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		closingDistance = GetComponentInParent<OrbitClosingIn> ();

	}
	
	// Update is called once per frame
	void Update () {
		WarningActive ();
	}

	public void WarningActive()
	{
		if (showWarning == false) 
		{
			if (closingDistance.transform.position.y < minDistance) 
			{
				render.enabled = true;
				showWarning = true;
			}
		}
	}

}
