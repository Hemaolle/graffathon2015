using UnityEngine;
using UnityEditor;
public class EditorSplit : EditorWindow {
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = false;
	float myFloat = 1.23f;
	GameObject myObject;
	GameObject meshTemplate;

	float rotationMultiplierMin;
	float rotationMultiplierMax;
	
	// Add menu named "My Window" to the Window menu
	[MenuItem ("Window/My Window")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		EditorSplit window = (EditorSplit)EditorWindow.GetWindow (typeof (EditorSplit));
		window.Show();
	}
	
	void OnGUI () {
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
//		myString = EditorGUILayout.TextField ("Text Field", myString);
		myObject = EditorGUILayout.ObjectField ("Object to split", myObject, typeof(GameObject), true) as GameObject;
		meshTemplate = EditorGUILayout.ObjectField ("Mesh template", meshTemplate, typeof(GameObject), true) as GameObject;
		rotationMultiplierMin = EditorGUILayout.FloatField ("rotationMin", rotationMultiplierMin);
		rotationMultiplierMax = EditorGUILayout.FloatField ("rotationMax", rotationMultiplierMax);
//		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
//		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
//		EditorGUILayout.EndToggleGroup ();
	}

	void Update() {
		if (myBool) {
			myBool = false;

			Mesh mesh = myObject.GetComponent<MeshFilter> ().mesh;
			for (int triangleIndex = 0; triangleIndex < mesh.triangles.Length;) {
				//			Mesh newMesh = new Mesh();
				Vector3[] vertices = new Vector3[3];
				for (int i = 0; i < 3; i++) {
					vertices [i] = mesh.vertices [mesh.triangles [triangleIndex]];
					//				Debug.Log (triangleIndex);
					triangleIndex++;
				}
				Vector3 averagePos = SplitMesh.Average (vertices);
				for (int i = 0; i < 3; i++) {
					vertices [i] = vertices [i] - averagePos;
				}
				GameObject newObject = Instantiate (meshTemplate, myObject.transform.position + averagePos, myObject.transform.rotation) as GameObject;
				
				newObject.GetComponent<MeshFilter> ().mesh = SplitMesh.CreateMeshTriangle (vertices);
				newObject.name = "w" + triangleIndex / 3;
				newObject.transform.parent = myObject.transform;
				//			if (triangleIndex < 4) {
				newObject.AddComponent<Explode> ().SetDirectionFromStart (averagePos);
				
				RandomRotate rotate = newObject.AddComponent<RandomRotate> ();
				
				rotate.rotationMultiplierMin = rotationMultiplierMin;
				rotate.rotationMultiplierMax = rotationMultiplierMax;
				//			}
			}
		}
	}
}