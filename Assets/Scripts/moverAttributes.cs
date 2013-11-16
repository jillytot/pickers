using UnityEngine;
using System.Collections;

public class moverAttributes : MonoBehaviour {
	
	public float moverSpeed = 3.0f; //Speed on which things move on the mover
	public float moverDirection; //Direction which Mover is facing
	public float updateSpeed; // the actual speed the follower is going.
	float raynge = 1;
	public GameObject wallCollider; // spawns wallCollider around mover if conditions are met
	Vector3 rightSpawnPos;
	Vector3 leftSpawnPos;
	Vector3 upSpawnPos;
	Vector3 downSpawnPos;

	// Use this for initialization
	void Start () {

		//Creates a Euler Angle based on transform.rotation.z to be converted to a Vector3 by the Follower GameObject.
		moverDirection = gameObject.transform.localEulerAngles.z;
		//Debug.Log (moverDirection);
		//Debug.Log (moverSpeed);

		spawnColliders ();

	}
	
	// Update is called once per frame
	void Update () {

		//show raycasts
		//Debug.DrawRay(transform.position, Vector3.right, Color.red, raynge);
		//Debug.DrawRay(transform.position, Vector3.left, Color.blue, raynge);
		//Debug.DrawRay(transform.position, Vector3.up, Color.green, raynge);
		//Debug.DrawRay(transform.position, Vector3.down, Color.yellow, raynge);

		//allows the speed of the followers to change
		updateSpeed = moverSpeed * gameMaster.inst.beltSpeedController;
	
	}

	void spawnColliders () {

		//First we determine the position to spawn each collider
		//spawn collider to my right
		rightSpawnPos = transform.position;
		rightSpawnPos.x += 1;
		rightSpawnPos.z -= 1;

		//spawn to my left
		leftSpawnPos = transform.position;
		leftSpawnPos.x -= 1;
		leftSpawnPos.z -= 1;

		//spawn to my up
		upSpawnPos = transform.position;
		upSpawnPos.y += 1;
		upSpawnPos.z -= 1;

		//spawn to my down
		downSpawnPos = transform.position;
		downSpawnPos.y -= 1;
		downSpawnPos.z -= 1;

		//Next we do our raycast, if nothing is there, let's spawn our collider
		RaycastHit hit; 

		//raycast to the right
		if (Physics.Raycast(transform.position, Vector3.right, out hit , raynge)) {
			Debug.Log("There is something to my right");
		} else {
			Debug.Log("There is nothing to my right");
			GameObject spawnWallRight = (GameObject)Instantiate(wallCollider, rightSpawnPos, transform.rotation);
		}

		//raycast to the left
		if (Physics.Raycast(transform.position, Vector3.left, out hit , raynge)) {
			Debug.Log("There is something to my left");
		} else {
			Debug.Log("There is nothing to my left");
			GameObject spawnWallLeft = (GameObject)Instantiate(wallCollider,leftSpawnPos, transform.rotation);
		}

		//raycast to up
		if (Physics.Raycast(transform.position, Vector3.up, out hit , raynge)) {
			Debug.Log("There is something to my up");
		} else {
			Debug.Log("There is nothing to my up");
			GameObject spawnWallUp = (GameObject)Instantiate(wallCollider,upSpawnPos, transform.rotation);
		}

		//raycast to down
		if (Physics.Raycast(transform.position, Vector3.down, out hit , raynge)) {
			Debug.Log("There is something to my down");
		} else {
			Debug.Log("There is nothing to my down");
			GameObject spawnWallDown = (GameObject)Instantiate(wallCollider,downSpawnPos, transform.rotation);
		}
	}
}
