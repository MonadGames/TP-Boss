using UnityEngine;
using System.Collections;

public abstract class HealthBar : MonoBehaviour
{
	public GameObject healthBar;
	public Vector2 scale;
	protected Vector3 healthScale;// The local scale of the health bar initially (with full health).

	// Use this for initialization
	void Awake ()
	{
		healthScale = healthBar.transform.localScale;
	}

	public abstract void updateHealthBar(float health, float maxHealth);

	public void hide(){
		healthBar.GetComponent<MonoBehaviour> ().enabled = false;
	}

	public void show(){
		healthBar.GetComponent<MonoBehaviour> ().enabled = true;
	}
}

