using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public abstract class LocalizedObject<Type> : MonoBehaviour where Type : class {
	
	public List<string> keywordsList;

	protected Type referenceObject;


	protected void Awake(){

		referenceObject = GetComponent<Type>();

		LanguageManager languageManager = LanguageManager.Instance;
		languageManager.OnChangeLanguage += OnChangeLanguage;
		
		//Run the method one first time
		OnChangeLanguage(languageManager);
	}

	void OnDestroy(){

		if(LanguageManager.HasInstance){
			LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
		}
	}

	protected abstract void OnChangeLanguage(LanguageManager languageManager);

}
