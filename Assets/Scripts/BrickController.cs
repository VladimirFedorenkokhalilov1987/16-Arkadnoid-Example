using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour
{

	public GameObject _brickPart;

	void OnCollisionEnter2D ()
	{
		Instantiate (_brickPart, transform.position, Quaternion.identity);
		GameManeger.instanse.DestroyBrick ();
		GameManeger.instanse.Score();
		Destroy (gameObject, .03f);
		GameManeger.instanse.Setup2 ();
		GameManeger.instanse.Setup1 ();
	}
}
