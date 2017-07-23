using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkinScript : MonoBehaviour {

	public int skinNumber;
	Button[] buttons;

	void Start(){
		GetComponent<Button> ().onClick.AddListener (TaskOnClick);
		buttons = transform.parent.gameObject.GetComponentsInChildren<Button> ();

		if(PlayerPrefs.GetInt("SkinNumber") == skinNumber)
			GetComponent<RectTransform> ().sizeDelta = new Vector2 (75, 75);
	}

	void TaskOnClick(){
		PlayerPrefs.SetInt ("SkinNumber", skinNumber);


		foreach (Button button in buttons) {
			button.GetComponent<RectTransform> ().sizeDelta = new Vector2 (65, 65);
		}
			
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (75, 75);

		Debug.Log ("[Saved] Skin Number : " + skinNumber);
	}

}
