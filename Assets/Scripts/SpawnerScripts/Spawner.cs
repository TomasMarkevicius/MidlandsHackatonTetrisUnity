using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] tetrisObjects;

	void Start () {
		SpawnRandom ();
	}

	public void SpawnRandom () {
		int index = Random.Range (0, tetrisObjects.Length);
		Instantiate (tetrisObjects [index], transform.position, Quaternion.identity);

	}
}
