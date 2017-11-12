using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {
	
	private Quest principalQuest;
	private List<Quest> quests;

	void Start () {
		quests = new List<Quest> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPrincipalQuest(Quest quest){
		principalQuest = quest;
	}
}
