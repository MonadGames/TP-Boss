using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechTrigger : MonoBehaviour
{
	public GameObject panel;
	public GameObject hint;
	public Text text;
	private Npc npc;
	private bool questGiven = false;
	private TW_MultiStrings_Regular typewriter;
	private int stringCount;
	private int currentString;
	bool isShowingMessage = false;

	void Start() {
		typewriter = text.GetComponent<TW_MultiStrings_Regular> ();
		stringCount = typewriter.MultiStrings.Length;
		currentString = 1;
		panel.SetActive(false);
		npc = gameObject.GetComponent<Npc> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		showHint (isPlayer(other));
	}

	void OnTriggerStay2D(Collider2D other)
	{
		giveQuest (other);
		if (shouldShowMessage (other)) {
			TurnOnMessage ();  
		} else if (shouldShowNextString (other)) {
			showNextString ();
		} else if (shouldShowFirstString (other)) {
			resetCounters ();
			TurnOnMessage(); 
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			hideMessage (true);
		}
	}

	private bool isPlayer(Collider2D other) {
		return other.name == "Player";
	}

	private void giveQuest(Collider2D other){
		if (currentString == stringCount && isPlayer(other) && !questGiven) {
			Quest mainQuest = npc.getMainQuest ();
			Player player = other.GetComponent<Player> ();
			player.setMainQuest (mainQuest);
			questGiven = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (isPlayer(other))
		{
			TurnOffMessage();
		}
	}

	private void showNextString() {
		typewriter.NextString ();
		currentString++;
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
		return isPlayer(other) && Input.GetKeyDown (KeyCode.E) && !isShowingMessage;
	}

	private bool shouldShowNextString (Collider2D other){
		return isPlayer(other) && Input.GetKeyDown (KeyCode.E) && currentString < stringCount;
	}

	private bool shouldShowFirstString(Collider2D other) {
		return isPlayer(other) && Input.GetKeyDown (KeyCode.E) && currentString == stringCount;
	}

	private void TurnOnMessage()
	{
		panel.SetActive(true);
		showHint(false);
		isShowingMessage = true;
		typewriter.StartTypewriter ();
	}

	private void resetCounters(){
		currentString = 1;
	}

	private void TurnOffMessage()
	{
		hideMessage (false);
		resetCounters ();
	}
}
