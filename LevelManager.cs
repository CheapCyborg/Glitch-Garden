using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {
	public float autoLoadNextLevelAfter;

	private void Start() {
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log("Level auto load disabled, use a positvie number in seconds");
		}
		else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void MainMenu(string start) {
		Debug.Log("Return to main menu requested");
		SceneManager.LoadScene(start);
	}

	public void QuitGame() {
		Debug.Log("Game quit requested");
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}

