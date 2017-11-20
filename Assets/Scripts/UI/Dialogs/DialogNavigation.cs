using UnityEngine;
using System.Collections;

public class DialogNavigation : MonoBehaviour
{
	public DialogAction[] actions;
	public GameObject panel;
	public bool selfDestroy;
	private DialogAction currentAction;
	private int index = 0;
	private PlayerMovementInX movX;
	private PlayerMovementInY movY;

	public GameObject player;

	void Start () {
		currentAction = actions [index];
		movX = player.GetComponent<PlayerMovementInX> ();
		movY = player.GetComponent<PlayerMovementInY> ();
	}
		
	void Update ()
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (panel.activeSelf) {
			movX.enabled = false;
			movY.enabled = false;
			foreach (DialogAction action in actions) {
				action.showHighlight (false);
			}
			currentAction.showHighlight (true);
			selectNextAction (other);
			selectPreviousAction (other);
			applyAction (other);
		}

	}

	private bool isPlayer(Collider2D other) {
		return other.name == "Player";
	}

	private void selectNextAction(Collider2D collider) {
		if (isPlayer(collider) && Input.GetKeyDown (KeyCode.D) && index +1 < actions.Length) {
			index++;
			currentAction = actions [index];
			currentAction.showHighlight (true);
		}
	}

	private void selectPreviousAction(Collider2D collider) {
		if (isPlayer(collider) && Input.GetKeyDown (KeyCode.A) && index > 0) {
			index--;
			currentAction = actions [index];
			currentAction.showHighlight (true);
		}
	}

	private void applyAction(Collider2D collider){
		if (isPlayer(collider) && Input.GetKeyDown(KeyCode.Space)) {
			movX.enabled = true;
			movY.enabled = true;
			currentAction.performAction ();
			if (currentAction.closeDialogWhenFinished) {
				panel.SetActive (false);
			}
		}
	}

}

