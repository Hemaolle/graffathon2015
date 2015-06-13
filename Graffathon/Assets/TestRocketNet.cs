using UnityEngine;
using System.Collections;
using RocketNet;
public class TestRocketNet : MonoBehaviour {
	Track testTrack;
	Device device;
	public float speed;
	// Use this for initialization
	void Start () {
		device = new Device("", false);
		device.Connect();
		testTrack = device.GetTrack("test_track_oskari");

	}
	
	// Update is called once per frame
	void Update () {
		Debug.LogError((int)Time.time);
		device.Update((int)Time.time);
//		Debug.LogError(device.GetRow());
//		Debug.LogError(testTrack.GetValue(device.GetRow()));
	}

//	void OnDestroy() {
//		device.Dispose();
//	}
}
