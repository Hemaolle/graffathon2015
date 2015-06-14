using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RocketNet;
public class Rocket : Singleton<Rocket> {

	public float speed;
	public float bpm;
	public bool player;
	public string trackPath = "Rocket/Tracks/";
	public float delay = 1;
	public AudioSource audioSource;

	Track testTrack;
	Device device;
	private bool playing;
	public float row;
	float startTime;
	private float startRow;
	private Dictionary<string, Track> tracks = new Dictionary<string, Track>();

	// Use this for initialization
	void Start () {
		device = new Device(Application.dataPath + "/" + trackPath, player);
		if (!player)
			device.Connect ();
		else {
			startTime = delay;
		}
		device.SetRow = SetRow;
		device.Pause = SetPause;
		device.IsPlaying = Playing;
	}
	
	// Update is called once per frame
	void Update () {
		if ((playing || player) && Time.time > delay)
			row = ((Time.time - startTime) * (bpm / 60f) + startRow);
		device.Update((int)row);
//		Debug.Log(row);
	}

	void SetRow(int row) {
		if(!playing)
			this.row = row;
	}

	void SetPause(bool pause) {
		playing = !pause;
		if (playing) {
			startTime = Time.time;
			startRow = row;
			audioSource.time = row / bpm*60;
			Debug.Log ("audio time " + audioSource.time);
			audioSource.Play ();
		} else {
			audioSource.Pause();
		}
		Debug.LogError("pause " + pause);
	}

	bool Playing() {
		return playing;
	}

	public float GetValue(string trackName) {
		if (!tracks.ContainsKey(trackName)) {
			tracks.Add(trackName, device.GetTrack(trackName));
		}
		return tracks[trackName].GetValue(row);
	}


	void OnDestroy() {
		device.Dispose();
	}
}
