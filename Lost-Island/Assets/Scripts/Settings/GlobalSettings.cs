using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;
using UnityStandardAssets.ImageEffects;


public static class GlobalSettings {


	/// <summary>
	/// Sets the general audio volume.
	/// </summary>
	/// <param name="value">Volume of general audio in game.</param>
	public static void SetGeneralAudioVolume( float value ){

		AudioListener.volume = value;
	}

	/// <summary>
	/// Sets the general audio mode.
	/// </summary>
	/// <param name="value">Value of audio speaker mode.</param>
	public static void SetGeneralAudioMode( int value ){

		AudioConfiguration config = AudioSettings.GetConfiguration ();

		switch( value ){
		case 1:
			config.speakerMode = AudioSpeakerMode.Mono;
			break;
		case 2:
			config.speakerMode = AudioSpeakerMode.Stereo;
			break;
		case 3:
			config.speakerMode = AudioSpeakerMode.Quad;
			break;
		case 4:
			config.speakerMode = AudioSpeakerMode.Surround;
			break;
		case 5:
			config.speakerMode = AudioSpeakerMode.Mode5point1;
			break;
		case 6:
			config.speakerMode = AudioSpeakerMode.Mode7point1;
			break;
		}

		AudioSettings.Reset (config);
	}

	/// <summary>
	/// Converts the audio speaker mode to int.
	/// </summary>
	/// <returns>The audio speaker mode to int.</returns>
	/// <param name="mode">AudioSpeakerMode.</param>
	public static int ConvertAudioSpeakerModeToInt( AudioSpeakerMode mode ){

		return (int) mode;
	}

	/// <summary>
	/// Gets the availabe resolutions.
	/// </summary>
	/// <returns>The availabe resolutions.</returns>
	public static Resolution[] GetAvailabeResolutions(){

		return Screen.resolutions;
	}

	/// <summary>
	/// Counts the index of the availabe resolutions.
	/// </summary>
	/// <returns>The availabe resolutions index.</returns>
	public static int CountAvailabeResolutionsIndex(){

		return GetAvailabeResolutions().Length - 1;
	}

	/// <summary>
	/// Gets the index of the resolution at.
	/// </summary>
	/// <returns>The resolution at index.</returns>
	/// <param name="index">Index.</param>
	public static Resolution GetResolutionAtIndex( int index ){

		return Screen.resolutions[ index ];
	}

	/// <summary>
	/// Sets the changed graphics settings.
	/// </summary>
	public static void SetGraphicsSettings(){

		Resolution res = GetResolutionAtIndex( SettingsData.ScreenResolution );

		Screen.SetResolution( res.width, res.height, SettingsData.FullScreen );

		QualitySettings.SetQualityLevel( SettingsData.QualityLevel, true );
		QualitySettings.pixelLightCount = SettingsData.PixelLightCount;
		QualitySettings.masterTextureLimit = SettingsData.TextureQuality;
		QualitySettings.anisotropicFiltering = GetIntTOAnisotropicFiltering( SettingsData.AnisotropicTextures );
		QualitySettings.antiAliasing = GetIntToAntiAliasing( SettingsData.AntiAliasing );
		QualitySettings.realtimeReflectionProbes = SettingsData.RealtimeReflectionProbes;
		QualitySettings.shadowDistance = SettingsData.ShadowDistance;
		QualitySettings.vSyncCount = SettingsData.VSyncCount;
		QualitySettings.lodBias = SettingsData.LODBias;
		QualitySettings.particleRaycastBudget = SettingsData.ParticleRaycastBudget;

	}

	/// <summary>
	/// Gets the fullscreen mode.
	/// </summary>
	/// <returns><c>true</c>, if fullscreen mode was gotten, <c>false</c> otherwise.</returns>
	public static bool GetFullscreenMode(){

		return Screen.fullScreen;
	}

