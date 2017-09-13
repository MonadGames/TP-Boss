using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechTrigger : MonoBehaviour
{
	public GameObject panel;
	public GameObject hint;
	public Text text;
	private TW_MultiStrings_Regular typewriter;
	private int stringCount;
	private int currentString;
	bool isShowingMessage = false;

	void Start()
	{
		typewriter = text.GetComponent<TW_MultiStrings_Regular> ();
		stringCount = typewriter.MultiStrings.Length;
		currentString = 1;
		panel.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		showHint (other.name == "Player");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (shouldShowMessage(other)) {
			TurnOnMessage();  
		} else if (shouldShowNextString(other)) {
			showNextString ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			hideMessage (true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player")
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
		return other.name == "Player" && Input.GetKeyDown (KeyCode.E) && !isShowingMessage;
	}

	private bool shouldShowNextString (Collider2D other){
		return other.name == "Player" && Input.GetKeyDown (KeyCode.E) && currentString < stringCount;
	}

	private void TurnOnMessage()
	{
		panel.SetActive(true);
		showHint(false);
		isShowingMessage = true;
		typewriter.StartTypewriter ();
	}

	private void TurnOffMessage()
	{
		hideMessage (false);
		currentString = 1;
		typewriter.pointer = 0;
	}
}
