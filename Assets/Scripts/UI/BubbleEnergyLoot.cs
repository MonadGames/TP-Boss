using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEnergyLoot : BubbleLoot {

	public override void takeValue (Player player){
		player.addEnergy (value);
		int valueText = (int) value;
		textController.createEnergy (valueText.ToString (), player.gameObject.transform);
		player.takeItem ();
	}
}
