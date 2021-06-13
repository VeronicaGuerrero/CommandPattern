using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command {

	private float JUMP_FORCE = 50f;
	private Vector3 jumpVector = Vector3.up; //(0,1,0)

	public void execute(GameObject actor){
		Debug.Log ("Actor --> " + actor.name + " Cmd --> Jump");
		if(actor.transform.position.y < 1.5f){
			actor.GetComponent<Rigidbody> ().AddForce (jumpVector * JUMP_FORCE);
		}

	}
}
