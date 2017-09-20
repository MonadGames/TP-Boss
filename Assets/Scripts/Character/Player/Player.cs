using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	private int countOfBadActions = 0;
	private Skill skillSelected;
	private Energy energy;

	void Start () {
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();

		// por ahora asi, luego podria haber una lista de isntancias de skills a seleccionar.
		skillSelected = new Skill ();
	}

	void Update () {
	}

	public void canUseSkill() {
		return energy.canUse (skillSelected);
	}
		
	public void OnCollisionEnter2D (Collision2D collision) {
	}

	public void OnCollisionExit2D (Collision2D collision) {
	}

	public Skill getSkillSelected() {
		return skillSelected;
	}

}
