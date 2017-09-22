using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	//public float attackSpeed;

	public float delay = 0.5f;
	public float lastTime = 0.5f;
	private Player player;

	void Start () {
		player = gameObject.GetComponent<Player> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			if(lastTime >= delay)
				useSkill ();
		}

		lastTime += Time.deltaTime;
	}

	void useSkill () {	
		if (gameObject.GetComponent<Player> ().canUseSkill ()) {
			GameObject instanceSkill = (GameObject)Instantiate(
				player.getSkillSelected(),
				// aca deberiamos cambiar la posicion para que salga de la mano.
				player.transform.position,
				player.transform.rotation);

			Destroy(instanceSkill, 1.0f);    

			lastTime = 0;
		}
	}
}
