using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKillEnemiesRequirement", menuName = "Requirement/Kill Enemies")]
public class KillEnemiesRequirement : Requirement {

	public int requiredDeaths;
	public int deadCount = 0;
	public List<string> enemyTypes;

	public override void notify(string enemy) {
		if (enemyTypes.Contains (enemy)) {
			deadCount++;
		}

	}

	void OnEnable() {
		EnemyNotificationSystem system = GameObject.FindObjectOfType<EnemyNotificationSystem> ();
		system.subscribe (this);
	}

	public override void checkProgress(Player player){
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy> ();
		isCompleted = deadCount >= requiredDeaths || enemies.Length == 0;
	}

}
