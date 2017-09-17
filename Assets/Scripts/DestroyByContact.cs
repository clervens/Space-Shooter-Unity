using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue = 10;
	private GameController gameController;

	private Transform objTransform;

	// Use this for initialization
	void Start () {
		objTransform = GetComponent<Transform> ();
		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");

		if (gameControllerObj != null) {
			gameController = gameControllerObj.GetComponent<GameController>();
		}

		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, objTransform.position, objTransform.rotation);

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);	
	}
}
