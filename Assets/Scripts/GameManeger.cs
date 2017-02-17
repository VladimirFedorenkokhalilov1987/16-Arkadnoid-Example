using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour 
{

	public int _lives =1;
	public int _score =0;
	public int _bestScore =0;
	private int _timer =1000;

	public int _bricks = 20;
	public float _resetDelay = 1f;
	public Text _livesText;
	public Text _scoreText;
	public Text _bestScoreText;
	public Text _timerText;

	public GameObject _gameover;
	public GameObject _win;
	public GameObject _bricksPref;
	public GameObject _paddle;
	public GameObject _dethPart;
	public static GameManeger instanse = null;

	private GameObject _clonePaddle;
	private int _destroyedBalls=0;

	void Start () 
	{
		var SoundState = GameObject.Find ("Sound").GetComponent<MainMenuController> ();
		SoundState.SoundOnOf ();

		if (instanse == null)
			instanse = this;
		else if (instanse != this)
			Destroy (gameObject);

		_bestScore = PlayerPrefs.GetInt ("HiScore", 0);
	
		Score ();
		Setup ();

//		if(_timer<=0)
//		Setup2 ();
	}

	public void Setup()
	{
		_clonePaddle = Instantiate (_paddle, new Vector2(0,-5.7f), Quaternion.identity) as GameObject;
		Instantiate (_bricksPref, new Vector2(Random.Range(-10,10),Random.Range(-1,7)), Quaternion.identity);
	}

	public void Setup1()
	{
		Instantiate (_bricksPref, new Vector2(Random.Range(-10,10),Random.Range(-1,7)), Quaternion.identity);
	}

	public void Setup2()
	{
			_timer = 1000;
	}

	void CheckGameOver()
	{
		if (_bricks < 1) {
			_win.SetActive (true);
			Time.timeScale=.25f;
			Invoke ("Reset", _resetDelay);
		}

		if (_lives < 1 ||_timer<=1) 
		{
			_gameover.SetActive (true);
			Time.timeScale=.25f;
			Invoke ("Reset", _resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void LoseLife () 
	{
		_lives--;
		_livesText.text = "Lives: " + _lives;
		Instantiate (_dethPart, _clonePaddle.transform.position, Quaternion.identity);
		Destroy (_clonePaddle);
		Invoke ("SetupPaddle", _resetDelay);
		CheckGameOver ();
	}

	public void Score ()
	{
		_score+=(_destroyedBalls*2)*10;
		_scoreText.text = "Score: " + _score;

		if(_score>_bestScore)
			_bestScore = _score;

		_bestScoreText.text = "Best Score: " +PlayerPrefs.GetInt("HiScore", _bestScore);
	}

	void SetupPaddle()
	{
		_clonePaddle = Instantiate (_paddle, new Vector2(-9,-5.7f), Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		_bricks--;
		_destroyedBalls++;
		CheckGameOver ();
	}

	void Update()
	{
		_timer--;
		_timerText.text = "Time to destroy this moon: " + _timer;	
		PlayerPrefs.SetInt ("HiScore", _bestScore);
		if (_timer <= 1)
		{
			_timer = 1;
			CheckGameOver ();
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}
}
