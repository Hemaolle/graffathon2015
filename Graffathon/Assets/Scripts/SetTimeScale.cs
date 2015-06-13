using UnityEngine;
using System.Collections;

public class SetTimeScale : MonoBehaviour {

	public float explodePhase = 0;

	public static float explodePhaseStatic;
	// Use this for initialization
	void Start () {
	
	}

	public static void SetExplodePhase(float phase) {
		explodePhaseStatic = phase;
	}
	
	// Update is called once per frame
	void Update () {
		explodePhaseStatic = Rocket.instance.GetValue("test_track_oskari");
//		explodePhaseStatic = explodePhase;
//		Time.timeScale = currentScale;
	}
}
