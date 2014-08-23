#pragma strict

var target:GameObject;

function Update () {
	transform.LookAt(target.transform);
}