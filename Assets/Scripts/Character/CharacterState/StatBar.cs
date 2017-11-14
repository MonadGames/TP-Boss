using UnityEngine;
using System.Collections;

public abstract class StatBar : MonoBehaviour
{
	public GameObject bar;
	public Vector2 scale;
	protected Vector3 barScale;// The local scale of the health bar initially (with full health).

	// Use this for initialization
	void Awake ()
	{
		barScale = bar.transform.localScale;
	}

	public abstract void updateBar(float value, float maxValue);

	public void hide(){
		bar.SetActive(false);
	}

	public void show(){
		bar.SetActive(true);
	}
}

