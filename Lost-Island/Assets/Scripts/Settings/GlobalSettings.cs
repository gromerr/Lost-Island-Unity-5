using UnityEngine;
using System.Collections;

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
	
}
