using UnityEngine;
using System.Collections;

/// <summary>
/// Settings data helper.
/// </summary>
public class SettingsData : MonoBehaviour{

	/// <summary>
	/// Gets or sets the language in game.
	/// </summary>
	/// <value>The language.</value>
	public static string Language{
		get;
		set;
	}

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
	public static int GeneralAudioMode{
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

	/// <summary>
	/// Gets or sets the screen resolution. Int value shows number of index Screen.resolutions
	/// </summary>
	/// <value>The screen resolution.</value>
	public static int ScreenResolution{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets a value of Fullscreen mode.
	/// </summary>
	/// <value><c>true</c> if full screen; otherwise, <c>false</c>.</value>
	public static bool FullScreen{
		get;
		set;
	}

	/// <summary>
	/// Gets or sets the refresh rate in Hz.
	/// </summary>
	/// <value>The refresh rate.</value>
	public static int RefreshRate{
		get;
		set;
	}
	
	public static int QualityLevel{
		get;
		set;
	}

	public static int PixelLightCount{
		get;
		set;
	}

	public static int TextureQuality{
		get;
		set;
	}

	public static int AnisotropicTextures{
		get;
		set;
	}

	public static int AntiAliasing{
		get;
		set;
	}

	//TODO Current not passible to change at runtime, check in future.
//	public static bool SoftParticles{
//		get;
//		set;
//	}

	public static bool RealtimeReflectionProbes{
		get;
		set;
	}

	//TODO Current not passible to change at runtime, check in future.
//	public static int Shadows{
//		get;
//		set;
//	}

	//TODO Current not passible to change at runtime, check in future.
//	public static int ShadowResolution{
//		get;
//		set;
//	}
	
	public static float ShadowDistance{
		get;
		set;
	}

	//TODO Check in future. Current It is not necessary to change by player.
//	public static int ShadowCascades{
//		get;
//		set;
//	}

	//TODO Check in future. Current It is not necessary to change by player.
//	public static int BlendWeights{
//		get;
//		set;
//	}

	public static int VSyncCount{
		get;
		set;
	}

	public static float LODBias{
		get;
		set;
	}

	public static int ParticleRaycastBudget{
		get;
		set;
	}

	public static bool PostProcessingDOF{
		get;
		set;
	}

	public static bool PostProcessingBloom{
		get;
		set;
	}

	void Start(){


	}
}
