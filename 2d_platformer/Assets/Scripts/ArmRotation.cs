﻿using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotOffset = 0;

	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		// Angle in degrees
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotOffset);
	}
}
