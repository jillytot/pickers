using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {
	
	public static gameMaster inst;
	public float spawnRateController = 1.0f; // How fast does shit spawn?
	public float beltSpeedController = 1.0f;
	public int piScore; // Your total score yo!
	public GameObject[] followerTypes;
	public static float entropy = 0; // incremented by follower deaths & time, decremented by shipping followers
	public static float entropyLimit = 100; //total allowable entropy before "game over"
	

	void Awake() {

		// Create an instance of GameMaster
		inst = this;	
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		entropyBehavior ();
		//Get the piCount of each box
		//ToDo - Add up Multiple Boxes to determine Score
		//ToDo - Show count of Pipickers per box
		var piCount = boxBehavior.thisBox.thisPiCount;
		piScore = piCount;

	
	}

	// Handles all GUI stuff
	void OnGUI () { 
		onPlayScene ();
		onPrototypeLevel();
	}

	//Special Behavior for Entropy
	void entropyBehavior () {

		if (entropy > entropyLimit) {
			entropy = entropyLimit;
		}
	
		//Game Over condition
		if (entropy == entropyLimit) {
			Debug.Log("Game Over MAN!!! GAME OVER!!! ");
		}
	}

	//During a normal playscene, show this stuff!
	void onPlayScene () {

		//Displays current count of shipped Followers
		GUI.Box (new Rect (0,0,Screen.width / 4 ,25), "Pipickers Shipped: " + piScore);
		GUI.Box (new Rect (0,25,Screen.width / 4 ,25), "Entropy: " + entropy + "/100");
	}

	//This should only display for the prototype, these attributes will never be shown in the actual game.
	void onPrototypeLevel () {
		GUI.Box (new Rect (Screen.width - Screen.width / 4, 0, Screen.width / 4, 25), "Spawn Rate: " + spawnRateController + " /sec " );
		GUI.Box (new Rect (Screen.width - Screen.width / 4, 25, Screen.width / 4, 25),  "Belt Speed: " + beltSpeedController * 100 + "%");
	}
}
