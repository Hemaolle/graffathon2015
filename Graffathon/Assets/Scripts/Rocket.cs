using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RocketNet;
public class Rocket : Singleton<Rocket> {
	Track testTrack;
	Device device;
	public float speed;
	public float bpm;
	private bool playing;
	private int row;
	float startTime;
	private int startRow;
	private Dictionary<string, Track> tracks = new Dictionary<string, Track>();

	// Use this for initialization
	void Start () {
		device = new Device("", false);
		device.Connect();
		device.SetRow = SetRow;
		device.Pause = SetPause;
		device.IsPlaying = Playing;
	}
	
	// Update is called once per frame
	void Update () {
//		int currentRow;
		if (playing)
			row = ((int)((Time.time - startTime) * (bpm / 60f) + startRow));
//		else 
//			currentRow = 0;
		device.Update(row);
		Debug.Log(row);
	}

	void SetRow(int row) {
		if(!playing)
			this.row = row;
	}

	void SetPause(bool pause) {
		playing = !pause;
		if(playing) {
			startTime = Time.time;
			startRow = row;
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
