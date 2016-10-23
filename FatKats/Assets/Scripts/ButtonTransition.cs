using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Text theText;

	public void Start(){
		theText = this.GetComponentInChildren<Text> ();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = Color.red; //Or however you do your color
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = Color.black; //Or however you do your color
	}
}

