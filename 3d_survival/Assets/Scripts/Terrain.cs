using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {

	public int viewDistance = 64; 
	
	private Camera cam;
	private GameObject ground;
	
	private static string basePath = "Sample Assets/Prototyping/";
	
	private string matPath = basePath + "Materials/prototype_blue_grid";
	private string modPath = basePath + "Models/prototype_platform_8x1x8";
	
	private Material platformMat;
	private Mesh platformMesh;
	
	private int tilesDistance;
	private GameObject[,] loadedTiles;

	void Awake() {
	
		cam = Camera.main;
		ground = GameObject.Find("Environment/Ground");
		
		// Load resources
		platformMat = (Material)Resources.Load(matPath, typeof(Material));
		platformMesh = ((GameObject)Resources.Load(modPath)).GetComponent<MeshFilter>().mesh;
		
		Vector3 size = platformMesh.bounds.size;
		tilesDistance = (int)Mathf.Max(size.x, size.y);
		loadedTiles = new GameObject[tilesDistance * 2 + 1, tilesDistance * 2 + 1];
	}
	
	void Start() {
	
		generateTiles();
	}

	void Update () {
	
	}
	
	void generateTiles() {
		for(int x = 0; x < loadedTiles.GetLength(0); x++) {
			for (int z = 0; z < loadedTiles.GetLength(1); z++) {
				
				Vector3 tilePos = new Vector3(
					(x * tilesDistance) + cam.transform.position.x - (loadedTiles.GetLength(0) * 8 / 2), 
					0f, 
					(z * tilesDistance) + cam.transform.position.z - (loadedTiles.GetLength(1) * 8 / 2));
					
				loadedTiles[x, z] = generateTile(tilePos);
			}
		}
	}
			
	GameObject generateTile(Vector3 position) {
	
		GameObject gameObject = new GameObject("Platform");
		
		gameObject.AddComponent<MeshRenderer>().material = platformMat;
		gameObject.AddComponent<MeshFilter>().sharedMesh = platformMesh;
		gameObject.AddComponent<BoxCollider>();
		
		gameObject.transform.parent = ground.transform;
		gameObject.transform.position = position;	
		
		return gameObject;
	}
}
