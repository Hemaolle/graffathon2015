using UnityEngine;
using System.Collections;

public class PulsingColor : MonoBehaviour {
	public Material material;
	public Camera targetCamera;
	public float phase;
	public Color color1;
	public Color color2;
	public AudioSource audiosource;

	bool quitCalled;
	
	// Update is called once per frame
	void Update () {
		phase = Rocket.instance.GetValue ("color");
		if (material != null)
			material.color = Color.Lerp (color1, color2, phase);
		if (targetCamera != null)
			targetCamera.backgroundColor = Color.Lerp (color1, color2, phase);
		if (audiosource != null)
			audiosource.volume = 1 - phase;
		if (phase == 1 && !quitCalled) {
			quitCalled = true;
			StartCoroutine (QuitApp ());
		}
	}

	IEnumerator QuitApp() {
		yield return new WaitForSeconds (3);
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
