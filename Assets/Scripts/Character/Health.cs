using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{	
	public float health = 100f;					// The player's health.
	public Vector2 scale;
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private Player playerControl;		// Reference to the Player script.
	private Animator anim;						// Reference to the Animator on the player


	void Awake () {
		playerControl = GetComponent<Player>();
		anim = GetComponent<Animator>();
		healthScale = healthBar.transform.localScale;
	}

	public void takeDamage (float damage, Transform enemyTransform) {
		if (health > 0f) {
			Vector3 hurtVector = transform.position - enemyTransform.position + Vector3.up * 0.5f;
			GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
			health -= damage;
			UpdateHealthBar();
		} else anim.SetTrigger ("Die");
			
	}
		
	public void UpdateHealthBar () {
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, scale.y, scale.x);
	}
}
