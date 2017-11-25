using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFinalLvl : MonoBehaviour {

	public GameObject removablePlatform;
	public GameObject bossPlatform;
	public GameObject invisiblePath;

	public GameObject cameraPlayer;
	public AudioClip suspensiveSong;

	private Player player;


	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}

	void Update () {
		checkShowFinalLvl ();
	}

	public void checkShowFinalLvl() {
		checkShowBoss ();
		checkShowInvisibleFloors();
	}

	public void checkShowBoss() {
		if (GameObject.FindObjectsOfType<Enemy> ().Length == 0 && !bossPlatform.active) {
			bossPlatform.SetActive (true);
			AudioSource source = cameraPlayer.GetComponent<AudioSource> ();
			source.clip = suspensiveSong;
			source.Play ();
		}
	}

	public void checkShowInvisibleFloors() {
		bool bossCondition = bossPlatform.active && GameObject.FindObjectOfType<Boss> ().isAwake ();
		if(bossCondition && removablePlatform.active && !invisiblePath.active) {
			removablePlatform.SetActive(false);
			invisiblePath.SetActive(true);
		}
	}

}
