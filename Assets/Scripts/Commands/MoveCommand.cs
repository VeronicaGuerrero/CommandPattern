using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {

	private Vector3 movement;
	private float MOVE_FORCE = 10f;
	public static float vertical_input, horizontal_input;

	public void execute(GameObject actor){
		Debug.Log ("Actor --> " + actor.name + " Cmd --> Move");
		movement = new Vector3 (horizontal_input, 0, vertical_input);
		actor.GetComponent<Rigidbody> ().AddForce (movement * MOVE_FORCE);
	}
}
