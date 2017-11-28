using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour {

	public Text damage;
	public Text defense;
	public Text maxHp;
	public Text maxSp;
	public Text countOfGoodActions;
	public Text countOfBadActions;

	private Player player;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		renderTexts ();
	}

	public void renderTexts() {
		damage.text = player.getDamage ().ToString();
		defense.text = player.getDefense ().ToString();
		maxHp.text = player.getHealth ().maxHealth.ToString();
		maxSp.text = player.getEnergy ().maxEnergy.ToString();
		countOfGoodActions.text = player.getStats ().getSanity ().getCountOfGoodActions ().ToString();
		countOfBadActions.text = player.getStats ().getSanity ().getCountOfBadActions ().ToString();
	}
}
