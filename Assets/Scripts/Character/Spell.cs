using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	public float damage;

	public float costEnergy;

	// Use this for initialization
	void Start () {
		
	}

	public float cost(){
		return costEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
