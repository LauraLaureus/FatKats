using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnWinningShow : MonoBehaviour {

	public string text;
	public GameObject winningUI; 
	public void Show(){
		winningUI.SetActive(true);x
		GameObject.Find ("WinnerText").GetComponent<Text>().text += text;
	}
}
