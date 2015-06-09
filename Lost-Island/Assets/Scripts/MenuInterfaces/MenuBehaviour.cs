using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class MenuBehaviour : MonoBehaviour {

	public static MenuBehaviour menuBehaviour;

	public GrphicsHelper graphicsHelper;
	public GameObject confirmPanel;
	public GameObject videoPanel;
	public Slider sliderLanguage;
	public Text textLanguage;
	public Slider sliderGeneralAudioVolume;
	public Slider sliderAudioEffectVolume;
	public Slider sliderAudioVoicesVolume;
	public Slider sliderAudioMusicVolume;
	public Slider sliderGeneralAudioMode;
	public Text textGeneralAudioMode;
	public Slider sliderScreenResolution;
	public Text textScreenResolution;
	public Toggle toggleFullScreen;
	public Slider sliderQualityLevel;
	public Text textQualityLevel;
	public Slider sliderPixelLightCount;
	public Text textPixelLightCount;
	public Slider sliderTextureQuality;
	public Text textTextureQuality;
	public Slider sliderAnisotropicTextures;
	public Text textAnisotropicTextures;
	public Slider sliderAntiAliasing;
	public Text textAntiAliasing;
	public Toggle toggleRealtimeReflectionProbes;
	public Slider sliderShadowDistance;
	public Text textShadowDistance;
	public Slider sliderVSyncCount;
	public Text textVSyncCount;
	public Slider sliderLODBias;
	public Slider sliderParticleRaycastBudget;
	public Toggle togglePostProcessingDOF;
	public Toggle togglePostProcessingBloom;
	public GameObject menu;

	private AudioScene audioScene;


	public AudioScene AudioSceneProperty{
		set{
			audioScene = value;
		}
	}

	public GameObject Menu{
		get{
			return menu;
		}
	}

	void Awake(){

		HoldInEveryScene();
		sliderScreenResolution.maxValue = GlobalSettings.CountAvailabeResolutionsIndex();
	}

	void Start(){
		SetSettingsInterfaceAtStart();
	}
	

	/// <summary>
	/// Holds the object in every scene.
	/// </summary>
	private void HoldInEveryScene(){

		if( menuBehaviour == null ){
			DontDestroyOnLoad( gameObject );
			menuBehaviour = this;
		}else if( menuBehaviour != this){
			Destroy( gameObject );

		}
	}

	/// <summary>
	/// Sets the settings audio interface at start.
	/// </summary>
	void SetSettingsInterfaceAtStart(){

		sliderGeneralAudioVolume.value = SettingsData.GeneralAudioVolume;
		sliderAudioEffectVolume.value = SettingsData.AudioEffectVolume;
		sliderAudioVoicesVolume.value = SettingsData.AudioVoicesVolume;
		sliderAudioMusicVolume.value = SettingsData.AudioMusicVolume;
		sliderGeneralAudioMode.value = SettingsData.GeneralAudioMode;
		sliderScreenResolution.value = SettingsData.ScreenResolution;
		toggleFullScreen.isOn = SettingsData.FullScreen;
		sliderQualityLevel.value = SettingsData.QualityLevel;
		sliderPixelLightCount.value = SettingsData.PixelLightCount;
		sliderTextureQuality.value = SettingsData.TextureQuality;
		sliderAnisotropicTextures.value = SettingsData.AnisotropicTextures;
		sliderAntiAliasing.value = SettingsData.AntiAliasing;
		toggleRealtimeReflectionProbes.isOn = SettingsData.RealtimeReflectionProbes;
		sliderShadowDistance.value = SettingsData.ShadowDistance;
		sliderVSyncCount.value = SettingsData.VSyncCount;
		sliderLODBias.value = SettingsData.LODBias;
		sliderParticleRaycastBudget.value = SettingsData.ParticleRaycastBudget;
		sliderLanguage.value = GlobalSettings.GetLanguage( SettingsData.Language );
		togglePostProcessingDOF.isOn = SettingsData.PostProcessingDOF;
		togglePostProcessingBloom.isOn = SettingsData.PostProcessingBloom;
	}

	/// <summary>
	/// Exits from game.
	/// </summary>
	public void ExitFromGame(){
		Application.Quit();
	}

	/// <summary>
	/// Sets the general audio volume on slider change.
	/// </summary>
	public void SetGeneralAudioVolumeOnSliderChange(){
		GlobalSettings.SetGeneralAudioVolume( sliderGeneralAudioVolume.value );
	}

	/// <summary>
	/// Sets the general audio mode on slider change.
	/// </summary>
	public void SetGeneralAudioModeOnSliderChange(){

		textGeneralAudioMode.text = ((AudioSpeakerMode)sliderGeneralAudioMode.value).ToString();

		GlobalSettings.SetGeneralAudioMode( (int)sliderGeneralAudioMode.value );

	}

	/// <summary>
	/// Sets the audio effect volume on slider change.
	/// </summary>
	public void SetAudioEffectVolumeOnSliderChange(){
		
		audioScene.SetAudioEffectVolume( sliderAudioEffectVolume.value );
	}

	/// <summary>
	/// Sets the audio voices volume on slider change.
	/// </summary>
	public void SetAudioVoicesVolumeOnSliderChange(){

		audioScene.SetAudioVoicesVolume( sliderAudioVoicesVolume.value );
	}

	/// <summary>
	/// Sets the audio music volume on slider change.
	/// </summary>
	public void SetAudioMusicVolumeOnSliderChange(){

		audioScene.SetAudioMusicVolume( sliderAudioMusicVolume.value );
	}

	/// <summary>
	/// Displaies the language on slider change.
	/// </summary>
	public void DisplayLanguageOnSliderChange(){
	}

	/// <summary>
	/// Displaies the screen resolution on slider change. Slider value is array index.
	/// </summary>
	public void DisplayScreenResolutionOnSliderChange(){

		Resolution res = GlobalSettings.GetResolutionAtIndex( (int) sliderScreenResolution.value );

		textScreenResolution.text = res.width.ToString() + "x" + res.height.ToString();
	}

	/// <summary>
	/// Displaies the quality level on slider change.
	/// </summary>
	public void DisplayQualityLevelOnSliderChange(){

		DisplayPixelLightCountOnSliderChange( false );
		DisplayTextureQualityOnSliderChange( false );
		DisplayAnisotropicTexturesOnSliderChange( false );
		DisplayAntiAliasingOnSliderChange( false );
		ChangeToggleRealtimeReflectionProbes();
		DisplayShadowDistanceOnSliderChange( false );
		DisplayVSyncCountOnSliderChange( false );
		DisplayLODBiasOnSliderChange( false );
		DisplayParticleRaycastBudgetOnSliderChange( false );
	}

	/// <summary>
	/// Displaies the pixel light count on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayPixelLightCountOnSliderChange( bool playerChange ){

		int result;

		if( playerChange ){
			result = (int)sliderPixelLightCount.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "PixelLightCount" );
			sliderPixelLightCount.value = result;
		}
	}

	/// <summary>
	/// Displaies the texture quality on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayTextureQualityOnSliderChange( bool playerChange ){

		int result;
		
		if( playerChange ){
			result = (int)sliderTextureQuality.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "TextureQuality" );
			sliderTextureQuality.value = result;
		}
	}

	/// <summary>
	/// Displaies the anisotropic textures on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayAnisotropicTexturesOnSliderChange( bool playerChange ){

		int result;
		
		if( playerChange ){
			result = (int)sliderAnisotropicTextures.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "AnisotropicTextures" );
			sliderAnisotropicTextures.value = result;
		}
	}

	/// <summary>
	/// Displaies the anti aliasing on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayAntiAliasingOnSliderChange( bool playerChange ){
		
		int result;
		
		if( playerChange ){
			result = (int)sliderAntiAliasing.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "AntiAliasing" );
			sliderAntiAliasing.value = result;
		}
	}

	/// <summary>
	/// Changes the toggle realtime reflection probes.
	/// </summary>
	public void ChangeToggleRealtimeReflectionProbes(){

		int result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "RealtimeReflectionProbes" );

		if( result == 1 ){
			toggleRealtimeReflectionProbes.isOn = true;
		}else{
			toggleRealtimeReflectionProbes.isOn = false;
		}
	}

	/// <summary>
	/// Displaies the shadow distance on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayShadowDistanceOnSliderChange( bool playerChange ){

		int result;
		
		if( playerChange ){
			result = (int)sliderShadowDistance.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "ShadowDistance" );
			sliderShadowDistance.value = result;
		}

		textShadowDistance.text = result.ToString();
	}

	/// <summary>
	/// Displaies the V sync count on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayVSyncCountOnSliderChange( bool playerChange ){

		int result;
		
		if( playerChange ){
			result = (int)sliderVSyncCount.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "VSyncCount" );
			sliderVSyncCount.value = result;
		}
	}

	/// <summary>
	/// Displaies the LOD bias on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayLODBiasOnSliderChange( bool playerChange ){

		float result;
		
		if( playerChange ){
			result = sliderLODBias.value;
		}else{
			result = graphicsHelper.GetValue( (int)sliderQualityLevel.value, "LODBias" );
			sliderLODBias.value = result;
		}

	}

	/// <summary>
	/// Displaies the particle raycast budget on slider change.
	/// </summary>
	/// <param name="playerChange">If set to <c>true</c> player change.</param>
	public void DisplayParticleRaycastBudgetOnSliderChange( bool playerChange ){

		int result;
		
		if( playerChange ){
			result = (int)sliderParticleRaycastBudget.value;
		}else{
			result = (int)graphicsHelper.GetValue( (int)sliderQualityLevel.value, "ParticleRaycastBudget" );
			sliderParticleRaycastBudget.value = result;
		}
	}

	/// <summary>
	/// Cheacks the changed settings in video options on back button.
	/// </summary>
	/// <param name="name">Name of GameObject to set off active.</param>
	public void CheckChangedSettingsOnBackButton( string name ){

		if( CheckSettings() ){
			GameObject.Find( name ).SetActive( false );
			videoPanel.SetActive( true );
		}else{
			confirmPanel.SetActive( true );
		}
	}

	/// <summary>
	/// Cheacks the settings is the same.
	/// </summary>
	/// <returns><c>true</c>, if settings was the same, <c>false</c> otherwise.</returns>
	private bool CheckSettings(){
		if( SettingsData.GeneralAudioVolume == sliderGeneralAudioVolume.value && 
		   	SettingsData.AudioEffectVolume == sliderAudioEffectVolume.value &&
		   	SettingsData.AudioMusicVolume == sliderAudioVoicesVolume.value &&
		   	SettingsData.AudioMusicVolume == sliderAudioMusicVolume.value &&
		   	SettingsData.GeneralAudioMode == (int)sliderGeneralAudioMode.value &&
		   	SettingsData.ScreenResolution == (int)sliderScreenResolution.value &&
		   	SettingsData.FullScreen == toggleFullScreen.isOn &&
		   	SettingsData.QualityLevel == (int)sliderQualityLevel.value &&
		   	(int)sliderPixelLightCount.value == SettingsData.PixelLightCount &&
		   	(int)sliderTextureQuality.value == SettingsData.TextureQuality &&
		   	(int)sliderAnisotropicTextures.value == SettingsData.AnisotropicTextures &&
		   	toggleRealtimeReflectionProbes.isOn == SettingsData.RealtimeReflectionProbes &&
		   	sliderShadowDistance.value == SettingsData.ShadowDistance &&
		   	(int)sliderVSyncCount.value == SettingsData.VSyncCount &&
		   	sliderLODBias.value == SettingsData.LODBias &&
		   	(int)sliderParticleRaycastBudget.value == SettingsData.ParticleRaycastBudget &&
		   	(int)sliderLanguage.value == GlobalSettings.GetLanguage( SettingsData.Language ) &&
		   	togglePostProcessingDOF.isOn == SettingsData.PostProcessingDOF &&
		   	togglePostProcessingBloom.isOn == SettingsData.PostProcessingBloom
		   ){

			return true;
		}

		return false;
	}

	/// <summary>
	/// Determines whether this instance cancel changed game settings.
	/// </summary>
	public void CancelChangedGameSettings(){

		SetSettingsInterfaceAtStart();
		audioScene.SetAudioVolumeInCurrentScene();
	}

	/// <summary>
	/// Saves the changed game settings.
	/// </summary>
	public void SaveChangedGameSettings(){

		SettingsData.Language = GlobalSettings.GetLanguage( (int)sliderLanguage.value );

		SettingsData.GeneralAudioVolume = sliderGeneralAudioVolume.value;
		SettingsData.AudioEffectVolume = sliderAudioEffectVolume.value;
		SettingsData.AudioMusicVolume = sliderAudioVoicesVolume.value;
		SettingsData.AudioMusicVolume = sliderAudioMusicVolume.value;
		SettingsData.GeneralAudioMode = (int)sliderGeneralAudioMode.value;
		SettingsData.ScreenResolution = (int)sliderScreenResolution.value;
		SettingsData.FullScreen = toggleFullScreen.isOn;

		SettingsData.QualityLevel = (int)sliderQualityLevel.value;
		SettingsData.PixelLightCount = (int)sliderPixelLightCount.value;
		SettingsData.TextureQuality = (int)sliderTextureQuality.value;
		SettingsData.AnisotropicTextures = (int)sliderAnisotropicTextures.value;
		SettingsData.AntiAliasing = (int)sliderAntiAliasing.value;
		SettingsData.RealtimeReflectionProbes = toggleRealtimeReflectionProbes.isOn;
		SettingsData.ShadowDistance = sliderShadowDistance.value;
		SettingsData.VSyncCount = (int)sliderVSyncCount.value;
		SettingsData.LODBias = sliderLODBias.value;
		SettingsData.ParticleRaycastBudget = (int)sliderParticleRaycastBudget.value;

		SettingsData.PostProcessingDOF = togglePostProcessingDOF.isOn;
		SettingsData.PostProcessingBloom = togglePostProcessingBloom.isOn;
		
		GameController.gameController.SaveSettings();
	}
	
}
