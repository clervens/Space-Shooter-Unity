using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float tilt = 4;
	public PlayerBoundary boundary;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Rigidbody playerRigidBody = GetComponent<Rigidbody> ();
		playerRigidBody.velocity = movement * speed;
		playerRigidBody.position = new Vector3 (
			Mathf.Clamp(playerRigidBody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(playerRigidBody.position.z, boundary.zMin, boundary.zMax)
		);
		playerRigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
	}
}

[System.Serializable]
public class PlayerBoundary {
	public float xMin = -5, xMax = 5, zMin = -4, zMax = 10;
}
