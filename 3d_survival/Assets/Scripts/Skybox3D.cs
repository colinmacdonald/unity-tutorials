using UnityEngine;
using System.Collections;

public class Skybox3D : MonoBehaviour {

	public Camera skyCam;
	
	// Update is called once per frame
	void Update () {
		skyCam.transform.rotation = camera.transform.rotation;
	}
}
