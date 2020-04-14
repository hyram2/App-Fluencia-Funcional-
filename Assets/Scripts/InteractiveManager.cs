using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
	public static InteractiveManager instance;

	public InteractiveTeleport lastTeleport;

	public GameObject player;

	public Light light;
	public Color neutralColor, badColor, goodColor;
	// Use this for initialization
	void Start()
	{
		if (instance == null)
			instance = this;
	}

	public void Teleport(InteractiveTeleport tp)
	{
		if (lastTeleport != null)
		{
			lastTeleport.gameObject.SetActive(true);
			lastTeleport.SetActive(true);
			lastTeleport.isDisabled = false;
		}

		light.color = tp.mood == MoodType.Good ? goodColor : tp.mood == MoodType.Bad ? badColor : neutralColor;
		var tempPos = tp.transform.position;
		tempPos.y = 1.6f;
		player.transform.position = tempPos;
		player.transform.LookAt(transform);
		lastTeleport = tp;
	}
}
