using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafingBackground : MonoBehaviour {

	public float speed;

	Rigidbody2D rb;

	void Awake(){
	//	/*rb = */GetComponent<Rigidbody2D> ().velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	//	rb.velocity = speed;
		gameObject.transform.Translate(speed/7, 0, 0);
	}
}
