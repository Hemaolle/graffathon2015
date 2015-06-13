using UnityEngine;
using System.Collections;

public class AudioPlayWithDelay : MonoBehaviour {
	public float delay = 0;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(delay);
		GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
