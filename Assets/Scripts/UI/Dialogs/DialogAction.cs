using UnityEngine;
using System.Collections;

public abstract class DialogAction : MonoBehaviour
{
	public GameObject highlight;
	public bool closeDialogWhenFinished;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void showHighlight(bool show){
		highlight.SetActive (show);
	}

	public abstract void performAction ();
}

