using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public float force = 10;
	public float time = 0;
	public float speed = 4;
	public float magnitudeMultiplier = 0.5f;
	public float delay = 1;
	public float phase = 0;
	public int explosionNumber;
	public bool recalculateDirection = false;

	Vector3 directionFromStart;
	Vector3 originalPosition;
	// Use this for initialization
	void Start () {
//		GetComponent<Rigidbody>().AddExplosionForce(force, Vector3.zero, 10);
		if(recalculateDirection)
			directionFromStart = transform.localPosition - Vector3.zero;
		originalPosition = transform.localPosition;
		speed = speed * (directionFromStart.magnitude * magnitudeMultiplier);
	}

	public void SetDirectionFromStart(Vector3 direction) {
		directionFromStart = direction;
	}
	
	// Update is called once per frame
	void Update () {
//			Debug.Log ("originalPosition " + originalPosition); 
//			Debug.Log ("directionFromStart " + directionFromStart);
		time = Time.time - delay;
		phase = Rocket.instance.GetValue ("Explosion_" + explosionNumber);
//		phase = SetTimeScale.explodePhaseStatic;
		transform.localPosition = originalPosition + directionFromStart * phase;
	}
}
