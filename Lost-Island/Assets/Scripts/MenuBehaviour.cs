using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {

	public Slider sliderGeneralAudioVolume;
	public Slider sliderAudioEffectVolume;
	public Slider sliderAudioVoicesVolume;
	public Slider sliderAudioMusicVolume;
	public AudioScene audioScene;

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

	}

	/// <summary>
	/// Exits from game.
	/// </summary>
	public void ExitFromGame(){
		Application.Quit();
	}

	public void ChangeValueOfSettings( Slider slider ){

		Text text = GetComponent<Text>();
		text.text = slider.value.ToString();
	}

	/// <summary>
	/// Sets the general audio volume on slider change.
	/// </summary>
	public void SetGeneralAudioVolumeOnSliderChange(){
		AudioListener.volume = sliderGeneralAudioVolume.value;
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

		GameController.gameController.SaveSettings();
	}
}
