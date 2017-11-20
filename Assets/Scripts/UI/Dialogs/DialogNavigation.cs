using UnityEngine;
using System.Collections;

public class DialogNavigation : MonoBehaviour
{
	public DialogAction[] actions;
	public GameObject panel;
	public bool selfDestroy;
	private DialogAction currentAction;
	private int index = 0;
	// Use this for initialization
	void Start ()
	{
		currentAction = actions [index];
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (panel.activeSelf) {
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
			currentAction.performAction ();

			if (currentAction.closeDialogWhenFinished) {
				panel.SetActive (false);
			}
		}
	}

}

