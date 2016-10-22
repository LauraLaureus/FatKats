using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {


	public Image img;
	public float percentaje;
	public float scale;

	void Start () {
		img = this.GetComponent<Image> ();
		percentaje = 1f;
	}

	void LateUpdate(){

		float x = Time.timeSinceLevelLoad/scale; 
		percentaje -= Mathf.Pow (x, 2);

		img.fillAmount = percentaje;
	}

}
