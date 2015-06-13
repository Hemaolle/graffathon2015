using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {
	public float phase = 0;
	public float rotationMultiplierMin = 50;
	public float rotationMultiplierMax = 100;

	float rotationMultiplier;
	Quaternion originalRotation;
	Vector3 originalEuler;
	Vector3 rotationAxel;
	// Use this for initialization
	void Start () {
		//		GetComponent<Rigidbody>().AddExplosionForce(force, Vector3.zero, 10);

		originalRotation = transform.localRotation;
		originalEuler = originalRotation.eulerAngles;
		if(originalEuler == Vector3.zero)
			originalEuler = Vector3.one;
		rotationAxel = Random.insideUnitSphere.normalized;
		rotationMultiplier = Random.Range(rotationMultiplierMin, rotationMultiplierMax);
	}
	
	// Update is called once per frame
	void Update () {
		phase = SetTimeScale.explodePhaseStatic;
		transform.localRotation = Quaternion.AngleAxis(phase * rotationMultiplier, rotationAxel);
//		Debug.Log ("originalEuler " + originalEuler);
//		Debug.Log ("(Quaternion.AngleAxis(phase * rotationMultiplier, " +
//		           "rotationAxel) * originalEuler " + Quaternion.AngleAxis(phase * rotationMultiplier, rotationAxel) * originalEuler);
	}
}
