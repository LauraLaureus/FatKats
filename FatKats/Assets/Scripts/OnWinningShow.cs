using UnityEngine;
using UnityEngine.UI;

public class OnWinningShow : MonoBehaviour {

	public string text;
	public GameObject enemyLifeBar;
	public GameObject winningUI;

	public void Show() {
		winningUI.SetActive(true);
		GameObject winnerText = GameObject.Find ("WinnerText");
		winnerText.GetComponent<Text>().text += text;
		Destroy (enemyLifeBar.GetComponent<OnWinningShow> ());

		if (winnerText.GetComponent <Text> ().text == "Winner Player 2Player 1" ||
		   	winnerText.GetComponent <Text> ().text == "Winner Player 1Player 2") {
			winnerText.GetComponent <Text>().text = "Draw";
		}
	}
}
