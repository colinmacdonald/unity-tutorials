#pragma strict

var parentCam:GameObject;
var skyboxCam:GameObject;

function Update () {

	skyboxCam.transform.rotation = parentCam.transform.rotation;
	
}