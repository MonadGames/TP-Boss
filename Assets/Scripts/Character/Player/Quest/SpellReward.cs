using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewSpellReward", menuName = "Reward/Spell")]
public class SpellReward : Reward
{
	public GameObject spell;

	public override void applyReward(Player player) {
		player.addSpell (spell);
	}
}

