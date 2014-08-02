using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public LayerMask validLayers;

	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");

		if (firePoint == null) {
			Debug.LogError("Missing \"FirePoint\" game Object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
					Shoot();
			}
		} else {
			if (Input.GetButton("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot();
			}
		}
	}

	void Shoot () {
		Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
										Camera.main.ScreenToWorldPoint(Input.mousePosition).y);								
		Vector2 firePointPos = new Vector2 (firePoint.position.x, firePoint.position.y);
		
		RaycastHit2D hit = Physics2D.Raycast (firePointPos, mousePos - firePointPos, 100, validLayers);
		Debug.DrawLine (firePointPos, (mousePos - firePointPos) * 100, Color.green);
	
		if (hit.collider != null) {
			Debug.DrawLine (firePointPos, hit.point, Color.red);
			Debug.Log("We hit: " + hit.collider.name + " for: " + damage);
		}
	}
}
