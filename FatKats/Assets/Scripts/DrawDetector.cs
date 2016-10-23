using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawDetector : MonoBehaviour {


	Text currentText;

	// Use this for initialization
	void Start () {
		currentText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentText.text.Contains ("Player 1") && currentText.text.Contains ("Player 2"))
			currentText.text = "DRAW!";
	}
}
