using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler{

	private Command CmdJump, CmdMove, CmdFire;

	public Command HandleInput(){
	
		//TO JUMP
		if(Input.GetAxis("Jump") != 0){
			CmdJump = new JumpCommand ();
			return CmdJump;
		}

		//TO MOVE
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
			CmdMove = new MoveCommand ();
			MoveCommand.vertical_input = Input.GetAxis ("Vertical");
			MoveCommand.horizontal_input = Input.GetAxis ("Horizontal");
			return CmdMove;
		}

		if(Input.GetAxis("Fire1") != 0){

			// Saber si le estamos dando click a un actor
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				if(hit.transform.gameObject.tag == "Actor"){
					RegistryCommandPattern.CURRENT_CUBE = hit.transform.gameObject;
					MaterialManager.setMaterialToSelectedCube ();
				}
				// Si estamos dando click para disparar
				else if(RegistryCommandPattern.CURRENT_CUBE != null){
					CmdFire = new FireCommand ();
					FireCommand.targetPosition = hit.point;
					return CmdFire;
				}
			}
		}
		return null;
	}
}
