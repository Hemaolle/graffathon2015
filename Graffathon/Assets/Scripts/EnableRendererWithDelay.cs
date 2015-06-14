using UnityEngine;
using System.Collections;

public class EnableRendererWithDelay : MonoBehaviour {

	public float delay = 10f;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (delay);
		GetComponent<MeshRenderer> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
