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
}
