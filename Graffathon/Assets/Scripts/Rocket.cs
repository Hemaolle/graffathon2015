using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RocketNet;
public class Rocket : Singleton<Rocket> {
	Track testTrack;
	Device device;
	public float speed;
	private int row;
	private Dictionary<string, Track> tracks = new Dictionary<string, Track>();

	// Use this for initialization
	void Start () {
		device = new Device("", false);
		device.Connect();
		device.SetRow = SetRow;
	}
	
	// Update is called once per frame
	void Update () {
		device.Update((int)Time.time);
	}

	void SetRow(int row) {
		this.row = row;
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
