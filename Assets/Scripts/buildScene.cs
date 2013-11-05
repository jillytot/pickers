using UnityEngine;
using System.Collections;

public class buildScene : MonoBehaviour {
	
	public GameObject piMover; //What to spawn
	public GameObject piFollower;
	public Vector3 spawnSource = new Vector3(0, 0, 0); //Where to spawn it from

	// Use this for initialization
	void Start () {
		GameObject piSpawn = (GameObject)Instantiate(piMover, spawnSource, transform.rotation);
		//GameObject piFollower = (GameObject)Instantiate(piFollower, spawnSource, transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
