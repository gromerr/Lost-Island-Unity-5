using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {

	public Slider sliderGeneralAudioVolume;
	public Slider sliderAudioEffectVolume;
	public Slider sliderAudioVoicesVolume;
	public Slider sliderAudioMusicVolume;
	public Slider sliderGeneralAudioMode;
	public Text textGeneralAudioMode;

	private AudioScene audioScene;

	void Awake(){

		audioScene = (AudioScene) FindObjectOfType( typeof(AudioScene));
	}

	void Start(){

		SetSettingsAudioInterfaceAtStart();
	}

	/// <summary>
	/// Sets the settings audio interface at start.
	/// </summary>
	void SetSettingsAudioInterfaceAtStart(){

		sliderGeneralAudioVolume.value = SettingsData.GeneralAudioVolume;
		sliderAudioEffectVolume.value = SettingsData.AudioEffectVolume;
		sliderAudioVoicesVolume.value = SettingsData.AudioVoicesVolume;
		sliderAudioMusicVolume.value = SettingsData.AudioMusicVolume;
		sliderGeneralAudioMode.value = SettingsData.GeneralAudioMode;

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

		//GlobalSettings.SetGeneralAudioMode( (int)sliderGeneralAudioMode.value );
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
	/// Determines whether this instance cancel changed game settings.
	/// </summary>
	public void CancelChangedGameSettings(){

		SetSettingsAudioInterfaceAtStart();
		audioScene.SetAudioVolumeInCurrentScene();
	}

	/// <summary>
	/// Saves the changed game settings.
	/// </summary>
	public void SaveChangedGameSettings(){

		SettingsData.GeneralAudioVolume = sliderGeneralAudioVolume.value;
		SettingsData.AudioEffectVolume = sliderAudioEffectVolume.value;
		SettingsData.AudioMusicVolume = sliderAudioVoicesVolume.value;
		SettingsData.AudioMusicVolume = sliderAudioMusicVolume.value;
		SettingsData.GeneralAudioMode = (int)sliderGeneralAudioMode.value;

		GameController.gameController.SaveSettings();
	}
}
