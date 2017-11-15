using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour {

	public GameObject expPrefab;
	public GameObject healthPrefab;
	public GameObject energyPrefab;
	public GameObject canvas;

	public void loot(Transform location, float exp) {
		lootExperience (location, exp);
		lootHealth (location);
		lootEnergy (location);
	}

	public void lootExperience(Transform location, float exp) {
		looting (location, expPrefab, exp);
	}

	public void lootHealth(Transform location) {
		if (Random.Range (0, 1) == 1) {
			looting (location, healthPrefab, Random.Range (5, 15f));
		}
	}

	public void lootEnergy(Transform location) {
		if (Random.Range (0, 1) == 1) {
			looting (location, energyPrefab, Random.Range (5, 10f));
		}
	}

	public void looting(Transform location, GameObject prefab, float value) {
		
		BubbleLoot instance = Instantiate(prefab.GetComponent<BubbleLoot>());

		Vector2 screenPosition = new Vector2 ();
		screenPosition.Set (location.position.x, location.position.y + 1);

		instance.transform.SetParent(canvas.transform, false);
		instance.transform.position = screenPosition;
		instance.setValue(value);
	}

}
