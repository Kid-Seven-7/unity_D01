using UnityEngine;

public class cam : MonoBehaviour {

	Vector3 camPos;

	// Update is called once per frame
	void Update () {
		camPos = player.activePos;
		camPos.z = -5;
		transform.position = camPos;
	}
}
