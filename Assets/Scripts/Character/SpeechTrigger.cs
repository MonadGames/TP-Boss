using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechTrigger : MonoBehaviour
{
	[SerializeField]
	Canvas messageCanvas;
	bool isShowingMessage = false;

	void Start()
	{
		messageCanvas.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		if (other.name == "Player")
//		{
//			TurnOnMessage();
//		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "Player" && Input.GetKeyDown (KeyCode.E)) {
			TurnOnMessage();                                
		}
	}

	private void TurnOnMessage()
	{
		if (!isShowingMessage) {
			messageCanvas.enabled = true;
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
		messageCanvas.enabled = false;
		isShowingMessage = false;
	}
}
