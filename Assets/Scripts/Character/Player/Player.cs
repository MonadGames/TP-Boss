using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	//ui 
	public GameObject skillSelected;
	public float powerHurtForce = 2f;
	public float hurtForce = 10f;
	public float timeOfDead = 1f;

	private SpriteRenderer[] spritesRenderers;
	private Spell  spellSelected;
	private float  lastHit = 0f;
	private float  secondsOfInvulnerability = 2f;
	private bool deadAnim = false;
	private CameraController cameraController;

	// core
	private Energy energy;
	private Stats stats; 
	private List<Quest> actualQuests;

	void Start () {
		//ui
		anim = GetComponent<Animator> ();
		spellSelected = skillSelected.GetComponent<Spell> ();
		cameraController = gameObject.GetComponentInChildren<CameraController>();
		spritesRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

		//core
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();
		stats = new Stats (this);
		actualQuests = new List<Quest> ();
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

		foreach (SpriteRenderer sprite in spritesRenderers) {
			Color color = sprite.color;
			color.a = (lastHit > 0) ? Mathf.Sin (Random.Range(-1f, 1f)) : 1f;
			sprite.material.color = color;
		}
	}

	public void updateDeath () {
		timeOfDead -= Time.deltaTime;

		if (!deadAnim) {
			anim.SetTrigger ("Die");
			deadAnim = true;
		}

		if (timeOfDead > 0) {
			foreach (SpriteRenderer sprite in spritesRenderers) {
				Color color = sprite.color;
				color.a = timeOfDead;
				sprite.material.color = color;
			}
		} else {
			this.die ();
		}
	}

	public bool canUseSkill() {
		return energy.canUse (spellSelected.damage);
	}

	public GameObject getSkillSelected() {
		return skillSelected;
	}

	public void takeDamage(float damage, Transform transformE){
		hurtEffect (transformE);
		if (lastHit <= 0) {
			lastHit = secondsOfInvulnerability;
			base.takeDamage (damage);
			cameraController.takeDamage ();
		}
	}

	public void hurtEffect(Transform transformE){
		float side = (transformE.localScale.x > 0) ? 1 : -1;

		Vector3 hurtVector = new Vector3(side  * powerHurtForce, 0, 0);
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
	}

	public Damage getDamage(Spell spell) {
		return stats.getDamage (spell);
	}

	public void addExperience(int exp) {
		stats.addExperience (exp);
	}

	public void addBadAction(){
		stats.addBadAction();
	}

	public void addGoodAction(){
		stats.addGoodAction();
	}

	public float getDefense() {
		return defense;
	}

	public void acceptQuest(Quest quest) {
		actualQuests.Add (quest);
	}

	public void completeQuest(Quest quest) {
		actualQuests.Remove (quest);
	}

}
