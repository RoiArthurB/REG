using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	HUDScript hud;
	public int bonusScore = 10;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript> ();
			hud.IncreaseScore (bonusScore);

			Destroy (this.gameObject);
		}
	}
}
