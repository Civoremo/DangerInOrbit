using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	public AudioClip[] clips;

	public static AudioSource soundSource;

	public static AudioClip[] soundClips;

	int tempNum;

	// Use this for initialization
	void Start () {
		soundClips = clips;
		soundSource = GetComponent<AudioSource> ();
		soundSource.clip = clips [0];
		tempNum = DebrySpawn.numberOfObjects;
	}
	
	// Update is called once per frame
	void Update () {
		PlayOnDestroy ();
	}

	public void SoundPlayer(int clipIndex)
	{
		soundSource.clip = clips [clipIndex];
		soundSource.Play ();
		Debug.Log ("Sound: " + clipIndex);
	}

	public void PlayOnDestroy()
	{
		if(DebrySpawn.numberOfObjects < tempNum)
		{
			SoundPlayer (1);
		}
	}
}
