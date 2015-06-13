using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {
	public GameObject spawnee;
	public float range;
	public int n = 10;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(1);
		for(int i = 0; i < n; i++){
			Vector3 pos = Random.insideUnitSphere;
			pos *= range;
			GameObject newObject = Instantiate(spawnee, pos, Random.rotation) as GameObject;
			newObject.AddComponent<Explode>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
