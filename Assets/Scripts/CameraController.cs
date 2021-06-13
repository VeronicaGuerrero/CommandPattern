using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private float TRANSITION_SPEED = 2.5f;
	private Quaternion targetRotation;

	// Update is called once per frame
	void Update () {

		if(isCurrentCube()){
			lookAtCurrentCube ();
		}
	}

	private void lookAtCurrentCube(){
		targetRotation = Quaternion.LookRotation (RegistryCommandPattern.CURRENT_CUBE.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation, TRANSITION_SPEED * Time.deltaTime);
	}

	private bool isCurrentCube(){
		return RegistryCommandPattern.CURRENT_CUBE != null ? true : false;
	}
}
