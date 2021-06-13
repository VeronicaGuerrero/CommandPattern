using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour {

	private static Color SELECTED_CUBE_COLOR = new Color (0.777f,0.8f,0.604f, 1);
	private static Color NOT_SELECTED_CUBE_COLOR = new Color (0f,0f,0f, 1);

	public static void setMaterialToSelectedCube(){

		foreach (Transform child in RegistryCommandPattern.CUBES_PARENT.transform){
			if(RegistryCommandPattern.CURRENT_CUBE.gameObject.name != child.gameObject.name){
				child.GetComponent<Renderer> ().material.color = NOT_SELECTED_CUBE_COLOR;
			}
		}
		RegistryCommandPattern.CURRENT_CUBE.GetComponent<Renderer>().material.color = SELECTED_CUBE_COLOR;
	}

}
