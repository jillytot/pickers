using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {
	
	public static gameMaster inst;
	public float spawnRateController = 1.0f; // How fast does shit spawn?
	public int piScore; // Your total score yo!
	public GameObject[] followerTypes;
	
	//follower types:
	
	
	void Awake() {
		inst = this;	
	}
	
	// Use this for initialization
	void Start () {
	
		//for (int i = 0; < followerNames.Length; i++) {
			
	//	}
		//followerNames = new string [followerTypes];
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	var piCount = boxBehavior.thisBox.thisPiCount;
	piScore = piCount;
	
	}
}
