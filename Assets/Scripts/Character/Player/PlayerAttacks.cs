using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	public float attackSpeed;

	private Player player;

	void Start () {
		player = gameObject.GetComponent<Player> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			useSkill ();
		}
	}

	void useSkill () {	
		// use skill devuelve true si tenia energia suficiente y lo decrementa
		if (gameObject.GetComponent<Player> ().canUseSkill ()) {
			
			Skill skill = player.getSkillSelected ();

			GameObject instanceSkill = (GameObject)Instantiate(
				player.getSkillSelected().prefab(),
				// aca deberiamos cambiar la posicion para que salga de la mano.
				player.transform.position,
				player.transform.rotation);

			instanceSkill.GetComponent<Rigidbody>().velocity = attackSpeed;

			Destroy(instanceSkill, 2.0f);    
		}
	}
}
