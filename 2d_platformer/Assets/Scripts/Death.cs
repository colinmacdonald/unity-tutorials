using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public float boundaryMin;

	private GameObject player;
	private Component text;
	
	private bool dead = false;
	
	// Use this for initialization
	void Start () {
		player = this.gameObject;
		text = player.GetComponentInChildren("DeathText") as System.Type;
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			deathText();
			
			return;
		}
		
		if (player.transform.position.y < boundaryMin) {
			dead = true;
			Invoke("kill", 5f);
		}
	}
	
	void deathText() {
	}
	
	void kill () {
		Debug.Log("Fell out of level");
		Application.LoadLevel("level1");
	}
}
