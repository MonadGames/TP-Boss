using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{

	override public void updateHealthBar(float health, float maxHealth){
		Image image = healthBar.GetComponent<Image> ();
		if (health < 0.5 * maxHealth) {
			image.color = Color.Lerp(image.material.color, Color.red, 1 - health * 0.01f);
		}
		image.transform.localScale = new Vector3(healthScale.x * health * 0.01f, scale.y, scale.x);
	}
}

