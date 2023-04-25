﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

//The purpose of this script is to display a message to the player when they enter a control zone of some sort,
//such as a no fly zone

public class ZoneNotifier : UdonSharpBehaviour
{
	VRCPlayerApi localPlayer = null;
	TextMeshProUGUI zoneNotifierText;
	public GameObject zoneNotifierTextObject;
	public bool globalNotifyPlayer = true; //whether or not to notify the player when they enter the zone (This is a global setting for all zones)

	void Start()
	{
		//finds the local player
		localPlayer = Networking.LocalPlayer;

		//finds the zone notifier text object
		zoneNotifierText = zoneNotifierTextObject.GetComponent<TextMeshProUGUI>();

		//turns off the zone notifier text object
		zoneNotifierTextObject.SetActive(false);
	}

	public void notifyPlayer(string message)
	{
		if (!globalNotifyPlayer)
			return;
		zoneNotifierText.text = message;

		//Turn the text object off and on again to make it update
		zoneNotifierTextObject.SetActive(false);
		zoneNotifierTextObject.SetActive(true);
	}
}