using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private InputHandler inputHandler;
	// Use this for initialization
	void Start () {
		inputHandler = new InputHandler ();
		RegistryCommandPattern.CUBE_MONOBEHAVIOUR = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(inputHandler.HandleInput() != null && RegistryCommandPattern.CURRENT_CUBE != null){
			Command cmd = inputHandler.HandleInput ();
			cmd.execute (RegistryCommandPattern.CURRENT_CUBE);
		}
	}
}
