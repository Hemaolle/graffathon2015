using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public float force = 10;
	public float time = 0;
	public float speed = 4;
	public float magnitudeMultiplier = 0.5f;
	public float delay = 1;

	Vector3 directionFromStart;
	Vector3 originalPosition;
	// Use this for initialization
	void Start () {
//		GetComponent<Rigidbody>().AddExplosionForce(force, Vector3.zero, 10);
		directionFromStart = transform.position - Vector3.zero;
		originalPosition = transform.position;
		speed = speed * (directionFromStart.magnitude * magnitudeMultiplier);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > delay) {
			time = Time.time - delay;
			transform.position = originalPosition + directionFromStart * time * speed;
		}
	}
}
