using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechTrigger : MonoBehaviour {
	public GameObject panel;
	public GameObject hint;

	public Text text;


	private Npc npc;
	private bool questGiven = false;
	private TW_MultiStrings_Regular typewriter;
	private int stringCount;
	bool isShowingMessage = false;

	private bool keyDown = false;

	void Start() {
		typewriter = text.GetComponent<TW_MultiStrings_Regular> ();
		stringCount = typewriter.MultiStrings.Length;
		panel.SetActive(false);
		npc = gameObject.GetComponent<Npc> ();
	}

	void Update() {
		keyDown = Input.GetKeyDown (KeyCode.E);

		//initializeText();
	}

	/*
	public void initializeText() {
		if(// es la primera vez){
			typewriter = npc.presentationText
			} else {
				typewriter.resetCounter.
				typewriter = npc.defaultText

					// show quests

			}


			// chequear que se termino el text.


	} */

	void OnTriggerEnter2D(Collider2D other) {
		showHint (isPlayer(other));
	}

	void OnTriggerStay2D(Collider2D other) {
		giveQuest (other);
		if (shouldShowMessage (other)) {
			TurnOnMessage ();
			keyDown = false;
		} else if (shouldShowNextString (other)) {
			showNextString();
			keyDown = false;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TurnOffMessage ();
		}
	}

	private bool isPlayer(Collider2D other) {
		return other.name == "Player";
	}

	private void giveQuest(Collider2D other){
		if (typewriter.index_of_string == stringCount -1 && isPlayer(other) && !questGiven) {
			// REFACTORIZAR ESE CODIGO FEO.
			Quest mainQuest = npc.getMainQuest ();
			Player player = other.GetComponent<Player> ();
			if (player.getMainQuest () == null) {
				player.setMainQuest (mainQuest);
				questGiven = true;
			} else {
				if (player.getMainQuest ().isFinishQuest (player)) {
					player.getMainQuest ().completeQuest (player);
					player.setMainQuest (mainQuest);
					questGiven = true;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (isPlayer(other)) {
			TurnOffMessage();
		}
	}

	private void showNextString() {
		typewriter.NextString ();
	}

	private void showHint(bool show){
		hint.SetActive (show);
	}

	private void hideMessage(bool showTheHint){
		if (isShowingMessage){
			panel.SetActive (false);
			isShowingMessage = false;
			showHint (showTheHint);
		}
	}

	private bool shouldShowMessage(Collider2D other){
		return isPlayer(other) && keyDown && !isShowingMessage;
	}

	private bool shouldShowNextString (Collider2D other){
		return isPlayer(other) && keyDown;
	}

	private void TurnOnMessage()
	{
		panel.SetActive(true);
		showHint(false);
		isShowingMessage = true;
		typewriter.StartTypewriter ();
	}

	private void resetCounters(){
		typewriter.ResetCounters ();
	}

	private void TurnOffMessage(){
		hideMessage (false);
		resetCounters ();
	}

	public bool isKeyDown() {
		return keyDown;
	}
}
