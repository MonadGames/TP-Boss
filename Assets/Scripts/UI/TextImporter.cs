using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {
	public TextAsset dialog;
	public string[] phrases;

	// Use this for initialization
	void Start () {
		if(dialog != null){
			phrases = (dialog.text.Split('\n'));
		}
	}

}
