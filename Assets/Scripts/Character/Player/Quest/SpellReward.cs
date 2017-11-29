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
			player.getStats ().setSanity (new Kind (player.getStats (), 1, 0));
		} else if(badAction) {
			player.getStats ().setSanity (new Evil (player.getStats (), 0, 1));
		}
	}
}

