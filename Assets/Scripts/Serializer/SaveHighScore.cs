using UnityEngine;
using System.Collections;
using System.IO;

public class SaveHighScore : MonoBehaviour {

	string path;
	int currentScore;
	HighScore hScore = new HighScore();
	HighScore bestScore = new HighScore();

	// Use this for initialization
	void Start () {
		path = Application.dataPath + "/HighScore.xml";
		bestScore = XMLObjectSerializer.Deserialize<HighScore> (path);
	}

	public void SaveHighScoreXML()
	{
		hScore.highScore = DebrySpawn.score;
		path = Application.dataPath + "/HighScore.xml";
		if (hScore.highScore > bestScore.highScore) {
			XMLObjectSerializer.Serialize (hScore, path);
		}
	}

	public void LoadHighScoreXML()
	{
		path = Application.dataPath + "/HighScore.xml";
		bestScore = XMLObjectSerializer.Deserialize<HighScore> (path);
		DebrySpawn.highScore = bestScore.highScore;
	}
}
