using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	private int countOfGoodActions = 0;
	public GameObject skillSelected;

	private int countOfBadActions = 0;
	private Energy energy;

	void Start () {
		health = gameObject.GetComponent<Health>();
		energy = gameObject.GetComponent<Energy>();

		// por ahora asi, luego podria haber una lista de instancias de skills a seleccionar.
		//skillSelected = new Skill ();
	}

	void Update () {
	}

	public bool canUseSkill() {
		return energy.canUse (20);
	}
		
	public void OnCollisionEnter2D (Collision2D collision) {
	}

	public void OnCollisionExit2D (Collision2D collision) {
	}

	public GameObject getSkillSelected() {
		return skillSelected;
	}

}
