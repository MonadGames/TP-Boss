using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {
	
	public Quest mainQuest;
	private List<Quest> quests;

	void Start () {
		quests = new List<Quest> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool hasQuest(){
		return mainQuest != null;
	}

	public Quest getMainQuest(){
		return mainQuest;
	}

	public void setMainQuest(Quest quest){
		mainQuest = quest;
	}
}
