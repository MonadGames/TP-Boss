using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewSpellReward", menuName = "Reward/Spell")]
public class SpellReward : Reward
{
	public GameObject spell;

	public bool goodAction;
	public bool badAction;

	public override void applyReward(Player player) {
		player.addSpell (spell);
		if (goodAction) {
			player.addGoodAction ();
		} else if(badAction) {
			player.addBadAction ();
		}
	}
}

