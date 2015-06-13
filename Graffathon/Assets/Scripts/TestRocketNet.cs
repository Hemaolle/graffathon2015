using UnityEngine;
using System.Collections;
using RocketNet;
public class TestRocketNet : MonoBehaviour {
	Track testTrack;
	Device device;
	public float speed;
	private int row;
	// Use this for initialization
	void Start () {
		device = new Device("", false);
		device.Connect();
		device.SetRow = SetRow;
		testTrack = device.GetTrack("test_track_oskari");

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.LogError((int)Time.time);
		device.Update((int)Time.time);
		SetTimeScale.explodePhaseStatic = testTrack.GetValue(row);
//		Debug.LogError(device.GetRow());
//		Debug.LogError(testTrack.GetValue(device.GetRow()));
	}

	void SetRow(int row) {
		this.row = row;
	}

//	void OnDestroy() {
//		device.Dispose();
//	}
}
