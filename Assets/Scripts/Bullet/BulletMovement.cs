using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed = 1f;
	Vector3 bulletPos;
	Vector3 bulletDirection;

	// Use this for initialization
	void Start () {
		bulletPos = transform.position;
		bulletDirection = CameraRotate.direction;
	}
	
	// Update is called once per frame
	void Update () {
		BulletMove ();
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
