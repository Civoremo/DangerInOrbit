using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public GameObject projectile;

	float cameraAngle;
	GameObject bullet;
	Vector3 shootPos;
	public static int ShotType = 0;
	public static int bulletAmount = 0;
	float shotTimer = 0f;
	bool shotReady = true;
	public static float powerTimer = 0f;
	bool powerReady = false;

	BulletMovement movementDir;
	GameObject createdBullet;

	AudioSource bulletSoundSrc;

	// Use this for initialization
	void Start () {
		bullet = projectile;
		bulletSoundSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		FireProjectile (ShotType);
		ShotTiming ();
	}

	public void ShotTiming()
	{
		if (shotTimer > 0) {
			shotTimer -= Time.deltaTime;
			shotReady = false;
			//Debug.Log (shotTimer);
		}
		if (shotTimer <= 0) {
			shotReady = true;
		}
	}

	public void FireProjectile(int selectNum)
	{
		switch (selectNum) {
		case 0:	// single bullet
			try{
				if (bulletAmount < 3 && DebrySpawn.alive == true) {
					if (Input.GetKey (KeyCode.Space)) {
						
						if(shotReady == true)
						{
							shotTimer = 0.7f;
							cameraAngle = CameraRotate.angle;
							shootPos = transform.position;
							createdBullet = Instantiate (bullet, shootPos, Quaternion.identity) as GameObject;
							movementDir = createdBullet.GetComponent<BulletMovement>();
							movementDir.angle = 0f + cameraAngle;
							bulletAmount++;
							bulletSoundSrc.clip = Sounds.soundClips[0];
							bulletSoundSrc.Play();
						}
					}
				}
			}
			catch{
			}
			break;
		case 1: // spread shot -- 3 bullets 
			try{
				if (bulletAmount < 9 && DebrySpawn.alive == true) 
				{
					if (Input.GetKey (KeyCode.Space)) 
					{
						/* 	take the current camera angle to determine the angle of the bullets
						*	cameraAngle is passed into movementDir.angle -- located in BulletMovement Script
						*/
						if(shotReady == true)
						{
							shotTimer = 1f;
						cameraAngle = CameraRotate.angle;

						for(int x = 0; x < 3; x++)
						{							
							if(x == 0)
							{
								shootPos = transform.position;
								createdBullet = Instantiate (bullet, shootPos, Quaternion.identity) as GameObject;
								movementDir = createdBullet.GetComponent<BulletMovement>();
								movementDir.angle = 0f + cameraAngle;
								bulletAmount++;
							}
							if(x == 1)
							{
								shootPos = transform.position;
								createdBullet = Instantiate (bullet, shootPos, Quaternion.identity) as GameObject;
								movementDir = createdBullet.GetComponent<BulletMovement>();
								movementDir.angle = 5f + cameraAngle;
								bulletAmount++;
							}
							if(x == 2)
							{
								shootPos = transform.position;
								createdBullet = Instantiate (bullet, shootPos, Quaternion.identity) as GameObject;
								movementDir = createdBullet.GetComponent<BulletMovement>();
								movementDir.angle = -5f + cameraAngle;
								bulletAmount++;
							}
						}
						bulletSoundSrc.clip = Sounds.soundClips[0];
						bulletSoundSrc.Play();
						}
					}
				}
			}
			catch{
			}
			break;
		default:
			break;
		}
	}
}
