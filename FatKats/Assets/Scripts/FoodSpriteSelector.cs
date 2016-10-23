using UnityEngine;
using System.Collections;


public class FoodSpriteSelector : MonoBehaviour {

	public Sprite food1;
	public Sprite food2;
	public Sprite food3;
	public Sprite food4;
	public Sprite food5;
	public Sprite food6;

	public Sprite giveRandomFood(){
		switch((int)(Random.Range(1,6))){
		case 1: return food1;
			break;
		case 2: return food2;
			break;
		case 3: return food3;
			break;
		case 4: return food4;
			break;
		case 5: return food5;
			break;
		default: return food6;
			break;
		}
	}
}
