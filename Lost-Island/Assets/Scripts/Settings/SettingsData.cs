using UnityEngine;
using System.Collections;

/// <summary>
/// Settings data helper.
/// </summary>
public class SettingsData : MonoBehaviour{

	/// <summary>
	/// Gets or sets the general audio volume.
	/// </summary>
	/// <value>The general audio volume.</value>
	public static float GeneralAudioVolume{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the general audio mode.
	/// </summary>
	/// <value>The general audio mode.</value>
	public static AudioSpeakerMode GeneralAudioMode{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the audio effect volume.
	/// </summary>
	/// <value>The audio effect volume.</value>
	public static float AudioEffectVolume{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the audio voices volume.
	/// </summary>
	/// <value>The audio voices volume.</value>
	public static float AudioVoicesVolume{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the audio music volume.
	/// </summary>
	/// <value>The audio music volume.</value>
	public static float AudioMusicVolume{
		get;
		set;
	}

	void Start(){


	}
}
