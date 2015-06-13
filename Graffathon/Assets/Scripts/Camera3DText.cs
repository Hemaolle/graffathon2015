using UnityEngine;
using System.Collections;

public class Camera3DText : MonoBehaviour {

	public float speed;

	Vector3 originalPosition;
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = originalPosition + Rocket.instance.GetValue("camera_3d_text") * speed * Vector3.right;
//		transform.Translate(Vector3.right * speed;, Space.World);
	}
}
