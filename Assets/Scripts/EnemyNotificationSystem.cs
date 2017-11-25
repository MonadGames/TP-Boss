using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyNotificationSystem : MonoBehaviour
{
	private List<Requirement> requirements;

	// Use this for initialization
	void Start ()
	{
		requirements = new List<Requirement> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void notifyDeath(string enemyType) {
		foreach (Requirement requirement in requirements) {
			requirement.notify (enemyType);
		}
	}

	public void subscribe(Requirement requirement) {
		requirements.Add (requirement);
	}

	public void unsubscribe(Requirement requirement) {
		requirements.Remove (requirement);
	}


}

