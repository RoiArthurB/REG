using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkin : MonoBehaviour {

	int skinNumber;

	void Awake(){
		skinNumber = PlayerPrefs.GetInt ("SkinNumber");
		GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("RobotSkin" + skinNumber) as RuntimeAnimatorController;
	}
}
