﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : StatBar
{

	override public void updateBar(float value, float maxValue){
		Image image = bar.GetComponent<Image> ();
		if (value < 0.5 * maxValue) {
			image.color = Color.red;
		}
		image.transform.localScale = new Vector3(barScale.x * value * 0.01f, scale.y, scale.x);
	}
}

