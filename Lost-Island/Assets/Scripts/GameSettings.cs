using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {

	public Slider sliderGeneralAudioVolume;
	public Slider sliderAudioEffectVolume;
	public Slider sliderAudioVoicesVolume;
	public Slider sliderAudioMusicVolume;
	
	private SettingsFileManager settingsData;


	void Awake(){

		settingsData = new SettingsFileManager();
		SetSettingsToInterface();
		SetInitializationSettingsToGame();
	}

	private void SetSettingsToInterface(){

		sliderGeneralAudioVolume.value = settingsData.Settings.GeneralAudioVolume;
		sliderAudioEffectVolume.value = settingsData.Settings.AudioEffectVolume;
		sliderAudioVoicesVolume.value = settingsData.Settings.AudioVoicesVolume;
		sliderAudioMusicVolume.value = settingsData.Settings.AudioMusicVolume;

	}

	private void SetInitializationSettingsToGame(){

		AudioListener.volume = settingsData.Settings.GeneralAudioVolume;

		AudioConfiguration config = AudioSettings.GetConfiguration();
		config.speakerMode = settingsData.Settings.GeneralAudioMode;
		AudioSettings.Reset( config );

		GameObject [] audioEffect = GameObject.FindGameObjectsWithTag( "AudioEffect" );

		foreach( GameObject audio in audioEffect ){

			float result = CountAudioVolume( audio, settingsData.Settings.AudioEffectVolume );
			audio.GetComponent<AudioSource>().volume = result;
		}

		GameObject [] audioVoice = GameObject.FindGameObjectsWithTag( "AudioVoice" );
		
		foreach( GameObject audio in audioVoice ){

			float result = CountAudioVolume( audio, settingsData.Settings.AudioVoicesVolume );
			audio.GetComponent<AudioSource>().volume = result;
		}

		GameObject [] audioMusic = GameObject.FindGameObjectsWithTag( "AudioMusic" );
		
		foreach( GameObject audio in audioMusic ){

			float result = CountAudioVolume( audio, settingsData.Settings.AudioMusicVolume );
			audio.GetComponent<AudioSource>().volume = result;
		}
	}

	private float CountAudioVolume( GameObject audioObject, float value ){

		float baseVolume = audioObject.GetComponent<AudioSourceOptions>().VolumeAudio;

		return ( baseVolume / 100 ) * (value * 100 );
	}

	public void SetGeneralAudioVolumeOnSliderChange(){
		AudioListener.volume = sliderGeneralAudioVolume.value;
	}

	public void SetAudioEffectVolumeOnSliderChange(){

		GameObject [] audioEffect = GameObject.FindGameObjectsWithTag( "AudioEffect" );
		
		foreach( GameObject audio in audioEffect ){

			float result = CountAudioVolume( audio, sliderAudioEffectVolume.value );
			audio.GetComponent<AudioSource>().volume = result;
		}
	}

	public void SetAudioVoicesVolumeOnSliderChange(){

		GameObject [] audioVoice = GameObject.FindGameObjectsWithTag( "AudioVoice" );
		
		foreach( GameObject audio in audioVoice ){
			
			float result = CountAudioVolume( audio, sliderAudioVoicesVolume.value );
			audio.GetComponent<AudioSource>().volume = result;
		}
	}

	public void SetAudioMusicVolumeOnSliderChange(){
		
		GameObject [] audioMusic = GameObject.FindGameObjectsWithTag( "AudioMusic" );
		
		foreach( GameObject audio in audioMusic ){
			
			float result = CountAudioVolume( audio, sliderAudioMusicVolume.value );
			audio.GetComponent<AudioSource>().volume = result;
		}
	}

	public void SaveGameSettings(){

		float effect = sliderAudioEffectVolume.value;
		float voices = sliderAudioVoicesVolume.value;
		float music = sliderAudioMusicVolume.value;

		settingsData.ReadSettingsFromApplication( effect, voices, music );
		settingsData.CreateSettingsFile();
	}

	public void CancelGameSettings(){
		SetSettingsToInterface();
		SetInitializationSettingsToGame();
	}
}
