using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{

	private bool _soundState;

	[SerializeField]
	private GameObject _sound;

	[SerializeField]
	private Toggle _soundTogle;

	public int _playerPrefsSound=1;

	public void Load ()
	{
		SceneManager.LoadScene (1);
	}
	
	public void Exit () 
	{
		Application.Quit ();
	}

	void Sound(bool _state)
	{
		_sound.SetActive (_state);
	}

	public void SoundOnOf()
	{
		if (_soundTogle.isOn && _playerPrefsSound==0) 
		{
			_soundState = true;
			_playerPrefsSound = 1;
			PlayerPrefs.SetInt ("SoundState", _playerPrefsSound);
			PlayerPrefs.Save ();
		} 
		else if(!_soundTogle.isOn && _playerPrefsSound==1)
		{
			_soundState = false;
			_playerPrefsSound = 0;
			PlayerPrefs.SetInt ("SoundState", _playerPrefsSound);
			PlayerPrefs.Save ();
		}
		_soundTogle.isOn = _soundState;
		Sound (_soundState);
	}
}
