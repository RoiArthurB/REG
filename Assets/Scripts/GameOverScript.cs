using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	int score = 0;
	int bestScore = 0;

	public Text text;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		bestScore = PlayerPrefs.GetInt ("BestScore");
	}

	void OnGUI(){
		text.text = "High Score: " + bestScore + "\nScore: " + score;

		/*
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");
		GUI.Label (new Rect (Screen.width / 2 - 50, 250, 100, 30), "High Score: " + bestScore);
		GUI.Label (new Rect (Screen.width / 2 - 40, 300, 80, 30), "Score: " + score);
		*/
	}
}
