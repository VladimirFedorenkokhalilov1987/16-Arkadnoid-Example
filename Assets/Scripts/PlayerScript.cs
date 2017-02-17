using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{

	[SerializeField, Range (1,20)]
	private float _playerSpeed;
	private Vector2 _playerPos;
	public float _boundary;

	void Start () 
	{
		_playerPos = gameObject.transform.position;
	}
	
	void Update () 
	{
		_playerPos.x += Input.GetAxis ("Horizontal") * _playerSpeed * Time.deltaTime;
		_playerPos = new Vector2 (Mathf.Clamp (_playerPos.x, -9.2f, 9.2f), _playerPos.y);

		if (Input.GetKey (KeyCode.D)) 
		{
			this.transform.RotateAround(_playerPos, new Vector3(0,0,1),1);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			this.transform.RotateAround(_playerPos, new Vector3(0,0,-1),1);
		}

		transform.position = _playerPos;
	}
}
