using UnityEngine;

public class player : MonoBehaviour{

	public Rigidbody2D red, yellow, blue, activeRB;
	public Collider2D redCol, yellowCol, blueCol;
	public GameObject redGO, yellowGO, blueGO;
	public GameObject redExit, yellowExit, blueExit;
	public bool redOnGround, yellowOnGround, blueOnGround, cleared;

	float upThrust, rlThrust; 

	int active;

	public Vector3 redPos, yellowPos, bluePos;
	public Vector3 redX, yellowX, blueX;
	static public Vector3 activePos;
	Vector3 redDefaultPos, yellowDefaultPos, blueDefaultPos;

	// Use this for initialization
	void Start (){
		active = 1;
		activeRB = red;
		redDefaultPos = red.transform.position;
		yellowDefaultPos = yellow.transform.position;
		blueDefaultPos = blue.transform.position;
		redOnGround = true;
		yellowOnGround = true;
		blueOnGround = true;
		cleared = false;
		redX = redExit.transform.position;
		yellowX = yellowExit.transform.position;
		blueX = blueExit.transform.position;
  }
	
	// Update is called once per frame
	void Update (){
		if (isInRange(redX.x, redGO.transform.position.x) &&
			isInRange(yellowX.x, yellow.transform.position.x) &&
			isInRange(blueX.x, blueGO.transform.position.x) &&
			isInRange(redX.y, redGO.transform.position.y) &&
			isInRange(yellowX.y, yellow.transform.position.y) &&
			isInRange(blueX.y, blueGO.transform.position.y) &&
			!cleared){
				Debug.Log("Level complete");
				cleared = true;
		}

		if (Input.GetKeyDown("1"))
			active = 1;
		if (Input.GetKeyDown("2"))
			active = 2;
		if (Input.GetKeyDown("3"))
			active = 3;

		if (active == 1){
			upThrust = 20000;
			rlThrust = 400;
			activePos = red.transform.position;
			activeRB = red;
		}else if (active == 2){
			upThrust = 22000;
			rlThrust = 900;
			activePos = yellow.transform.position;
			activeRB = yellow;
		}else if (active == 3){
			upThrust = 18000;
			rlThrust = 150;
			activePos = blue.transform.position;
			activeRB = blue;
		}

		if (Input.GetKey("right")){
			activeRB.AddForce(transform.right * rlThrust);
		}
		if (Input.GetKey("left")){
			activeRB.AddForce(transform.right * -rlThrust);
		}
		if (Input.GetKeyDown("space")){
			if (active == 1 && redOnGround){
				red.AddForce(transform.up * upThrust);
				redOnGround = false;
			}else if (active == 2 && yellowOnGround){
				yellow.AddForce(transform.up * upThrust);
				yellowOnGround = false;
			}else if (active == 3 && blueOnGround){
				blue.AddForce(transform.up * upThrust);
				blueOnGround = false;
			}
		}
		if (Input.GetKeyDown("r")){
			red.transform.position = redDefaultPos;
			yellow.transform.position = yellowDefaultPos;
			blue.transform.position = blueDefaultPos;
		}
		redPos = red.transform.position;
		yellowPos = yellow.transform.position;
		bluePos = blue.transform.position;
	}

	bool isInRange(float baseVal, float testVal){
		if ((baseVal > (testVal - 2))  &&  (baseVal < (testVal + 2)))
			return (true);
		return (false);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "player"){
			if (this.gameObject == redGO)
				redOnGround = true;
			if (this.gameObject == yellowGO)
				yellowOnGround = true;
			if (this.gameObject == blueGO)
				blueOnGround = true;
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "player")
		{
			if (this.gameObject == redGO)
				redOnGround = true;
			if (this.gameObject == yellowGO)
				yellowOnGround = true;
			if (this.gameObject == blueGO)
				Debug.Log("blue");
		}
	}
}
