using UnityEngine;
using System.Collections;

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
