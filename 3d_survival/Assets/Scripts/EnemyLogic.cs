using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	GameObject enemy;
	Color baseColor;
	
	public int health = 100;
	
	void Awake() {
		enemy = this.gameObject;
		baseColor = enemy.renderer.material.color;
	}
	
	void Update() {
		if (health <= 0) {
			kill();
		}
	}
	
	void ApplyDamage(int damageIn) {
		health -= damageIn;
		enemy.renderer.material.color = Color.red;
		Invoke("resetColor", 0.5f);
	}
	
	void resetColor() {
		enemy.renderer.material.color = baseColor;
	}
	
	void kill() {
		Destroy(enemy);
	}
}
