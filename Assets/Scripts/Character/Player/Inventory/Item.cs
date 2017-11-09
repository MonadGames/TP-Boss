using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	protected float weight;
	protected string nameItem;

	public Item(string name, float weight) {
		this.weight = weight;
		this.nameItem = name; 
	}

	public abstract void use ();

	public float getWeight() { 
		return this.weight;
	}

	public string getName() { 
		return nameItem;
	}
}
