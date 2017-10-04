using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	public GameObject skillSelected;

	private Spell  spellSelected;
	private int    countOfBadActions = 0;
	private Energy energy;
	private float  lastHit = 0f;
	private float  secondsOfInvulnerability = 1f;
	private CameraController camera;

	void Start () {
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();
		camera = gameObject.GetComponent<CameraController>();
		spellSelected = skillSelected.GetComponent<Spell> ();
		// por ahora asi, luego podria haber una lista de instancias de skills a seleccionar.
		//skillSelected = new Skill ();
	}

	void Update () {
		lastHit -= Time.deltaTime;
	}

	public bool canUseSkill() {
		return energy.canUse (spellSelected.damage);
	}
		
	public void OnCollisionEnter2D (Collision2D collision) {
	}

	public void OnCollisionExit2D (Collision2D collision) {
	}

	public GameObject getSkillSelected() {
		return skillSelected;
	}

	public void takeDamage(float damage,Transform transform){
		if (lastHit <= 0) {
			lastHit = secondsOfInvulnerability;
			base.takeDamage (damage, transform);
			camera.takeDamage ();
		}
	}

	public float totalDamage(Spell spell){
		return (spell.damage + damage);
	}

}
