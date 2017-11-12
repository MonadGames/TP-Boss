using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHealthBar : HealthBar
{

	override public void updateHealthBar(float health, float maxHealth){
		SpriteRenderer image = healthBar.GetComponent<SpriteRenderer> ();

		image.color = Color.Lerp(image.material.color, Color.red, 1 - health * 0.01f);
		image.transform.localScale = new Vector3(healthScale.x * health * 0.01f, scale.y, scale.x);
	}
}

