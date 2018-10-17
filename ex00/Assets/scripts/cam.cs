using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {

	public Vector3 pos;

	// Update is called once per frame
	void Update () {
		pos = player.pos;
		pos.z = -10f;
		pos.y = -0.5f;
		transform.position = pos;
	}
}
