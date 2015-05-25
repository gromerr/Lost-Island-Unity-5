using UnityEngine;
using System.Collections;
using System.IO;
using System;


public class SettingsFileManager : FileManager {

	private DataContainer dataContainer;

	public SettingsFileManager():base(){

		fileName = "PlayerSettings.dat";
		pathFile += fileName;
		dataContainer = new DataContainer();

		FileInitialization();
	}


	/// <summary>
	/// Reads content from application if it is first time or file don't exist.
	/// </summary>
	protected override void ReadFromApplication(){

		dataContainer.GeneralAudioVolume = SettingsData.GeneralAudioVolume = AudioListener.volume;
		dataContainer.GeneralAudioMode = SettingsData.GeneralAudioMode = GlobalSettings.ConvertAudioSpeakerModeToInt( AudioSettings.GetConfiguration().speakerMode );
		dataContainer.AudioEffectVolume = SettingsData.AudioEffectVolume = 1f;
		dataContainer.AudioVoicesVolume = SettingsData.AudioVoicesVolume = 1f;
		dataContainer.AudioMusicVolume = SettingsData.AudioMusicVolume = 1f;
		dataContainer.ScreenResolution = SettingsData.ScreenResolution = GlobalSettings.CountAvailabeResolutionsIndex();

		dataContainer.FullScreen = SettingsData.FullScreen = GlobalSettings.GetFullscreenMode();
		dataContainer.RefreshRate = SettingsData.RefreshRate = Screen.currentResolution.refreshRate;

		dataContainer.QualityLevel = SettingsData.QualityLevel = GlobalSettings.GetQualityLevel();
		dataContainer.PixelLightCount = SettingsData.PixelLightCount = QualitySettings.pixelLightCount;
		dataContainer.TextureQuality = SettingsData.TextureQuality = QualitySettings.masterTextureLimit;
		dataContainer.AnisotropicTextures = SettingsData.AnisotropicTextures = GlobalSettings.GetAnisotropicFilteringToInt();
		dataContainer.AntiAliasing = SettingsData.AntiAliasing = GlobalSettings.GetAntiAliasingToInt( QualitySettings.antiAliasing );
		dataContainer.RealtimeReflectionProbes = SettingsData.RealtimeReflectionProbes = QualitySettings.realtimeReflectionProbes;
		dataContainer.ShadowDistance = SettingsData.ShadowDistance = QualitySettings.shadowDistance;
		dataContainer.VSyncCount = SettingsData.VSyncCount = QualitySettings.vSyncCount;
		dataContainer.LODBias = SettingsData.LODBias = QualitySettings.lodBias;
		dataContainer.ParticleRaycastBudget = SettingsData.ParticleRaycastBudget = QualitySettings.particleRaycastBudget;
	}

	/// <summary>
	/// Saves the custum component data from application
	/// and serialize.
	/// </summary>
	protected override void SaveCustomData(){
		GetGlobalCustomData();
		biniaryFormatter.Serialize( fileStream, dataContainer );

	}

	/// <summary>
	/// Deserialize and loads the custom component data to application.
	/// </summary>
	protected override void LoadCustomData(){

		dataContainer = (DataContainer) biniaryFormatter.Deserialize( fileStream );
		SetGlobalCustomData();
	}

	/// <summary>
	/// Gets the global custom data.
	/// </summary>
	protected override void GetGlobalCustomData(){
		dataContainer.GeneralAudioVolume = SettingsData.GeneralAudioVolume;
		dataContainer.GeneralAudioMode = SettingsData.GeneralAudioMode;
		dataContainer.AudioEffectVolume = SettingsData.AudioEffectVolume;
		dataContainer.AudioVoicesVolume = SettingsData.AudioVoicesVolume;
		dataContainer.AudioMusicVolume = SettingsData.AudioMusicVolume;
		dataContainer.ScreenResolution = SettingsData.ScreenResolution;

		dataContainer.FullScreen = SettingsData.FullScreen;
		dataContainer.RefreshRate = SettingsData.RefreshRate;

		dataContainer.QualityLevel = SettingsData.QualityLevel;
		dataContainer.PixelLightCount = SettingsData.PixelLightCount;
		dataContainer.TextureQuality = SettingsData.TextureQuality;
		dataContainer.AnisotropicTextures = SettingsData.AnisotropicTextures;
		dataContainer.AntiAliasing = SettingsData.AntiAliasing;
		dataContainer.RealtimeReflectionProbes = SettingsData.RealtimeReflectionProbes;
		dataContainer.ShadowDistance = SettingsData.ShadowDistance;
		dataContainer.VSyncCount = SettingsData.VSyncCount;
		dataContainer.LODBias = SettingsData.LODBias;
		dataContainer.ParticleRaycastBudget = SettingsData.ParticleRaycastBudget;
	}

	/// <summary>
	/// Sets the global custom data.
	/// </summary>
	protected override void SetGlobalCustomData(){
		SettingsData.GeneralAudioVolume = dataContainer.GeneralAudioVolume;
		SettingsData.GeneralAudioMode = dataContainer.GeneralAudioMode;
		SettingsData.AudioEffectVolume = dataContainer.AudioEffectVolume;
		SettingsData.AudioVoicesVolume = dataContainer.AudioVoicesVolume;
		SettingsData.AudioMusicVolume = dataContainer.AudioMusicVolume;
		SettingsData.ScreenResolution = dataContainer.ScreenResolution;

		SettingsData.FullScreen = dataContainer.FullScreen;
		SettingsData.RefreshRate = dataContainer.RefreshRate;

		SettingsData.QualityLevel = dataContainer.QualityLevel;
		SettingsData.PixelLightCount = dataContainer.PixelLightCount;
		SettingsData.TextureQuality = dataContainer.TextureQuality;
		SettingsData.AnisotropicTextures = dataContainer.AnisotropicTextures;
		SettingsData.AntiAliasing = dataContainer.AntiAliasing;
		SettingsData.RealtimeReflectionProbes = dataContainer.RealtimeReflectionProbes;
		SettingsData.ShadowDistance = dataContainer.ShadowDistance;
		SettingsData.VSyncCount = dataContainer.VSyncCount;
		SettingsData.LODBias = dataContainer.LODBias;
		SettingsData.ParticleRaycastBudget = dataContainer.ParticleRaycastBudget;
	}

}

/// <summary>
/// Conteiner data for biniary serialize.
/// </summary>
[Serializable]
class DataContainer{
	public float GeneralAudioVolume;
	public int GeneralAudioMode;
	public float AudioEffectVolume;
	public float AudioVoicesVolume;
	public float AudioMusicVolume;

	public int ScreenResolution;
	public bool FullScreen;
	public int RefreshRate;

	public int QualityLevel;
	public int PixelLightCount;
	public int TextureQuality;
	public int AnisotropicTextures;
	public int AntiAliasing;
	//public bool SoftParticles;
	public bool RealtimeReflectionProbes;
	//public int Shadows;
	//public int ShadowResolution;
	public float ShadowDistance;
	//public int ShadowCascades;
	//public int BlendWeights;
	public int VSyncCount;
	public float LODBias;
	public int ParticleRaycastBudget;

}
