using UnityEngine;
using System.Collections;

public class FieldCreator : MonoBehaviour 
{

	public GameObject _wall;
	public GameObject _wall2;
	public GameObject _wall3;
	public GameObject _wall4;
	public GameObject _ball;
	private float _moveSpeed = 10;

	void Start ()
	{
		Instantiate (_wall, new Vector2(-4,0), Quaternion.identity);
		Instantiate (_wall2, new Vector2(4,0), Quaternion.identity);
		Instantiate (_wall3, new Vector2(0,-4), Quaternion.identity);
		Instantiate (_wall4, new Vector2(0,4), Quaternion.identity);
		Instantiate (_ball, new Vector2(3,2), Quaternion.identity);
		_wall.transform.localScale = new Vector2 (0.1f,Screen.height);
		_wall2.transform.localScale = new Vector2 (Screen.width,0.1f);
		_wall3.transform.localScale = new Vector2 (Screen.width,Screen.height);
		_wall4.transform.localScale = new Vector2 (Screen.width,0.1f);
	}
	
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			_ball.transform.Translate(new Vector3 (0, 1,0)*_moveSpeed*Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.S))
		{
			_ball.transform.Translate (new Vector3 (0, -1,0)*_moveSpeed*Time.deltaTime);
		}
	}
}
