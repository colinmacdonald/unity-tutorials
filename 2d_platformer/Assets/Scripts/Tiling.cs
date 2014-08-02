using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;

	public bool hasRightTile = false;
	public bool hasLeftTile = false;
	public bool reverseScale = false;

	private float spriteWidth = 0f;
	private Camera cam;
	private Transform myTransform;
	
	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLeftTile == false || hasRightTile == false) {

			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasRightTile == false) {
				Debug.Log ("create right tile");
				createTile (1);
				hasRightTile = true;

			} else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasLeftTile == false) {
				Debug.Log("create left tile");
				createTile (-1);
				hasLeftTile = true;
			}
		}
	}

	void createTile (int rightOrLeft) {
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, 
		                                   myTransform.position.y, 
		                                   myTransform.position.z);

		// Cast as Transform
		Transform newTile = (Transform)Instantiate (myTransform, newPosition, myTransform.rotation);

		if (reverseScale == true) {
			newTile.localScale = new Vector3 (newTile.localScale.x * -1, newTile.localScale.y, newTile.localScale.z);
		}

		newTile.parent = myTransform.parent;

		if (rightOrLeft > 0) {
			newTile.GetComponent<Tiling>().hasLeftTile = true;

		} else {
			newTile.GetComponent<Tiling>().hasRightTile = true;
		}
	}
}
