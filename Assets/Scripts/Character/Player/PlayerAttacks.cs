using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	public AudioClip spellSound;
	public float cd = 0.5f;
	public float cdNormalAttack = 0f;
	public float lastTime = 0.5f;

	private Player player;
	private AudioSource source;
	private Animator anim;
	private PlayerMovementInX movementInX;


	void Start () {
		source = GetComponent<AudioSource> ();
		player = gameObject.GetComponent<Player> ();
		anim = gameObject.GetComponent<Animator> ();
		movementInX = gameObject.GetComponent<PlayerMovementInX> ();
	}

	void Update () {
		checkSpellAttack ();
		checkNormalAttack ();
		lastTime += Time.deltaTime;
	}

	public void checkSpellAttack () {
		if (Input.GetKey (KeyCode.Z) && lastTime >= cd) {
			useSkill ();
		}
	}

	public void checkNormalAttack() {
		if(player.skillSelected != null){
			if (Input.GetKeyUp (KeyCode.X) && lastTime >= cdNormalAttack) {
				anim.SetTrigger ("NormalAttack");
			}
		}
	}

	void useSkill () {	
		if (player.canUseSkill ()) {
			anim.SetTrigger ("Cast Spell");
			lastTime = 0;
		}
	}

	public void castSpell() {
		source.PlayOneShot (spellSound, 1f);
		GameObject instanceSkill = (GameObject)Instantiate( player.getSkillSelected(), new Vector2(player.transform.position.x, player.transform.position.y + 0.4f), player.transform.rotation);

		if (!movementInX.getIsRight()){
			instanceSkill.transform.Rotate (0, 0, 180);
		}
		Destroy(instanceSkill, 1f);    
		 
		lastTime = 0;
	}
}
