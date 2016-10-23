using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float ValorNutritivo = 0.1f;
	void OnTriggerEnter2D (Collider2D col) {
		if(col.tag == "Player") {
			switch(col.name) {
			case "Luffy":
				GameObject.Find ("LifeBar 1").GetComponent<LifeBar> ().percentaje += ValorNutritivo;
				Destroy (this.gameObject);
				break;
			case "Pastelito":
				GameObject.Find ("LifeBar Reverse").GetComponent<LifeBar> ().percentaje += ValorNutritivo;
				Destroy (this.gameObject);
				break;
			}
		}
	}
			
	// Update is called once per frame
	void Update () {
		// Asintótica a 0.8 aprox
		// ValorNutritivo = (1.8f / Mathf.PI) * Mathf.Atan(Time.timeSinceLevelLoad / 50f);

		// Asintótica a 1
		ValorNutritivo = (2f / Mathf.PI) * Mathf.Atan(Time.timeSinceLevelLoad / 25f);
	}
}
