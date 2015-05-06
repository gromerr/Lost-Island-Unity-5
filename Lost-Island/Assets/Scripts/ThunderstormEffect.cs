using UnityEngine;
using System.Collections;

[RequireComponent( typeof( AudioSource ) )]
public class ThunderstormEffect : MonoBehaviour {


	public AudioClip thunderstormAudio;
	//public float audioVolume = 1f;
	public float delayTimeAudio = 1f;
	public Color normalSkyColor;
	public Color flashSkyColor;
	public float oneFlashTime = 0.1f;
	public float breakFlashTime = 0.2f;
	
	private Material skyboxMaterial;
	private const string shaderProperty = "_Tint";
	private float time = 0;
	private AudioSource audioOrigin;


	void Awake(){

		audioOrigin = GetComponent<AudioSource>();
		skyboxMaterial = RenderSettings.skybox;
		setSkyboxColor( normalSkyColor );
	}
	
	void Start () {

		StartCoroutine( playDelayThunderstormSound() );
		StartCoroutine( playThunderstormEffect() );
	
	}
	
	void Update () {
		time += Time.deltaTime;

		if( time > thunderstormAudio.length + delayTimeAudio ){
			makeFlashEffect();
			time = 0;
		}
	}

	void setSkyboxColor( Color skyColor ){

		skyboxMaterial.SetColor( shaderProperty, skyColor );
	}

	IEnumerator playDelayThunderstormSound(){

		yield return new WaitForSeconds(delayTimeAudio);
		audioOrigin.PlayOneShot( thunderstormAudio );
	}

	IEnumerator playOneFlashEffect(){

		setSkyboxColor( flashSkyColor );
			
		yield return new WaitForSeconds( oneFlashTime );
			
		setSkyboxColor( normalSkyColor );
	}

	IEnumerator playThunderstormEffect(){

		for( int i = 0; i < 3; i++ ){

			StartCoroutine( playOneFlashEffect() );
			yield return new WaitForSeconds( breakFlashTime );
		}

	}

	void makeFlashEffect(){

		StartCoroutine( playDelayThunderstormSound() );
		StartCoroutine( playThunderstormEffect() );
	}
}
