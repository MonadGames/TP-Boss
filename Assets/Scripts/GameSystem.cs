using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public GameObject[] npcs;
	public GameObject controllerMenu;

	private Player player;
	private Vector3 checkpoint;
	private CanvasController canvasController;
	public bool uiLocked = false;

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

		checkOpenMenu ();
	}

	public void checkBack(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvasController.goToMenu ();
		}
	}

	public void save(Vector3 vector) {
		checkpoint = vector;
	}

	public void checkOpenMenu (){
		if (Input.GetKeyDown (KeyCode.Escape) && getUILock()) {
			controllerMenu.SetActive (!controllerMenu.active);
			releaseUILock ();
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
		playerPos = checkpoint;
		player.gameObject.transform.localPosition = playerPos;
		player.revive ();
	}

	public void checkGameOver (){
		if (player.isDead () && !canvasController.visible) {
			canvasController.gameOver ();	
		}
	}

	public bool getUILock() {
		if (uiLocked) {
			return !uiLocked;
		} else {
			uiLocked = true;
			return uiLocked;
		}
	}

	public void releaseUILock(){
		StartCoroutine(WaitAndRelease (0.1f));
	}

	private IEnumerator WaitAndRelease(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		uiLocked = false;
	}
}
