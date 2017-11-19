using UnityEngine;
using System.Collections;

public class TakeDecisionAndGiveSpellAction : DialogAction
{
	Player player;
	public GameObject spell;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindObjectOfType<Player> ();
	}

	public override void performAction(){
		player.addSpell (spell);
		(player.getMainQuest ().requirement as TakeAdecisionRequirement).takedecision();
	}
}

