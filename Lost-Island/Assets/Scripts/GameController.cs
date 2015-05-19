using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameController;
	private SettingsFileManager settingsManager;

	void Awake(){

		HoldGameControllerInEveryScene();
		settingsManager = new SettingsFileManager();
	}


	/// <summary>
	/// Holds this game controller in every scene.
	/// </summary>
	private void HoldGameControllerInEveryScene(){

		if( gameController == null ){
			DontDestroyOnLoad( gameObject );
			gameController = this;
		}else if( gameController != this){
			Destroy( gameObject );
		}
	}

	/// <summary>
	/// Saves the settings to file.
	/// </summary>
	public void SaveSettings(){

		settingsManager.Save();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
