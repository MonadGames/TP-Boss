﻿using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {

	public GameObject popupTakeDamage;
	public GameObject popupGetExp;
	public GameObject popupHeal;

    void Start() {
    }

	public void createTakeDamage(string text, Transform location) {
		createBattleText (text, location, popupTakeDamage);
	}

	public void createGetExperience(string text, Transform location) {
		createBattleText (text, location, popupGetExp);
	}

	public void createHeal(string text, Transform location) {
		createBattleText (text, location, popupHeal);
	}

	public void createBattleText(string text, Transform location, GameObject objectText) {
		FloatingText instance = Instantiate(objectText.GetComponent<FloatingText>());

		Vector2 screenPosition = new Vector2 ();
		screenPosition.Set (location.localPosition.x, location.localPosition.y + 1);

		instance.transform.SetParent(location, false);
		instance.transform.position = screenPosition;
		instance.SetText(text);
	}
}
