using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour
{

	public float _destroyTime = 0.5f;

	void Start () 
	{
		Destroy (gameObject, _destroyTime);
	}
}
