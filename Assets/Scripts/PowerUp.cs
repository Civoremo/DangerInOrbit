using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	float powerSpeedUp = 0.7f;
	public float speed = 1f;
	public Vector3 powerPos;
	public Vector3 direction;
	public float angle;
	// Use this for initialization
	void Start () {
		//FireBullet.powerTimer = powerSpeedUp;
		powerPos = transform.position;
		//direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
		direction = new Vector3(0,1,0);
	}
	
	// Update is called once per frame
	void Update () {
	
		Movement ();
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "mainCharacter") 
		{
			//FireBullet.powerTimer = powerSpeedUp;
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Planet") 
		{
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "mainCharacter") 
		{
			//FireBullet.powerTimer = powerSpeedUp;
			//transform.eulerAngles = angle;
			Destroy (gameObject);
		}
	}


	public void Movement()
	{
		transform.position -= direction * 0.2f * Time.deltaTime;
		//powerPos -= direction * speed * Time.deltaTime;
		//transform.position = powerPos;
	}
}
