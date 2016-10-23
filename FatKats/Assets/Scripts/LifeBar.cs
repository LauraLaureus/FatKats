using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

	public Image img;

	public float percentaje;
	public float scale;
	private bool wrote = false;

	void Start () {
		img = this.GetComponent<Image> ();
		percentaje = 1f;
	}

	void LateUpdate() {
		
		if (percentaje <= 0 && !wrote) {
			if (this.GetComponent<OnWinningShow> () != null) {
				this.GetComponent<OnWinningShow> ().Show ();
			}
			Time.timeScale = 0;
			wrote = true;
		}

		float x = Time.timeSinceLevelLoad/scale; 
		percentaje -= Mathf.Pow (x, 2);

		img.fillAmount = percentaje;
	
	}

}
