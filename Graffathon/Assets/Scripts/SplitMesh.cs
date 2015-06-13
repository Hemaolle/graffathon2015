using UnityEngine;
using System.Collections;

public class SplitMesh : MonoBehaviour {
	public GameObject meshTemplate;
	public float rotationMultiplierMin = 10;
	public float rotationMultiplierMax = 100;

	public int explosionNumber;

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		for (int triangleIndex = 0; triangleIndex < mesh.triangles.Length;) {
//			Mesh newMesh = new Mesh();
			Vector3[] vertices = new Vector3[3];
			for (int i = 0; i < 3; i++) {
				vertices[i] = mesh.vertices[mesh.triangles[triangleIndex]];
//				Debug.Log (triangleIndex);
				triangleIndex++;
			}
			Vector3 averagePos = Average(vertices);
			for (int i = 0; i < 3; i++) {
				vertices[i] = vertices[i] - averagePos;
			}
			GameObject newObject = Instantiate(meshTemplate, transform.position + averagePos, transform.rotation) as GameObject;

			newObject.GetComponent<MeshFilter>().mesh = CreateMeshTriangle(vertices);
			newObject.name = "w" + triangleIndex / 3;
			newObject.transform.parent = transform;
//			if (triangleIndex < 4) {
			Explode explode = newObject.AddComponent<Explode>();		
			explode.SetDirectionFromStart(averagePos);
			explode.explosionNumber = explosionNumber;

			RandomRotate rotate = newObject.AddComponent<RandomRotate>();
			rotate.rocketKey = "Explosion_" + explosionNumber;

			rotate.rotationMultiplierMin = rotationMultiplierMin;
			rotate.rotationMultiplierMax = rotationMultiplierMax;
//			}
		}

//		GetComponent<MeshFilter>().mesh = CreateMeshTriangle(new Vector3[] {new Vector3(-1,-1,0), 
//			new Vector3(-1, 1, 0),
//			new Vector3(1, -1, 0)});
		GetComponent<MeshRenderer> ().enabled = false;
//		Destroy(gameObject);
	}

	public static Vector3 Average(Vector3[] vectors){
		Vector3 result = new Vector3();
		foreach(Vector3 vector in vectors) {
			result += vector;
		}
		result /= vectors.Length;
		return result;
	}

	Mesh CreateMesh(float width, float height)
	{
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = new Vector3[] {
			new Vector3(-width, -height, 0.01f),
			new Vector3(width, -height, 0.01f),
			new Vector3(width, height, 0.01f),
			new Vector3(-width, height, 0.01f)
		};
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		m.RecalculateNormals();
		
		return m;
	}

	Mesh CreateMeshTriangle(float width, float height)
	{
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = new Vector3[] {
			new Vector3(-width, -height, 0.01f),
			new Vector3(width, -height, 0.01f),
			new Vector3(-width, height, 0.01f)
		};
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2 };
		m.RecalculateNormals();
		
		return m;
	}

	public static Mesh CreateMeshTriangle(Vector3[] vertices)
	{
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = vertices;
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2 };
		m.RecalculateNormals();
		
		return m;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
