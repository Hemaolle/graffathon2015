﻿using UnityEngine;
using System.Collections;
using RocketNet;

public class RocketSave : MonoBehaviour {
	public string trackPath;
	public string[] trackNames;

//	Device device;
//	
//	// Use this for initialization
//	void Start () {
//		device = new Device("", false);
//		device.Connect();
//		foreach (string trackName in trackNames) {
//			device.GetTrack(trackName);
//		}
//		device.Update(0);
//		device.SaveTracks();
//	}

	void Update() {		
		foreach (string trackName in trackNames) {
			Debug.Log(trackName + " " + Rocket.instance.GetValue(trackName));
		}
	}
	
//	void OnDestroy() {
//		device.Dispose();
//	}
}
