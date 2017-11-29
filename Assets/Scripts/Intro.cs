using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	public float intro = 8f;
	public float story = 105f;
	public GameObject logo;
	public GameObject video;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (changeScene ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene("Scene3");
		}
	}

	public IEnumerator changeScene(){
		yield return new WaitForSeconds (intro);
		logo.SetActive (false);
		video.SetActive (true);
		yield return new WaitForSeconds (story);
		SceneManager.LoadScene("Scene3");
	}
}

