using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// List of reference to GameObjects with AudioSource.
/// </summary>
public class AudioScene : MonoBehaviour {

	//TODO add static AudioScene variable
	
	public List<GameObject> audioEffect;
	public List<GameObject> audioVoices;
	public List<GameObject> audioMusic;


	void Start(){

		if( MenuBehaviour.menuBehaviour ){
			MenuBehaviour.menuBehaviour.AudioSceneProperty = this;
		}else{
			Debug.Log( "There is no MenuBehaviour in scene" );
		}

		SetAudioVolumeInCurrentScene();
	}
	
	/// <summary>
	/// Sets all additional audio volume in current scene.
	/// </summary>
	public void SetAudioVolumeInCurrentScene(){
		
		foreach( GameObject audio in audioEffect ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, SettingsData.AudioEffectVolume );
		}
		
		foreach( GameObject audio in audioVoices ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, SettingsData.AudioVoicesVolume );
		}
		
		foreach( GameObject audio in audioMusic ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, SettingsData.AudioMusicVolume );
		}
	}

	/// <summary>
	/// Counts the audio volume.
	/// </summary>
	/// <returns>The audio volume.</returns>
	/// <param name="audio">Audio gameObject.</param>
	/// <param name="value">Value.</param>
	private float CountAudioVolume( GameObject audio, float value ){
		
		float baseVolume = audio.GetComponent<AudioSourceOptions>().VolumeAudio;
		
		return ( baseVolume / 100 ) * (value * 100 );
	}

	/// <summary>
	/// Sets the audio effect volume.
	/// </summary>
	/// <param name="sliderValue">Slider value.</param>
	public void SetAudioEffectVolume( float sliderValue ){

		foreach( GameObject audio in audioEffect ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, sliderValue );
		}
	}

	/// <summary>
	/// Sets the audio voices volume.
	/// </summary>
	/// <param name="sliderValue">Slider value.</param>
	public void SetAudioVoicesVolume( float sliderValue ){
		
		foreach( GameObject audio in audioVoices ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, sliderValue );
		}
	}

	/// <summary>
	/// Sets the audio music volume.
	/// </summary>
	/// <param name="sliderValue">Slider value.</param>
	public void SetAudioMusicVolume( float sliderValue ){
		
		foreach( GameObject audio in audioMusic ){
			
			audio.GetComponent<AudioSource>().volume = CountAudioVolume( audio, sliderValue );
		}
	}
	
}
