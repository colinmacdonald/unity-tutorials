#pragma strict

public var dayLength:Number = 60; // Length of day light in seconds
public var moonLengthFactor:Number = 28; // How many days for full moon rotation

private var sun:GameObject;
private var moon:GameObject;

function Awake () {
	sun = gameObject.transform.FindChild("Environment/Sun").gameObject;
	moon = gameObject.transform.FindChild("Environment/Moon").gameObject;
	
	// Half the animation length is the day light animation duration. Divide this by the 
	// dayLength makes the day light animation last that long.
	sun.animation["SunRotation"].speed = sun.animation["SunRotation"].length / 2 / dayLength;
	moon.animation["MoonRotation"].speed = moon.animation["MoonRotation"].length / 2 / dayLength * 1 / moonLengthFactor;
}