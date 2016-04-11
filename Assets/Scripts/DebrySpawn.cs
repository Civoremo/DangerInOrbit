using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DebrySpawn : MonoBehaviour {

	public Button restartButton;
	public Text restartButtonText;
	public Text scoreText;
	public Text gameOverText;
	public static int score= 0;
	public GameObject DebryObject;
	public static int numberOfObjects = 0;
	public int numOfEnemys = 2;
	public static bool alive = true;

	GameObject debryObject;

	// Use this for initialization
	void Awake () {
		
		debryObject = DebryObject;
		SpawnDebry ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SpawnDebry ();
		ScoreTracker ();
	}

	public void SpawnDebry()
	{
		if (alive == true) {
			if (numberOfObjects <= 0) {
				numOfEnemys++;
				for (int x = 0; x < numOfEnemys; x++) {
					Instantiate (debryObject, new Vector3 (), Quaternion.identity);
					numberOfObjects++;
				}
			}
		}
	}

	public void ScoreTracker()
	{
		scoreText.text = "" + score;
		if (alive == true) {
			gameOverText.enabled = false;
			restartButton.enabled = false;
			restartButton.image.enabled = false;
			restartButtonText.enabled = false;

		}
		if (alive == false) {
			gameOverText.enabled = true;
			restartButton.enabled = true;
			restartButton.image.enabled = true;
			restartButtonText.enabled = true;
		}
	}

	public void ResetLevel()
	{
		SceneManager.LoadScene ("ProtoTypingScene");
		score = 0;
		numOfEnemys = 2;
		numberOfObjects = 0;
		scoreText.text = "" + score;
		alive = true;
	}
}
