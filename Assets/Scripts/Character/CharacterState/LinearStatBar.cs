using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LinearStatBar : StatBar
{

	override public void updateBar(float value, float maxValue){
		Image image = bar.GetComponent<Image> ();
		image.transform.localScale = new Vector3(barScale.x * value * 0.01f, scale.y, scale.x);
	}
}

