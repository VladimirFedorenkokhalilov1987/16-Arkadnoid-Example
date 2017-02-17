using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour 
{
	
	private bool _ballIsActive;

	private Vector2 _ballPos;
	private Vector3 _ballStartForce;
	public static BallScript instanse = null;

	void Start () 
	{
		_ballStartForce = new Vector2 (20f, 20f);
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _ballIsActive==false) 
		{
			transform.parent=null;
			_ballIsActive = true;
			gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D>().AddForce (_ballStartForce*Time.deltaTime);
		}

		if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
}

	
		
