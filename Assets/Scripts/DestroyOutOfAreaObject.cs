using UnityEngine;
using System.Collections;

public class DestroyOutOfAreaObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
			FireBullet.bulletAmount--;
		}
	}
}
