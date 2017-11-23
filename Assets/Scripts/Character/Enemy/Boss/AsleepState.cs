using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsleepState : BossState {

	private Boss boss;

	public AsleepState(Boss boss) {
		this.boss = boss;
	}

	public override void update() {
		float range = Vector2.Distance (boss.transform.position, boss.getPlayer().transform.position);

		if (range <= boss.rangeOfAwake) {
			boss.getAnim().SetTrigger ("Awake");
			boss.setState(new AwakeState (boss));
		}
	}
}
