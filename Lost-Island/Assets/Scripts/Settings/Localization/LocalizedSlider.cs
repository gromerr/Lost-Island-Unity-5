using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using SmartLocalization;


public class LocalizedSlider : LocalizedObject<Slider> {

	public Text textField;

	void Start(){

		OnSliderChange();
	}

	public void OnSliderChange(){

		string key = GetKeyLanguage();
		SetTextField( key );
	}

	private string GetKeyLanguage(){

		if( referenceObject == null ){
			referenceObject = GetComponent<Slider>();
		}

		return keywordsList.ElementAt( (int)referenceObject.value );
	}

	private void SetTextField( string key ){
		textField.text  = LanguageManager.Instance.GetTextValue( key );
	}

	protected override void OnChangeLanguage(LanguageManager languageManager){

		string key = GetKeyLanguage();
		SetTextField( key );
	}
}
