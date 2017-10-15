using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	//public float attackSpeed;

	public AudioClip spellSound;
	public float cd = 0.5f;
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
		if (Input.GetKey (KeyCode.Z) && lastTime >= cd)
			useSkill ();
		
		lastTime += Time.deltaTime;
	}

	void useSkill () {	
		if (gameObject.GetComponent<Player> ().canUseSkill ()) {
			anim.SetTrigger ("Cast Spell");
			lastTime = 0;
		}
	}

	public void castSpell(){

		source.PlayOneShot (spellSound, 1f);
		GameObject instanceSkill = (GameObject)Instantiate( player.getSkillSelected(), new Vector2(player.transform.position.x, player.transform.position.y + 0.4f), player.transform.rotation);

		if (!movementInX.getIsRight()){
			instanceSkill.transform.Rotate (0, 0, 180);
		}
		Destroy(instanceSkill, 1f);    

		lastTime = 0;
	}
}
