using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {
	
	public static gameMaster inst;
	public float spawnRateController = 1.0f; // How fast does shit spawn?
	public int piScore = 0; // Your total score yo!
	
	void Awake() {
		inst = this;	
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
