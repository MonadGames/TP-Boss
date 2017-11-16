using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {

	public GameObject popupTakeDamage;
	public GameObject popupGetExp;
	public GameObject popupHeal;
	public GameObject popupEnergy;

	public GameObject canvas;

    void Start() {
    }

	public void createTakeDamage(string text, Transform location) {
		createBattleText ("-" + text, location, popupTakeDamage);
	}

	public void createGetExperience(string text, Transform location) {
		createBattleText ("+" + text + " EXP", location, popupGetExp);
	}

	public void createHeal(string text, Transform location) {
		createBattleText ("+" + text, location, popupHeal);
	}

	public void createEnergy(string text, Transform location) {
		createBattleText ("+" + text, location, popupEnergy);
	}

	public void createBattleText(string text, Transform location, GameObject objectText) {
		FloatingText instance = Instantiate(objectText.GetComponent<FloatingText>());

		Vector2 screenPosition = new Vector2 ();
		screenPosition.Set (location.position.x, location.position.y + 1);

		instance.transform.SetParent(canvas.transform, false);
		instance.transform.position = screenPosition;
		instance.SetText(text);
	}
}
