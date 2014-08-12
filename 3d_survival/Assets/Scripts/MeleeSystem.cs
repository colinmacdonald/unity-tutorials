using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

	public int damageOut = 25;
	public float maxDistance = 5;
	
	public Transform sword;

	Transform player;
	
	void Awake() {
		player = this.transform;
	}
	
	void Update() {
	
		if (!Input.GetButtonDown("Fire1")) {
			return;
		}
		
		sword.animation.Play("Sword");
		
		RaycastHit hit = new RaycastHit();
		
		if (Physics.Raycast(player.position, player.TransformDirection(Vector3.forward), out hit)) {
			
			if (hit.distance >= maxDistance) {
				return;
			}
			
			hit.transform.SendMessage("ApplyDamage", damageOut, SendMessageOptions.DontRequireReceiver);
		}
	}
}
