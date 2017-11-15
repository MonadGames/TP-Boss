using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleExpLoot : BubbleLoot {

	public override void takeValue (Player player){
		player.addExperience ((int) value);
	}
}
