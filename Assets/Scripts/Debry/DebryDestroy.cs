using UnityEngine;
using System.Collections;

public class DebryDestroy : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			Destroy (transform.parent.parent.gameObject);
			DebrySpawn.score++;
			DebrySpawn.numberOfObjects--;
		}
		if (other.gameObject.tag == "Planet") {
			Destroy (transform.parent.parent.gameObject);
			DebrySpawn.alive = false;
			DebrySpawn.numberOfObjects--;
		}
	}
}
