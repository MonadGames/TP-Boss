﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

	public AudioClip npcVoice;

	public string defaultText;
	public string presentationText;
	public Quest mainQuest;

	public List<Quest> quests;
	private AudioSource source;
	private SpeechTrigger trigger;
	private bool isPlayer = false;

	private bool initVoice = false;
	private bool itsShowedText = false;

	void Start () {
		quests = new List<Quest> ();
		source = GetComponent<AudioSource> ();
		trigger = GetComponent<SpeechTrigger> ();
	}

	void Update () {
		checkVoiceSound ();
	}

	void OnTriggerStay2D(Collider2D other) {
		isPlayer = other.name == "Player";
	}

	void OnTriggerExit2D(Collider2D other) {
		isPlayer = false;
	}

	public void checkVoiceSound() {
		if (isPlayer && trigger.isKeyDown() && !initVoice) {
			if (!source.isPlaying) {
				source.PlayOneShot (npcVoice, 0.3f);
			}
			initVoice = true;
			isPlayer = false;
		} 

		if (!trigger.isKeyDown() && initVoice) {
			initVoice = false;
		}
	}

	public string text() {
		if (!itsShowedText) {
			return presentationText;
		}

		return defaultText;
	} 

	public string questText(Quest quest) {
		if (quest.isFinishQuest (GetComponent<Player>())) {
			return quest.finishText;
		} 

		return quest.historyText;
	}

	public bool hasQuest(){
		return mainQuest != null;
	}

	public Quest getMainQuest(){
		return mainQuest;
	}

	public void setMainQuest(Quest quest){
		mainQuest = quest;
	}
}
