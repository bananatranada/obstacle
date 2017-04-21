using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler instance;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;

	public List<GameObject> pooledObjects;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = Instantiate(pooledObject) as GameObject;
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	// Use this for initialization
	void Start () {
//		pooledObjects = new List<GameObject> ();
//		for (int i = 0; i < pooledAmount; i++) {
//			GameObject obj = Instantiate(pooledObject) as GameObject;
//			obj.SetActive(false);
//			pooledObjects.Add(obj);
//		}
	}

	public GameObject GetPooledObject () {
		for (int i = 0; i < pooledObjects.Count; i++) {
//			if (pooledObjects[i] == null) {
//				GameObject obj = Instantiate(pooledObject) as GameObject;
//				obj.SetActive(false);
//				pooledObjects[i] = obj;
//				return pooledObjects[i];
//			}

			if (!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}

		if (willGrow) {
			GameObject obj = Instantiate(pooledObject) as GameObject;
			pooledObjects.Add(obj);
			return obj;
		}

		return null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
