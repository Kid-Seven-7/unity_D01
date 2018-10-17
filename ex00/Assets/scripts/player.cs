using UnityEngine;

public class player : MonoBehaviour{

	public GameObject red, yellow, blue, actPlayer;

	static public Vector3 pos, defaultPos;
	public Vector3 redDefault, yellowDefault, blueDefault, tPos;

	public int active;
	public float time, airTime;
	
	static public bool onGround;

	// Use this for initialization
	void Start (){
		time = airTime = 0;
		onGround = true;
		redDefault = red.transform.position;
		yellowDefault = yellow.transform.position;
		blueDefault = blue.transform.position;
		active = 1;
	}
	
	// Update is called once per frame
	void Update (){
		time += Time.deltaTime;

		if (active == 1){
			actPlayer = red;
			defaultPos = redDefault;
		}else if (active == 2){
			actPlayer = yellow;
			defaultPos = yellowDefault;
		}else if (active == 3){
			actPlayer = blue;
			defaultPos = blueDefault;
		}

		tPos = pos = actPlayer.transform.position;

		if (Input.GetKeyDown("1"))
			active = 1;
		if (Input.GetKeyDown("2"))
			active = 2;
		if (Input.GetKeyDown("3"))
			active = 3;
		if (Input.GetKey("right"))
			actPlayer.transform.Translate(Vector3.right * Time.deltaTime);
		if (Input.GetKey("left"))
			actPlayer.transform.Translate(Vector3.left * Time.deltaTime);
		if (Input.GetKey("r")){
			onGround = true;
			red.transform.position = redDefault;
			yellow.transform.position = yellowDefault;
			blue.transform.position = blueDefault;
		}

		if (onGround){
			if (Input.GetKey("space")){
				airTime = time + 50f;
				actPlayer.transform.Translate((Vector3.up * 25) * Time.deltaTime);
				onGround = false;
			}
		}else{
			if (time < airTime){
				actPlayer.transform.Translate((Vector3.down) * Time.deltaTime);
				if (actPlayer.transform.position.y < defaultPos.y){
					Debug.Log("hello");
					onGround = true; 
					actPlayer.transform.position = new Vector3(pos.x, defaultPos.y, pos.z);
				}
			}
		}
	}
}
