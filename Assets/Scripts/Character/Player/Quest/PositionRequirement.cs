using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPositionRequirement", menuName = "Requirement/Position")]
public class PositionRequirement : Requirement {

	public Vector2 objetivePos;

	public override void checkProgress(){
		Vector3 playerPos = player.gameObject.transform.position;
		float diffX = Mathf.Abs(playerPos.x - objetivePos.x);
		float diffY = Mathf.Abs(playerPos.y - objetivePos.y);
		isCompleted = (between (diffX, -5, 5) && between (diffY, -5, 5));
	}

	public bool between(float point, float from, float to) {
		return (point >= from) && (point <= to);
	}

}
