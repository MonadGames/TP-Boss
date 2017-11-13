using UnityEngine;
using System.Collections;

public class VisibilityToggle : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ToggleVisibility(){
		this.gameObject.SetActive (!this.gameObject.activeSelf);
	}
}

