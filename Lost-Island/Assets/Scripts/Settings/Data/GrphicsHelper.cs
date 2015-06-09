using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GrphicsHelper : MonoBehaviour {

	[SerializeField]
	private List<GraphicOption> settings;

	public List<GraphicOption> Settings{
		get{
			return settings;
		}
	}

	public float GetValue( int graphicLevel, string optionName ){

		GraphicOption resultSearch = settings.Find ( option => option.name.Contains( optionName ) );
		float value = 0;

		switch( graphicLevel ){
		case 0:
			value = resultSearch.graphicFastest;
			break;
		case 1:
			value = resultSearch.graphicFast;
			break;
		case 2:
			value = resultSearch.graphicSimple;
			break;
		case 3:
			value = resultSearch.graphicGood;
			break;
		case 4:
			value = resultSearch.graphicBeautiful;
			break;
		case 5:
			value = resultSearch.graphicFantastic;
			break;
		case 6:
			value = resultSearch.graphicExtreme;
			break;

		}

		return value;
	}
	
}

[Serializable]
public class GraphicOption{

	public string name;
	public float graphicFastest;
	public float graphicFast;
	public float graphicSimple;
	public float graphicGood;
	public float graphicBeautiful;
	public float graphicFantastic;
	public float graphicExtreme;
}

