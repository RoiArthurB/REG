using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	public bool randomFlip = true;

	Vector3 flip;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn (){
		// Random design
		if(randomFlip)
			if (Random.Range (0, 2) == 0)
				flip = new Vector3 (0, 180, 0);
			else
				flip = Vector3.zero;
		
		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.Euler(flip));
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
