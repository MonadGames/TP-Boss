using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	public GameObject skillSelected;

	private SpriteRenderer[] spritesRenderers;
	private Spell  spellSelected;
	private int    countOfBadActions = 0;
	private Energy energy;
	private float  lastHit = 0f;
	private float  secondsOfInvulnerability = 2f;

	public float powerHurtForce = 2f;
	public float hurtForce = 10f;
	public float timeOfDead = 1f;

	private CameraController camera;

	void Start () {
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();
		spellSelected = skillSelected.GetComponent<Spell> ();
		camera = gameObject.GetComponentInChildren<CameraController>();
		spritesRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
		// por ahora asi, luego podria haber una lista de instancias de skills a seleccionar.
		//skillSelected = new Skill ();
	}

	void Update () {
		if (!isDead ()) {
			checkVulnerability ();	
		} else {
			updateDeath ();
		}


	}

	public void checkVulnerability(){
		lastHit -= Time.deltaTime;

		//float transparencyFactor = (lastHit > 0) ? Mathf.Sin (Random.Range(-1f, 1f)) : 1f;
		foreach (SpriteRenderer sprite in spritesRenderers) {
			Color color = sprite.color;
			color.a = (lastHit > 0) ? Mathf.Sin (Random.Range(-1f, 1f)) : 1f;
			sprite.material.color = color;
		}
	}

	public void updateDeath () {
		timeOfDead -= Time.deltaTime;

		if (timeOfDead > 0) {
			foreach (SpriteRenderer sprite in spritesRenderers) {
				Color color = sprite.color;
				color.a = timeOfDead;
				sprite.material.color = color;
			}
		}
	}

	public bool canUseSkill() {
		return energy.canUse (spellSelected.damage);
	}

	public GameObject getSkillSelected() {
		return skillSelected;
	}

	public void takeDamage(float damage,Transform transform){
		hurtEffect (transform);
		if (lastHit <= 0) {
			lastHit = secondsOfInvulnerability;
			base.takeDamage (damage, transform);
			camera.takeDamage ();
		}
	}

	public void hurtEffect(Transform transform){
		Vector3 hurtVector = transform.position - transform.position + transform.localScale  * powerHurtForce;
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
	}

	public float totalDamage(Spell spell){
		return (spell.damage + damage);
	}

}
