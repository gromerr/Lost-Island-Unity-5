using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {

	public void ExitFromGame(){
		Application.Quit();
	}

	public void ChangeValueOfSettings( Slider slider ){

		Text text = GetComponent<Text>();
		text.text = slider.value.ToString();
	}
}
