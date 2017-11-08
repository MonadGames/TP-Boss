using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private Dictionary<Item, int> items;
	private int weight;

	public Inventory() {
		items = new List<Item> ();
		weight = 10;
	}

	public bool addItem(Item item){
		items.Add(item, )
	}

	public bool haveItem(Item item){
		return inventory.haveItem (item);
	}

	public void useItem(Item item){
		inventory.useItem (item);
	}
}
