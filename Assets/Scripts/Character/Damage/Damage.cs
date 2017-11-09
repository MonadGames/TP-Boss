using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	private Spell spell;
	private Stats stats;

	public Damage(Spell spell, Stats stats) {
		this.spell = spell;
		this.stats = stats;
	}

	public float getDamage(){
		return spell.damage + stats.getPlayer().damage;
	}
}
