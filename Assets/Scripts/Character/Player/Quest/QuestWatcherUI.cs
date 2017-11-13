using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestWatcherUI : MonoBehaviour
{
	public Player player;
	public Text questText;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Quest quest = player.getMainQuest ();
		if (quest != null) {
			questText.text = player.getMainQuest ().questName;
		}
	}
}

