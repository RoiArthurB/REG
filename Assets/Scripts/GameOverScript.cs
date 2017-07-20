using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

	int score = 0;
	int bestScore = 0;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		bestScore = PlayerPrefs.GetInt ("BestScore");
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		GUI.Label (new Rect (Screen.width / 2 - 50, 250, 100, 30), "High Score: " + bestScore);
		GUI.Label (new Rect (Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);

		if(GUI.Button(new Rect(Screen.width / 2 - 30, 350, 60, 30), "Retry?"))
			Application.LoadLevel(0);
	}
}
