using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public List<Vector3> checkpoints;
	public GameObject[] npcs;

	private Player player;
	private Vector3 lastCheckpoint;
	private CanvasController canvasController;
	private List<Quest> quests;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		canvasController = GameObject.FindObjectOfType<CanvasController> ();
		lastCheckpoint = checkpoints [0];
		quests = new List<Quest> ();

		createAndAssignFirstQuest ();

		createAndAssignSecondQuest ();
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

	public void createAndAssignFirstQuest(){
		Requirement firstReq = new PositionRequirement(player, new Vector2(75, 4));
		Reward firstReward = new EmptyReward ();
		Npc npc = npcs [0].gameObject.GetComponentInChildren<Npc> ();
		npc.setMainQuest(new Quest ("Un sueño hecho realidad", "Reúnete con Gwendolyn en el altar del destino", player, firstReq, firstReward));
	}

	public void createAndAssignSecondQuest(){
		Requirement secReq = new TakeAdecisionRequirement(player);
		Reward secReward = new EmptyReward ();
		Npc npc = npcs [1].gameObject.GetComponentInChildren<Npc> ();
		npc.setMainQuest(new Quest ("Elige tu destino", "Elige sabiamente tu destino", player, secReq, secReward));
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
		if (Input.GetKey (KeyCode.Escape)) {
			canvasController.goToMenu ();
		}
	}
		

	public void checkContinue(){
		if (Input.GetKey (KeyCode.E)) {
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
