using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SmartLocalization;
using System.Linq;
using System.Collections.Generic;

public class LocalizedText : LocalizedObject<Text> {

	// Use this for initialization
	void Start () {

		referenceObject.text = LanguageManager.Instance.GetTextValue( keywordsList.ElementAt(0) );
	}

	protected override void OnChangeLanguage(LanguageManager languageManager){

		referenceObject.text = LanguageManager.Instance.GetTextValue(keywordsList.ElementAt(0));
	}

}
