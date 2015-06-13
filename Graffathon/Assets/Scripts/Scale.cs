using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {
	public string rocketKey;
	Vector3 originalScale;
	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = originalScale * Rocket.instance.GetValue(rocketKey);
	}
}
