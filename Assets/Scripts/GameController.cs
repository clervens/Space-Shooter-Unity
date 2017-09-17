using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount = 10;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.gameObject.SetActive (false);
		restartText.gameObject.SetActive (false);
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		if (restart && Input.GetKeyDown(KeyCode.R)) {
			//Application.LoadLevel (Application.loadedLevel);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.gameObject.SetActive (true);
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOverText.gameObject.SetActive (true);
		gameOver = true;
	}
}
