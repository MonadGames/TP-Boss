using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeState : BossState {

	private Boss boss;

	public AwakeState(Boss boss) {
		this.boss = boss;
	}

	public override void update() {
		if (!boss.getAI ().enabled) {
			boss.getAI ().enabled = true;
		}
	}
}
