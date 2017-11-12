using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRequirement : Requirement {

	private Vector2 objetivePos;

	public PositionRequirement(Player player, Vector2 vector) : base(player) {
		objetivePos = vector;
	}

	public new void checkProgress(){
		Vector3 playerPos = player.transform.position;

		float diffX = Mathf.Abs(playerPos.x - objetivePos.x);
		float diffY = Mathf.Abs(playerPos.y - objetivePos.y);

		isCompleted = (between (diffX, -1, 1) && between (diffY, -1, 1));
	}

	public bool between(float point, float from, float to) {
		return (point >= from) && (point <= to);
	}

}
