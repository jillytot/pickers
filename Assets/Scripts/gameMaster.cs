using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {
	
	public static gameMaster inst;
	public float spawnRateController = 1.0f; // How fast does shit spawn?
	public int piScore; // Your total score yo!
	public static int followerTypes = 5; // The number of follower types in the game.
	
	void Awake() {
		inst = this;	
	}
	
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	var piCount = boxBehavior.thisBox.thisPiCount;
	piScore = piCount;
	
	}
}
