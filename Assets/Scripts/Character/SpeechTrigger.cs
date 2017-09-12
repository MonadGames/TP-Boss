using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechTrigger : MonoBehaviour
{
	public GameObject panel;
	public GameObject hint;
	bool isShowingMessage = false;

	void Start()
	{
		panel.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			hint.SetActive (true);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player" && Input.GetKeyDown (KeyCode.E)) {
			TurnOnMessage();  
			hint.SetActive (false);
		}
	}

	private void TurnOnMessage()
	{
		if (!isShowingMessage) {
			panel.SetActive(true);
			isShowingMessage = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			TurnOffMessage();
		}
	}

	private void TurnOffMessage()
	{
		panel.SetActive(false);
		hint.SetActive (false);
		isShowingMessage = false;
	}
}
