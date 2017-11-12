using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public Player player;
	public GameObject panel;
	public GameObject UI;

	public bool visible;

	void Start () {
		visible = false;
		player = GameObject.FindObjectOfType<Player> ();
	}


	public void gameOver(){
		visible = true;
		StartCoroutine(waitAndGameOver(player.timeOfDead));
	}

	IEnumerator waitAndGameOver(float waitTime) {
		yield return new WaitForSecondsRealtime(waitTime);
		panel.SetActive (true);
		UI.SetActive (false);
	}

	IEnumerator waitAndRestart(float waitTime) {
		// Aca me gustaria poner una animacion de regreso o algun sonido.
		yield return new WaitForSecondsRealtime(waitTime);
		panel.SetActive (false);
		UI.SetActive (true);
	}

	public void restart() {
		visible = false;
		StartCoroutine(waitAndRestart(player.timeOfDead));
	}

	public void goToMenu(){
		// Por ahora no tenemos menu, asque no hace nada.
	}
}
