using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {

	public int viewDistance = 64; 
	public GameObject platformPrefab;
	
	private Camera cam;
	private GameObject ground;
	
	private int tilesDistance;
	private Object[,] loadedTiles;

	void Awake() {
	
		cam = Camera.main;
		ground = GameObject.Find("Environment/Ground");
		
		Vector3 size = platformPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.size;
		Debug.Log(size);
		tilesDistance = (int)Mathf.Max(size.x * platformPrefab.transform.localScale.x, size.z * platformPrefab.transform.localScale.z);
		loadedTiles = new GameObject[viewDistance / tilesDistance + 1, viewDistance / tilesDistance + 1];
	}
	
	void Start() {
	
		generateTiles();
	}

	void Update () {
	
	}
	
	void generateTiles() {
		Debug.Log(loadedTiles.GetLength(0));
		Debug.Log (loadedTiles.GetLength(1));
		for(int x = 0; x < loadedTiles.GetLength(0); x++) {
			for (int z = 0; z < loadedTiles.GetLength(1); z++) {
				float axisY = Random.Range(-2f, -0.1f);
				Vector3 tilePos = new Vector3(
					(x * tilesDistance) + cam.transform.position.x - (loadedTiles.GetLength(0) * tilesDistance / 2), 
					axisY, 
					(z * tilesDistance) + cam.transform.position.z - (loadedTiles.GetLength(1) * tilesDistance / 2));
					
				GameObject temp = (GameObject)Instantiate(platformPrefab, tilePos, platformPrefab.transform.rotation);
				temp.transform.parent = ground.transform;
				
			}
		}
	}
}
