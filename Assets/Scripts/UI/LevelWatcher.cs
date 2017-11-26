﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelWatcher : MonoBehaviour
{
	private Player player;
	public Text level;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		level.text = player.getStats ().getLevel ().ToString();
	}
}

