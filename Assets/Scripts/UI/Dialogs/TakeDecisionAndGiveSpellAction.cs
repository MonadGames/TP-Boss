using UnityEngine;
using System.Collections;

public class TakeDecisionAndGiveSpellAction : DialogAction
{
	Player player;
	CanvasController uiController;
	public GameObject fountainParticleEffect;
	public GameObject spell;
	public bool goodAction;
	public bool badAction;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindObjectOfType<Player> ();
		uiController = GameObject.FindObjectOfType<CanvasController> ();

	}

	public override void performAction(){
		player.addSpell (spell);
		player.GetComponent<Animator> ().SetTrigger ("Choose God");
		fountainParticleEffect.SetActive (true);
		(player.getMainQuest ().requirement as TakeAdecisionRequirement).takedecision();

		player.addSpell (spell);
		if (goodAction) {
			player.getStats ().setSanity (new Kind (player.getStats (), 1, 0));
		} else if(badAction) {
			player.getStats ().setSanity (new Evil (player.getStats (), 0, 1));
		}
	}
}

