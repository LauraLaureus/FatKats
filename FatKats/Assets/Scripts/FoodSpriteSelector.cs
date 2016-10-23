using UnityEngine;
using System.Collections;


public class FoodSpriteSelector : MonoBehaviour {

	public GameObject[] meals;


	public GameObject giveRandomFood(){
		return meals [Random.Range (0, meals.Length)];
	}
}
