using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{	
	public float health = 100f;					// The player's health.
	public float powerHurtForce = 2f;
	public Vector2 scale;
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private Animator anim;						// Reference to the Animator on the player


	void Awake () {
		anim = GetComponent<Animator>();
		healthScale = healthBar.transform.localScale;
	}

	void Update(){
		if (health <= 0) {
			anim.SetTrigger ("Die");
		}
	}

	public void takeDamage (float damage, Transform enemyTransform) {
		if (health > 0f && damage > 0) {
			Vector3 hurtVector = transform.position - enemyTransform.position + enemyTransform.localScale  * powerHurtForce; //Vector3.up
			GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
			health -= damage;
			UpdateHealthBar();
		}
	}
		
	public void UpdateHealthBar () {
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, scale.y, scale.x);
	}
}
