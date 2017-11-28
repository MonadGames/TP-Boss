using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityView : MonoBehaviour {

	public Sprite goodImage;
	public Sprite badImage;
	public Sprite neutralImage;


	private Image myImage;
	private Player player;
	private Sanity actualState;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
		actualState = null;
		myImage = GetComponent<Image> ();
	}

	void Update () {
		checkSanity ();	
	}

	public void checkSanity() {
		Sanity state = player.getStats ().getSanity ();
		if (state != actualState) {
			myImage.sprite = (state.isNetrual ()) ? neutralImage : (state.isGood ()) ? goodImage : badImage;
			actualState = state;
		}
	}
}
