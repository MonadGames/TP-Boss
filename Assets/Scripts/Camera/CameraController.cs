using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private PostProcessingBehaviour postProcessing; 

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		postProcessing = gameObject.GetComponent<PostProcessingBehaviour>();
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}

	public void takeDamage(){
		postProcessing.profile; // falta terminar esto
	}
}
