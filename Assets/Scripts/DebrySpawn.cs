using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DebrySpawn : MonoBehaviour {

	public Button restartButton;
	public Text restartButtonText;
	public Text scoreText;
	public Text gameOverText;
	public Text livesText;
	public Text tryAgainText;
	public Text highScoreText;

	public static int highScore;
	SaveHighScore saveScore;
	public static int score = 0;
	public static int lives = 3;
	public GameObject DebryObject;
	public static int numberOfObjects = 0;
	public int numOfEnemysToCreate = 2;
	public static bool alive = true;
	bool savedScore = false;

	//int debrySpawned = 0;
	GameObject debryObject;
	GameObject createdObject;
	OrbitClosingIn ClosingSpeed;
	public float fallSpeed = 0.002f;
	Vector3 spawnPos = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		//lives = 3;
		saveScore = GetComponent<SaveHighScore> ();
		debryObject = DebryObject;
		saveScore.LoadHighScoreXML ();
		highScoreText.text = "" + highScore;
		//Debug.Log (CameraRotate.rotateSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
		ScoreTracker ();
		if (lives > 0) {
			SpawnDebry ();
		}
		ShotSelection ();
	}

	public void SpawnDebry()
	{
		if (alive == true) {
			if (numberOfObjects <= 0) {
				try
				{
					for (int x = 0; x < numOfEnemysToCreate; x++) {
						createdObject = Instantiate (debryObject, spawnPos, Quaternion.identity) as GameObject;
						ClosingSpeed = createdObject.GetComponentInChildren<OrbitClosingIn>();
						ClosingSpeed.FallingSpeed = fallSpeed;

						numberOfObjects++;
						//debrySpawned++;

						/*	toDo
						 * 	adjust for the speed to increase only once every Group Spawn of 5 or more
						 */
						if(numberOfObjects == 0)
						{
							fallSpeed += 0.0005f;
							CameraRotate.rotateSpeed.z += 0.1f;
							//debrySpawned = 0;
//							Debug.Log (CameraRotate.rotateSpeed.z);

						}

				}
				numOfEnemysToCreate++;
				}
				catch{
				}
			}
		}
	}

	public void ScoreTracker()
	{
		scoreText.text = "" + score;
		livesText.text = "" + lives;

		if (lives <= 0) {
			alive = false;
		}

		if (alive == true) {
			gameOverText.enabled = false;
			restartButton.enabled = false;
			restartButton.image.enabled = false;
			restartButtonText.enabled = false;
			tryAgainText.enabled = false;

		}
		// Game Over Prompt
		if (alive == false ) {
			gameOverText.enabled = true;
			tryAgainText.enabled = true;

			if (savedScore == false) {
				saveScore.SaveHighScoreXML ();
				savedScore = true;
			}
			//restartButton.enabled = true;
			//restartButton.image.enabled = true;
			//restartButtonText.enabled = true;
		}
	}

	public void ResetLevel()
	{
		SceneManager.LoadScene ("Test2");
		score = 0;
		lives = 3;
		numOfEnemysToCreate = 2;
		numberOfObjects = 0;
		scoreText.text = "" + score;
		CameraRotate.rotateSpeed.z = 0.4f;
		saveScore.LoadHighScoreXML ();
		highScoreText.text = "" + highScore;
		alive = true;
		savedScore = false;

	}

	public void ShotSelection()
	{
		if(Input.GetKeyDown (KeyCode.Alpha1))
		{
			FireBullet.ShotType = 0;
			Debug.Log ("Shot: " + FireBullet.ShotType);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			FireBullet.ShotType = 1;
			Debug.Log ("Shot: " + FireBullet.ShotType);
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			ResetLevel ();
		}
	}
}
