using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public GameObject projectile;

	GameObject bullet;
	Vector3 shootPos;
	public static int bulletAmount = 0;

	// Use this for initialization
	void Start () {
		bullet = projectile;
	}
	
	// Update is called once per frame
	void Update () {
		FireProjectile ();
	}

	public void FireProjectile()
	{
		if (bulletAmount < 3 && DebrySpawn.alive == true) {
			if (Input.GetButtonDown ("Jump")) {
				shootPos = transform.position;
				Instantiate (bullet, shootPos, Quaternion.identity);
				bulletAmount++;
			}
		}
	}
}
