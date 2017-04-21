using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private BoardManager boardManager;

	void Awake () {
		Debug.Log ("GameManager: Awake()");

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			// prevent from having a GameManager for each scene (we just want one)
			Destroy(gameObject);
		}
		// prevent from being destroyed from scene to scene
		DontDestroyOnLoad (gameObject);
		boardManager = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame () {
		boardManager.SetupScene ();
	}
}
