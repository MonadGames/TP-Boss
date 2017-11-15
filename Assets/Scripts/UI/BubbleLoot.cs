using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleLoot : MonoBehaviour {

	protected float value;

	public void setValue(float value){
		this.value = value;
	}

	public void OnCollisionStay2D (Collision2D collision) {
		if (collision.gameObject.name == "Player") {
			takeValue (collision.gameObject.GetComponent<Player>());
			Destroy(gameObject, 0.5f);
		}
	}

	public virtual void takeValue (Player player){}

}
