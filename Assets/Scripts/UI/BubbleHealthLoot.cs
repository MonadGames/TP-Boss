﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHealthLoot : BubbleLoot {

	public override void takeValue (Player player){
		player.addHealth (value);
	}
}
