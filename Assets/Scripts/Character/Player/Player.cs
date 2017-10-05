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
		spellSelected = skillSelected.GetComponent<Spell> ();
		camera = gameObject.GetComponentInChildren<CameraController>();

		// por ahora asi, luego podria haber una lista de instancias de skills a seleccionar.
		//skillSelected = new Skill ();
	}

	void Update () {
		lastHit -= Time.deltaTime;
	}

	public bool canUseSkill() {
		return energy.canUse (spellSelected.damage);
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

	public void die(){
		anim.SetTrigger ("Die");
		//Aca definir el Game over.
	}
}
