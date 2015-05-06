using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SettingsFileManager {

	private const string fileName = "config.txt";
	private string pathFile;
	private SettingsDataCollection settingsDataCollection;

	public SettingsFileManager(){

		pathFile = Application.dataPath + "/" + fileName;
		settingsDataCollection = new SettingsDataCollection();

		PrepareDataFromFile();
	}

	public SettingsDataCollection Settings{
		get{
			return settingsDataCollection;
		}
	}

	private bool CheckFileExist(){

		return File.Exists( pathFile );
	}

	private void PrepareDataFromFile(){

		if( CheckFileExist() ){
			ReadSettingsFile();
		}else{
			ReadSettingsFromApplication();
			CreateSettingsFile();
		}
	}

	private void ReadSettingsFile(){
		bool transacion = true;
		float parseValue;

		try{

			StreamReader file = new StreamReader( pathFile );

			while( !file.EndOfStream && transacion ){
				string line = file.ReadLine();
				line.Trim();

				string []parameter = line.Split( '=' );

				if( parameter.Length == 2 ){

					switch( parameter[0] ){
					case SettingsDataHelper.GeneralAudioVolume:
						if( transacion = ParseFileDataToFloat( parameter[1], out parseValue ) ){
							settingsDataCollection.GeneralAudioVolume = parseValue;
						}
						break;
					case SettingsDataHelper.GeneralAudioMode:
						transacion = ParseGeneralAudioMode( parameter[1] );
						break;
					case SettingsDataHelper.AudioEffectVolume:
						if( transacion = ParseFileDataToFloat( parameter[1], out parseValue ) ){
							settingsDataCollection.AudioEffectVolume = parseValue;
						}
						break;
					case SettingsDataHelper.AudioVoicesVolume:
						if( transacion = ParseFileDataToFloat( parameter[1], out parseValue ) ){
							settingsDataCollection.AudioVoicesVolume = parseValue;
						}
						break;
					case SettingsDataHelper.AudioMusicVolume:
						if( transacion = ParseFileDataToFloat( parameter[1], out parseValue ) ){
							settingsDataCollection.AudioMusicVolume = parseValue;
						}
						break;
					default:
						transacion = false;
						break;
					}
				}else{
					transacion = false;
				}
			}

			file.Close();

		}catch( Exception ex ){

			Debug.LogException( ex );
		}

		if( !transacion ){
			Debug.Log("Read file return: " + transacion + "\nthe new settings file is create.");
			ReadSettingsFromApplication();
			CreateSettingsFile();
		}

	}

	private bool ParseFileDataToFloat( string value, out float result ){

		if( float.TryParse( value , out result ) ){
			if( result > 1 && result < 0 ){
				return false;
			}else{
				return true;
			}
		}else{
			return false;
		}
	}

	private bool ParseGeneralAudioMode( string value ){

		if( value == AudioSpeakerMode.Stereo.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Stereo;
		}else if( value == AudioSpeakerMode.Mode7point1.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Mode7point1;
		}else if( value == AudioSpeakerMode.Mode5point1.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Mode5point1;
		}else if( value == AudioSpeakerMode.Surround.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Surround;
		}else if( value == AudioSpeakerMode.Mono.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Mono;
		}else if( value == AudioSpeakerMode.Prologic.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Prologic;
		}else if( value == AudioSpeakerMode.Quad.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Quad;
		}else if( value == AudioSpeakerMode.Raw.ToString() ){
			settingsDataCollection.GeneralAudioMode = AudioSpeakerMode.Raw;
		}else{
			return false;
		}

		return true;
	}

	public void CreateSettingsFile(){

		//ReadSettingsFromApplication();

		try{
			StreamWriter file = new StreamWriter( pathFile );

			file.WriteLine( "GeneralAudioVolume=" + settingsDataCollection.GeneralAudioVolume );
			file.WriteLine( "GeneralAudioMode=" + settingsDataCollection.GeneralAudioMode );
			file.WriteLine( "AudioEffectVolume=" + settingsDataCollection.AudioEffectVolume );
			file.WriteLine( "AudioVoicesVolume=" + settingsDataCollection.AudioVoicesVolume );
			file.WriteLine( "AudioMusicVolume=" + settingsDataCollection.AudioMusicVolume );

			file.Close();

		}catch( Exception ex ){

			Debug.LogException( ex );
		}
	}

	public void ReadSettingsFromApplication(){

		settingsDataCollection.GeneralAudioVolume = AudioListener.volume;
		settingsDataCollection.GeneralAudioMode = AudioSettings.GetConfiguration().speakerMode;
		settingsDataCollection.AudioEffectVolume = 1f;
		settingsDataCollection.AudioVoicesVolume = 1f;
		settingsDataCollection.AudioMusicVolume = 1f;
	}

	public void ReadSettingsFromApplication( float audioEffect, float audioVoices, float audioMusic ){
		
		settingsDataCollection.GeneralAudioVolume = AudioListener.volume;
		settingsDataCollection.GeneralAudioMode = AudioSettings.GetConfiguration().speakerMode;
		settingsDataCollection.AudioEffectVolume = audioEffect;
		settingsDataCollection.AudioVoicesVolume = audioVoices;
		settingsDataCollection.AudioMusicVolume = audioMusic;
	}
	
}
