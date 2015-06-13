using UnityEngine;
using System.Collections;

public class SplitMesh : MonoBehaviour {
	public GameObject meshTemplate;
	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		for (int triangleIndex = 0; triangleIndex < mesh.triangles.Length;) {
//			Mesh newMesh = new Mesh();
			Vector3[] vertices = new Vector3[3];
			for (int i = 0; i < 3; i++) {
				vertices[i] = mesh.vertices[mesh.triangles[triangleIndex]];
				Debug.Log (triangleIndex);
				triangleIndex++;
			}
			GameObject newObject = Instantiate(meshTemplate, transform.position, transform.rotation) as GameObject;
			newObject.GetComponent<MeshFilter>().mesh = CreateMeshTriangle(vertices);
			newObject.name = "w" + triangleIndex / 3;
			newObject.AddComponent<Explode>().SetDirectionFromStart(Average(vertices));;
		}

//		GetComponent<MeshFilter>().mesh = CreateMeshTriangle(new Vector3[] {new Vector3(-1,-1,0), 
//			new Vector3(-1, 1, 0),
//			new Vector3(1, -1, 0)});

		Destroy(gameObject);
	}

	Vector3 Average(Vector3[] vectors){
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

	Mesh CreateMeshTriangle(Vector3[] vertices)
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
