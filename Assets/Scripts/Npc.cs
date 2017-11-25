using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

	public AudioClip npcVoice;

	public string[] defaultText;
	public string[] presentationText;
	public Quest mainQuest;

	public List<Quest> quests;
	private AudioSource source;
	private SpeechTrigger trigger;
	private bool isPlayer = false;

	private bool initVoice = false;
	private bool itsShowedText = false;

	void Start () {
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

	public string[] text() {
		// CASO 1: Primera vez que hablas
		// - si tiene mainquest, le tira el texto de la quest 
		// -- setear multistrings a description
		// - si no, muestra texto por default

		// CASO 2: quest sin completar 
		// - mostrar texto de la quest -- description [string]
		// CASO 3: quest completa
		// - mostrar finish quest

		string[] textToShow = defaultText;
		if (!itsShowedText) {
			textToShow = presentationText;
			itsShowedText = true;
		} else if (mainQuest != null) {
			print ("Show Main quest text");
			textToShow = questText (mainQuest);
		}

		return textToShow;
	} 

	public string[] questText(Quest quest) {
		if (quest.isFinishQuest (GameObject.FindObjectOfType<Player>())) {
			return quest.finishText;
		} 

		return quest.historyText;
	}

	public bool hasQuest(){
		return mainQuest != null;
	}

	public bool firstTalk(){
		return itsShowedText;
	}

	public Quest getMainQuest(){
		return mainQuest;
	}

	public void updateMainQuest() {
		Quest quest = null;

		if (quests.Count > 0) {
			quest = quests.Find(aquest => true);
			quests.Remove (quest);
		}

		mainQuest = quest;
	}

	public void setMainQuest(Quest quest){
		mainQuest = quest;
	}
}
