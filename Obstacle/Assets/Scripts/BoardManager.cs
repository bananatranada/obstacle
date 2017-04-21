using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
//using Obstacle;

// Script (non-prefab)

// water (visual)
//11111111111
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11000000011
//11111111111


public class BoardManager : MonoBehaviour {

	public int columns = 100;
	public int rows = 100;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;

	// refactor somehow
	private Obstacle obstacle;
	private float totalTime;
	private List<List<List<char>>> timeframes;
	private float currentTime = 0.0f;
	private int frameCounter = 0;

	private Transform boardHolder;


	public void SetupScene () {
		BoardSetup ();
		
		// test; reading from resources
//		TextAsset ta = Resources.Load("level_3") as TextAsset;
//		obstacle = ObstacleBuilder.Build (ta.text);
//		timeframes = obstacle.GetTimeframes ();
//		totalTime = obstacle.GetTotalTime ();
	}

	void BoardSetup () {
		Debug.Log ("Setting up the board");
		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
//				GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
//				GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0.0f), Quaternion.identity) as GameObject;
//				instance.transform.SetParent(boardHolder);

				// walls
//				if (x < 2 || x > 8) {
//					GameObject toInstantiate = wallTiles[0];
//					GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0.0f), Quaternion.identity) as GameObject;
//					instance.transform.SetParent(boardHolder);
//					continue;
//				} 

				// checkered floor (if x and y are the same even/odd pair, use dark floor)
				if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0)) {
					GameObject toInstantiate = floorTiles[0];
					GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0.0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				} else {
					GameObject toInstantiate = floorTiles[1];
					GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0.0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}
	}

	// placeholder
//	IEnumerator RemoveExplosion (GameObject obj) {
//		yield return new WaitForSeconds(0.1f);
//		obj.SetActive (false);
//		obj.transform.position = new Vector3 (0, 0, 0.0f);
//		// disable and remove
//	}

//	void FixedUpdate () {
//		if (currentTime > totalTime || Mathf.Approximately(currentTime, totalTime)) {
//			currentTime = 0.0f;
//		}
//
//		if (frameCounter >= 5) {
//			// todo: fix cast
//			var frame = timeframes [(int)(currentTime * 10)];
//			for (int i = 0; i < frame.Count; i++) {
//				for (int j = 0; j < frame[i].Count; j++) {
//					if (frame [i] [j] == 'x') {
//						// if water, continue (so we don't explode on water)
////						GameObject obj = ObjectPooler.instance.GetPooledObject();
////						if (obj == null) return;
////						obj.transform.position = new Vector3 (j + 3, i+1, 0.0f);
////						obj.SetActive(true);
////						StartCoroutine(RemoveExplosion(obj));
//						//						Instantiate (wallTiles [0], new Vector3 (j + 3, i+1, 0.0f), Quaternion.identity);
//					}
//				}
//			}
//
//			frameCounter = 0;
//		}
//
////		if (Mathf.Approximately(currentTime,0.0f) || 
////		    Mathf.Approximately(currentTime,0.1f) || 
////		    Mathf.Approximately(currentTime,0.2f) || 
////		    Mathf.Approximately(currentTime,0.3f) || 
////		    Mathf.Approximately(currentTime,0.4f) || 
////		    Mathf.Approximately(currentTime,0.5f) || 
////		    Mathf.Approximately(currentTime,0.6f) || 
////		    Mathf.Approximately(currentTime,0.7f) || 
////		    Mathf.Approximately(currentTime,0.8f) || 
////		    Mathf.Approximately(currentTime,0.9f)) {
////			// todo: fix cast
////			var frame = timeframes [(int)(currentTime * 10)];
////			for (int i = 0; i < frame.Count; i++) {
////				for (int j = 0; j < frame[i].Count; j++) {
////					if (frame [i] [j] == 'x') {
////						GameObject obj = ObjectPooler.instance.GetPooledObject();
////						if (obj == null) return;
////						obj.transform.position = new Vector3 (j + 3, i+1, 0.0f);
////						obj.SetActive(true);
////						StartCoroutine(RemoveExplosion(obj));
//////						Instantiate (wallTiles [0], new Vector3 (j + 3, i+1, 0.0f), Quaternion.identity);
////					}
////				}
////			}
////		}
//
//		currentTime += 0.02f;
//		frameCounter++;
//	}
	
}
