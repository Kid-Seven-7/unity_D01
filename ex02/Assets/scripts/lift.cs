using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{

	public Rigidbody2D platform;

	public int num;
	public bool up;
	// Use this for initialization
	void Start()
	{
		num = 0;
		up = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (num % 100 == 0)
		{
			up = !up;
		}
		if (up)
			platform.AddForce(Vector3.up * 100);
		else
			platform.AddForce(Vector3.up * -100);
		num++;
	}
}