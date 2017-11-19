using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEmptyReward", menuName = "Reward/Empty")]
public class EmptyReward : Reward {

	public override void applyReward(Player player){
	}
}
