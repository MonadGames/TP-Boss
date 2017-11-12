using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	private Dictionary<Item, int> items;
	private float actualWeight;
	private float weightMax;

	public Inventory() {
		items = new Dictionary<Item, int>();
		weightMax = 10f;
		actualWeight = 0f;
	}

	public bool addItem(Item item){
		if(canAddItem(item)){
			if (haveItem (item)) {
				items [item]++;
			} else {
				items.Add (item, 1);
			}

			actualWeight += item.getWeight();
			return true;
		}
		return false;
	}

	public bool canAddItem(Item item) {
		return (actualWeight + item.getWeight ()) <= weightMax;
	}


	public bool haveItem(Item item){
		return items.ContainsKey (item);
	}

	public void useItem(Item item){
		if (haveItem (item) && items[item] > 0) {
			actualWeight -= item.getWeight ();
			item.use ();
			items [item]--;
		}
	}
}
