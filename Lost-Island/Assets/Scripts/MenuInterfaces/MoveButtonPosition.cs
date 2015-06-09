using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MoveButtonPosition : ButtonBehaviour {

	public GameObject buttonTarget;

	private Vector3 normalPosition;
	private Vector3 targetPosition;


	void Awake(){
		normalPosition = GetComponent<RectTransform>().localPosition;
		targetPosition = buttonTarget.GetComponent<RectTransform>().localPosition;
	}
	

	protected override void SetButton(){
		
		if( MenuBehaviour.menuBehaviour.Menu.activeSelf == true ){
			if( Application.loadedLevel == 1 ){
				ShowButton( showInMainMenu );
				GetComponent<RectTransform>().localPosition = normalPosition;
			}else{
				ShowButton( showInGame );
				GetComponent<RectTransform>().localPosition = targetPosition;
			}
		}
	}


	
}
