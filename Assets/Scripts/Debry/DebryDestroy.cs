using UnityEngine;
using System.Collections;

public class DebryDestroy : MonoBehaviour {

	public GameObject powerBoost;
	public GameObject particleExplosion;
	OrbitClosingIn closingSignScript;
	//public GameObject signObject;
	public int health = 5;
	GameObject powerPickUp;

	Vector3 AngleFalling;
	OrbitMovement orbitMoveAngle;
	PowerUp powerUpAngle;

	// Use this for initialization
	void Start () {
		//closingSignScript = GetComponentInParent<OrbitClosingIn> ();
		//signObject = closingSignScript.createdSign;
		//powerPickUp = powerBoost;
	}
	
	// Update is called once per frame
	void Update () {
	
		Destroy ();
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Planet") {
			Instantiate (particleExplosion, transform.position, Quaternion.identity);
			Sounds.soundSource.clip = Sounds.soundClips [1];
			Sounds.soundSource.Play ();
			Destroy (transform.parent.parent.gameObject);
			//Destroy (signObject);
			//DebrySpawn.alive = false;
			DebrySpawn.numberOfObjects--;
			DebrySpawn.lives--;
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			//Instantiate (particleExplosion, transform.position, Quaternion.identity);
			Sounds.soundSource.clip = Sounds.soundClips [1];
			Sounds.soundSource.Play ();
			Destroy (other.gameObject);
			DebrySpawn.score++;
			health--;
			FireBullet.bulletAmount--;
		}
	}

	public void Destroy()
	{
		if (health <= 0) 
		{
			powerPickUp = Instantiate (powerBoost, transform.position, Quaternion.identity) as GameObject;
			WorldAngle ();
			//powerUpAngle = GetComponent<PowerUp> ();
			//powerUpAngle.angle = AngleFalling;
			//Debug.Log (AngleFalling);
			Instantiate (particleExplosion, transform.position, Quaternion.identity);
			Sounds.soundSource.clip = Sounds.soundClips [1];
			Sounds.soundSource.Play ();
			Destroy (transform.parent.parent.gameObject);
			DebrySpawn.numberOfObjects--;
		}
	}

	public void WorldAngle()
	{
		orbitMoveAngle = GetComponentInParent<OrbitMovement> ();
		powerPickUp.transform.eulerAngles = orbitMoveAngle.transform.eulerAngles;
		//Debug.Log (AngleFalling);
	}
}
