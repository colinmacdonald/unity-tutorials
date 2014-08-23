#pragma strict

public var skyCam:Camera;
public var moon:GameObject;

public var skyboxDay:Material;
public var skyboxNight:Material;

public var baseColor:Color;
public var riseColor:Color;
public var setColor:Color;

private var sunLight:Light;
private var moonLight:Light;
private var skybox:Skybox;
private var lerpTime:float;

private var lerpFactor:float = 0.125;

function Awake () {
	sunLight = gameObject.GetComponent("Light") as Light;
	moonLight = moon.GetComponent("Light") as Light;
	skybox = skyCam.GetComponent("Skybox") as Skybox;
	
	lerpTime = animation["SunRotation"].length / animation["SunRotation"].speed / 2 * lerpFactor;
		
	// Defaults
	baseColor = sunLight.color;
	sunLight.enabled = false;
	moonLight.enabled = false;
}

function SunRise () {
	skybox.material = skyboxDay;
	sunLight.enabled = true;
	moonLight.enabled = false;
	sunLight.color = riseColor;
}

function SunMid () {
	sunLight.color = Color.Lerp(sunLight.color, baseColor, lerpTime);
}

function SunSet () {
	sunLight.color = Color.Lerp(sunLight.color, setColor, lerpTime);
}

function Night () {
	sunLight.enabled = false;
	skybox.material = skyboxNight;
	moonLight.enabled = true;
}