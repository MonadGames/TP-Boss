﻿using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private PostProcessingBehaviour postProcessing; 

	private Vector3 lastPosition;
	float shakeElapsed = 1f;
	float shakeDuration = 0.5f;
	float shakeMagnitude = 0.2f;

	private Vector3 offset;

	void Start () {
		postProcessing = gameObject.GetComponent<PostProcessingBehaviour>();
		offset = transform.position - player.transform.position;
	}

	void Update () {
		
		if (shakeElapsed < shakeDuration) {
			shakeElapsed += Time.deltaTime;          

			float percentComplete = shakeElapsed / shakeDuration;         
			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;

			Vector3 newPos = new Vector3 (x, y, 0);
			newPos *= shakeMagnitude * damper;
			newPos += (player.transform.position + offset);

			transform.position = newPos;
		
		} else {
			transform.position = player.transform.position + offset;
		}
	}

	public void takeDamage(){
		lastPosition = transform.position;
		shakeElapsed = 0.0f;
	}
}
