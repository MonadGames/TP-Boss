using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public GameObject player;
	public GameObject panel;


	private Player playerController;
	private bool visible;

	void Start () {
		visible = false;
		playerController = player.gameObject.GetComponent<Player> ();
	}

	void Update () {
		checkGameOver ();
	}

	void checkGameOver (){
		if (playerController.isDead () && !visible) {
			visible = true;
			StartCoroutine(wait(playerController.timeOfDead));
			panel.SetActive (true);
		}
	}

	IEnumerator wait(float sec)
	{
		yield return new WaitForSeconds(sec);
	}
}
