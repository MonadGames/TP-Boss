using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	//public float attackSpeed;

	public float cd = 0.5f;
	public float lastTime = 0.5f;
	private Player player;
	private Animator anim;
	private PlayerMovementInX movementInX;

	void Start () {
		player = gameObject.GetComponent<Player> ();
		anim = gameObject.GetComponent<Animator> ();
		movementInX = gameObject.GetComponent<PlayerMovementInX> ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt)) {
			if(lastTime >= cd)
				useSkill ();
		}

		lastTime += Time.deltaTime;
	}

	void useSkill () {	
		if (gameObject.GetComponent<Player> ().canUseSkill ()) {
			anim.SetTrigger ("Cast Spell");
		}
	}

	public void castSpell(){
		GameObject instanceSkill = (GameObject)Instantiate(
			player.getSkillSelected(),
			// aca deberiamos cambiar la posicion para que salga de la mano.
			// tenemos un problema con la posicion del skill. Al parecer 
			new Vector2(player.transform.position.x, player.transform.position.y + 0.4f),
			player.transform.rotation);
		if (!movementInX.getIsRight()){
			instanceSkill.transform.Rotate (0, 0, 180);
		}
		//instanceSkill.GetComponent<Animator> ().avatar = player;

		Destroy(instanceSkill, 1f);    

		lastTime = 0;
	}
}
