using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float phase;
	public Vector3 axis = Vector3.up;
	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		phase = Rocket.instance.GetValue("row");
		transform.localRotation = Quaternion.AngleAxis(phase * speed, axis);
	}
}
