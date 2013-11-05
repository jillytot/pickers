using UnityEngine;
using System.Collections;

public class moverAttributes : MonoBehaviour {
	
	public float moverSpeed = 3.0f; //Speed on which things move on the mover
	public float moverDirection; //Direction which Mover is facing

	// Use this for initialization
	void Start () {
		
		//Creates a Euler Angle based on transform.rotation.z to be converted to a Vector3 by the Follower GameObject.
		moverDirection = gameObject.transform.localEulerAngles.z;
		//Debug.Log (moverDirection);
		//Debug.Log (moverSpeed);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
