using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameManager;

	void Awake () {
		Debug.Log ("Loader: Awake()");

		if (GameManager.instance == null) {
			Debug.Log ("Loader: Instantiating GameManager");

			Instantiate(gameManager);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
