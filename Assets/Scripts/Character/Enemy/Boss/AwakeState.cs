using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeState : BossState {

	private Boss boss;

	public AwakeState(Boss boss) {
		this.boss = boss;
	}

	public override void update() {
		if (!boss.getAI ().enabled && boss.IsPlayingIdle()) {
			boss.getAI ().enabled = true;
		}

		if (boss.getPlayer ().isDead()) {
			float posXPlayer = boss.getPlayer ().transform.position.x;
			Vector3 pos = boss.transform.position;
			boss.transform.position.Set (posXPlayer - 10, pos.y, pos.z);
		}
	}

	public override bool isAwake (){
		return true;
	}
}
