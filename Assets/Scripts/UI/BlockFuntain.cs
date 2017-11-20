using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFuntain : MonoBehaviour {

	private SimpleSpeechTrigger trigger;
	private DialogNavigation navigation;
	private Player player;

	public GameObject hint;

	void Start () {
		trigger = GetComponent<SimpleSpeechTrigger> ();
		navigation = GetComponent<DialogNavigation> ();
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		if (player.getSkillSelected () != null) {
			trigger.enabled = false;
			navigation.enabled = false;
			hint.SetActive (false);
		}
	}
}
