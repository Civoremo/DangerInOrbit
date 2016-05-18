using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed = 1f;
	Vector3 bulletPos;
	public Vector3 bulletDirection;
	public float angle;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		bulletPos = transform.position;
		SetDirection ();
		//Debug.Log (CameraRotate.direction + "  " + bulletDirection + "  " + angle);
	}
	
	// Update is called once per frame
	void Update () {
		BulletMove ();
	}

	/*	
	 * angle value is passed in with FireBullet Script
	 */
	public void SetDirection()
	{
		direction = new Vector3(-Mathf.Sin((Mathf.PI/180) * angle), Mathf.Cos(((Mathf.PI/180) * angle)), 0);
		bulletDirection = direction;
	}

	public void BulletMove()
	{
		
		bulletPos += bulletDirection * Time.deltaTime * speed;
		transform.position = bulletPos;
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (gameObject);
		FireBullet.bulletAmount--;
	}
}
