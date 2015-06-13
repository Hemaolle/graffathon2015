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
	private float row;
	float startTime;
	private float startRow;
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
			row = ((Time.time - startTime) * (bpm / 60f) + startRow);
//		else 
//			currentRow = 0;
		device.Update((int)row);
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
//		if(!playing)
//			return currentRow;
//		float nextRow = tracks[trackName].GetValue(row);
//		return currentRow + (nextRow - currentRow);
//		return interpolate(currentRow, nextRow, row, tracks[trackName].Type);
	}

	/**
     * Interpolates value for row between two TrackKey-objects.
     *
     * Interpolation type depends on the first key; only the value is
     * used from the second key in the process.
     *
     * Row can naturally be fractional, so interpolation between
     * values flowing in time is continuous.
     */
//	public static float interpolate(float first, float second, float row, Track.Key.Type type) {
//		float t = (row - first) / (second - first);
//			
//		switch (type) {
//		case Track.Key.Type.Step:
//			return first;
//			//case KeyType.LINEAR:
//		case Track.Key.Type.Smooth:
//			t = t * t * (3 - 2*t);
//			break;
//		case Track.Key.Type.Ramp:
//			t = Mathf.Pow(t, 2.0);
//			break;
//		}
//
//		return first + (second - first) * t;
//	}

	void OnDestroy() {
		device.Dispose();
	}
}
