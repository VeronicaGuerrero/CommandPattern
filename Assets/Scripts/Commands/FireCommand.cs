using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command {

	private GameObject bullet;
	private Rigidbody bulletRigidBody;
	private float BULLET_FORCE = 1000f;
	private float distacia;
	private Vector3 actorPosition, direction, shootVector;
	public static Vector3 targetPosition;

	public void execute(GameObject actor){
		Debug.Log ("Actor --> " + actor.name + " Cmd --> Fire");
		actorPosition = actor.transform.position;
		shootVector = targetPosition - actorPosition;
		shootVector.Normalize ();
		createBullet ();
		bulletRigidBody.AddForce (shootVector * BULLET_FORCE);
		Debug.DrawLine (targetPosition, actorPosition, Color.green, 2);
	}

	private void createBullet(){
		//Crear balla
		bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bullet.gameObject.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		bullet.gameObject.transform.position = actorPosition + Vector3.up;
		bulletRigidBody = bullet.AddComponent<Rigidbody> ();
		bulletRigidBody.mass = 0.5f;
		RegistryCommandPattern.CUBE_MONOBEHAVIOUR.StartCoroutine (destroyBullet(bullet));
	}

	IEnumerator destroyBullet(GameObject bullet){
		yield return new WaitForSeconds (2);
		Object.Destroy (bullet);
	}

}
