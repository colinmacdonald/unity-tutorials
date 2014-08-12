using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	public float min = 0;
	public float max = 20;
	
	private Camera cam;
	
	void Awake () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cam.transform.position.y <= min) {
			Debug.Log (cam.transform.position.y);
			cam.transform.position.Set(cam.transform.position.x, min, cam.transform.position.z);
		}
		
		if (cam.transform.position.y >= max) {
			cam.transform.position.Set(cam.transform.position.x, max, cam.transform.position.z);
		}
	}
}
