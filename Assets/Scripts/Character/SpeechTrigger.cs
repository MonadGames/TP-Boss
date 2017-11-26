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
	bool isShowingMessage = false;
	private bool keyDown = false;
	private bool firstTalk = true;
	private GameSystem system;

	void Start() {
		typewriter = text.GetComponent<TW_MultiStrings_Regular> ();
		panel.SetActive(false);
		npc = gameObject.GetComponent<Npc> ();
		system = GameObject.FindObjectOfType<GameSystem> ();
	}

	void Update() {
		keyDown = Input.GetKeyDown (KeyCode.E);
	}

	void OnTriggerEnter2D(Collider2D other) {
		showHint (isPlayer(other));
	}

	void OnTriggerStay2D(Collider2D other) {
		giveQuest (other);
		if (shouldShowMessage (other)) {
			TurnOnMessage ();
			system.getUILock ();
			keyDown = false;
			firstTalk = false;
		} else if (shouldShowNextString (other)) {
			showNextString();
			keyDown = false;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			TurnOffMessage ();
			system.releaseUILock ();
		}
	}

	private int stringCount(){
		return typewriter.MultiStrings.Length;
	}

	private bool isPlayer(Collider2D other) {
		return other.name == "Player";
	}

	private void giveQuest(Collider2D other){
		Player player = other.GetComponent<Player> ();

		if (!firstTalk && isPlayer(other) && shouldGiveQuest(player) && isShowingMessage) {
			// REFACTORIZAR ESE CODIGO FEO.
			if (player.getMainQuest () == null) {
				player.setMainQuest (npc.getMainQuest());
				questGiven = true;
			} else {
				completeQuestAndAssignNewOne (player);
			}
		}
	}

	private bool isLastString() {
		return typewriter.index_of_string == stringCount() - 1;
	}

	private bool shouldGiveQuest(Player player){
		bool questAvailable = !questGiven || (npc.getMainQuest() != null && npc.getMainQuest().isFinishQuest (player));
		return isLastString() && questAvailable;
	}

	private void completeQuestAndAssignNewOne(Player player) {
		// La quest actual del player se completo
		if (player.getMainQuest ().isFinishQuest (player)) {
			player.getMainQuest ().completeQuest (player);
			// La quest del NPC se completo (eran la misma)
			if (npc.getMainQuest().isFinishQuest (player)) {
				// Actualizar mainQuest del NPC con la siguiente en la lista.
				npc.updateMainQuest ();
			}
			player.setMainQuest (npc.getMainQuest());
			questGiven = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (isPlayer(other)) {
			TurnOffMessage();
			system.releaseUILock ();
		}
	}

	private void showNextString() {
		// chequear que se termino el text.
		if (isLastString ()) {
			print ("Last string");
			typewriter.MultiStrings = npc.text ();
			typewriter.index_of_string = typewriter.MultiStrings.Length;
		}
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
		typewriter.MultiStrings = npc.text();
		resetCounters ();
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
