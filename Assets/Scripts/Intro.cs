using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	public float seconds = 8f;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (changeScene ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public IEnumerator changeScene(){
		yield return new WaitForSeconds (seconds);
		SceneManager.LoadScene("Scene3");
	}
}

