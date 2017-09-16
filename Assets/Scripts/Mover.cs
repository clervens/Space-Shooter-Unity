using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed = 20;

	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		Transform transform = GetComponent<Transform> ();
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
