using UnityEngine;
using System.Collections;

public class TakeDecisionAndGiveSpellAction : DialogAction
{
	Player player;
	CanvasController uiController;
	public GameObject fountainParticleEffect;
	public GameObject spell;
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
	}
}

