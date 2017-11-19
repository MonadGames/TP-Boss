using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public List<Vector3> checkpoints;
	public GameObject[] npcs;

	private Player player;
	private Vector3 lastCheckpoint;
	private CanvasController canvasController;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		canvasController = GameObject.FindObjectOfType<CanvasController> ();
		lastCheckpoint = checkpoints [0];
	}


	void Update () {
		if (!canvasController.visible) {
			checkLastCheckpoint ();
			checkGameOver ();
		} else {
			checkContinue ();
			checkBack ();
		}
	}

	public void checkLastCheckpoint() {
		Vector3 playerPos = player.gameObject.transform.position;
		foreach(Vector3 vector in checkpoints) {
			// Asumo que la lista esta ordenada y los checkpoint comienzan desde el menor hasta el mayor
			if (playerPos.x > vector.x) {
				lastCheckpoint = vector;
			}
		}
	}

	public void checkBack(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvasController.goToMenu ();
		}
	}
		

	public void checkContinue(){
		if (Input.GetKeyDown (KeyCode.E)) {
			restartToCheckPoint ();
			canvasController.restart();
		}
	}

	public void restartToCheckPoint(){
		Vector3 playerPos = player.gameObject.transform.localPosition;
		playerPos = lastCheckpoint;
		player.gameObject.transform.localPosition = playerPos;
		player.revive ();
	}

	public void checkGameOver (){
		if (player.isDead () && !canvasController.visible) {
			canvasController.gameOver ();	
		}
	}
}
