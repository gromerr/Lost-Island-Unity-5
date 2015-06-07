using UnityEngine;
using System.Collections;

/// <summary>
/// Class save basic AudioSource volume.
/// </summary>
public class AudioSourceOptions : MonoBehaviour {

	private float volume;
	
	void Awake(){
		volume = GetComponent<AudioSource>().volume;
	}
	
	public float VolumeAudio{
		get{
			return volume;
		}
	}
}
