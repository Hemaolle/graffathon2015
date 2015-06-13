using UnityEngine;
using System.Collections;

public class SetTimeScale : MonoBehaviour {

	public float explodePhase = 0;

	public static float explodePhaseStatic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		explodePhaseStatic = explodePhase;
//		Time.timeScale = currentScale;
	}
}
