using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LoadingManager : MonoBehaviour {

	public Slider progressBar;

	private AsyncOperation asynchronic;


	void Awake(){

		if( ! GameController.gameController ){
			StartCoroutine( LoadLevelAsynchronic( 1 ) );
		}
	}
	
	void Start () {
	
		StartLoadingLevel();
	}

	/// <summary>
	/// Starts the loading level from gamecontroller.
	/// </summary>
	private void StartLoadingLevel(){

		try{
			GlobalSettings.SetLanguage();
			StartCoroutine( LoadLevelAsynchronic( GameController.gameController.LevelToLoad ) );

		}catch( Exception ex ){

			Debug.LogException( ex );

			StartCoroutine( LoadLevelAsynchronic( 1 ) );
		}
	}

	/// <summary>
	/// Loads the level asynchronic.
	/// </summary>
	/// <returns>The level asynchronic.</returns>
	/// <param name="id">Identifier of level.</param>
	private IEnumerator LoadLevelAsynchronic( int id ){
		
		asynchronic = Application.LoadLevelAsync( id );
		
		while( !asynchronic.isDone ){
			
			progressBar.value = asynchronic.progress;
			yield return null;
		}
	}

}
