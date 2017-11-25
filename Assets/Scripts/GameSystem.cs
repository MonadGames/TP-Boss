using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public GameObject[] npcs;

	private Player player;
	private Vector3 checkpoint;
	private CanvasController canvasController;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		canvasController = GameObject.FindObjectOfType<CanvasController> ();
		checkpoint = new Vector3(3,0,0);
	}


	void Update () {
		if (!canvasController.visible) {
			checkGameOver ();
		} else {
			checkContinue ();
			checkBack ();
		}
	}

	public void checkBack(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvasController.goToMenu ();
		}
	}

	public void save(Vector3 vector) {
		checkpoint = vector;
	}
		

	public void checkContinue(){
		if (Input.GetKeyDown (KeyCode.E)) {
			restartToCheckPoint ();
			canvasController.restart();
		}
	}

	public void surviveToBoss() {
		// Aca podriamos activar una animacion que se ponga todo borroso y diga el nombre del juego.
	}

	public void restartToCheckPoint(){
		Vector3 playerPos = player.gameObject.transform.localPosition;
		playerPos = checkpoint;
		player.gameObject.transform.localPosition = playerPos;
		player.revive ();
	}

	public void checkGameOver (){
		if (player.isDead () && !canvasController.visible) {
			canvasController.gameOver ();	
		}
	}
}