	/// <summary>
	/// Gets the quality level application.
	/// </summary>
	/// <returns>The quality level application.</returns>
	public static int GetQualityLevel(){

		return QualitySettings.GetQualityLevel();
	}

	/// <summary>
	/// Gets the anisotropic filtering from application to int.
	/// </summary>
	/// <returns>The anisotropic filtering from application to int.</returns>
	public static int GetAnisotropicFilteringToInt(){

		AnisotropicFiltering aniso = QualitySettings.anisotropicFiltering;
		int result = 0;

		switch( aniso ){
		case AnisotropicFiltering.Disable:
			result = 0;
			break;
		case AnisotropicFiltering.Enable:
			result = 1;
			break;
		case AnisotropicFiltering.ForceEnable:
			result = 2;
			break;
		}

		return result;
	}

	/// <summary>
	/// Gets the int TO anisotropic filtering.
	/// </summary>
	/// <returns>The int TO anisotropic filtering.</returns>
	/// <param name="value">Value.</param>
	public static AnisotropicFiltering GetIntTOAnisotropicFiltering( int value ){

		AnisotropicFiltering aniso = AnisotropicFiltering.Disable;

		switch( value ){
		case 0:
			aniso = AnisotropicFiltering.Disable;
			break;
		case 1:
			aniso = AnisotropicFiltering.Enable;
			break;
		case 2:
			aniso = AnisotropicFiltering.ForceEnable;
			break;
		}

		return aniso;
	}

	/// <summary>
	/// Gets the int to anti aliasing.
	/// </summary>
	/// <returns>The int to anti aliasing.</returns>
	/// <param name="value">Value.</param>
	public static int GetIntToAntiAliasing( int value ){

		int result = 0;

		switch( value ){
		case 0:
			result = 0;
			break;
		case 1:
			result = 2;
			break;
		case 2:
			result = 4;
			break;
		case 3:
			result = 8;
			break;
		}

		return result;
	}

	/// <summary>
	/// Gets the anti aliasing to int.
	/// </summary>
	/// <returns>The anti aliasing to int.</returns>
	/// <param name="value">Value.</param>
	public static int GetAntiAliasingToInt( int value ){

		int result = 0;
		
		switch( value ){
		case 0:
			result = 0;
			break;
		case 2:
			result = 1;
			break;
		case 4:
			result = 2;
			break;
		case 8:
			result = 3;
			break;
		}

		return result;
	}

	/// <summary>
	/// Sets the language.
	/// </summary>
	public static void SetLanguage(){

		LanguageManager.Instance.ChangeLanguage( SettingsData.Language );
	}

	/// <summary>
	/// Holds the language manager in every scene.
	/// </summary>
	public static void HoldLanguageManager(){
		LanguageManager.SetDontDestroyOnLoad();
	}

	/// <summary>
	/// Gets the language from string to number.
	/// </summary>
	/// <returns>The language.</returns>
	/// <param name="name">Name.</param>
	public static int GetLanguage( string name ){

		switch( name ){

		case "pl":
			return 0;
		case "en":
			return 1;
		default:
			return 0;
		}
	}

	/// <summary>
	/// Gets the language from number to string.
	/// </summary>
	/// <returns>The language.</returns>
	/// <param name="value">Value.</param>
	public static string GetLanguage( int value ){

		switch( value ){
			
		case 0:
			return "pl";
		case 1:
			return "en";
		default:
			return "pl";
		}
	}

	/// <summary>
	/// Sets the post processing effect to Main Camera.
	/// </summary>
	public static void SetPostProcessingEffect(){

		GameObject camera = Camera.main.gameObject;

		Bloom bloom = camera.GetComponent<Bloom>();
		DepthOfField dof = camera.GetComponent<DepthOfField>();

		if( bloom != null ){
			bloom.enabled = SettingsData.PostProcessingBloom;
		}

		if( dof != null ){
			dof.enabled = SettingsData.PostProcessingDOF;
		}
	}
}
