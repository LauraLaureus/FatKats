using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnWinningShow : MonoBehaviour {

	public string text;
	public GameObject enemyLifeBar;
	public GameObject winningUI;

	public void Show(){
		winningUI.SetActive(true);
		GameObject.Find ("WinnerText").GetComponent<Text>().text += text;
		Destroy (enemyLifeBar.GetComponent<OnWinningShow> ());
	}
}
