using UnityEngine;
using System.Collections;

public class slotBehavior : MonoBehaviour {
	
	//public slotBehavior thisSlot;
	public bool slotActive;
	public bool isFull = false;
	public bool clearSlot;
	
	void Awake () {
		
		//thisSlot = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var clearThisSlot = boxBehavior.thisBox.boxFull;
		clearSlot = false;
		isFull = false; 
		slotActive = false;
		Vector3 goBack = new Vector3(0,0,-1);
		
		//Is there a follower on me?
		RaycastHit hit;
		if (Physics.Raycast(transform.position, goBack, out hit , 1000)) {
			//Debug.Log ("There is someting above me");
			//Debug.DrawRay(transform.position, goBack , Color.blue, 10000);
			slotActive = hit.collider.CompareTag("Touchable");
			if (slotActive) {
				isFull = hit.collider.gameObject.GetComponent<followerAttributes>().inSlot;
			}	
		}	
	if (clearThisSlot) { 
		clearSlot = true;
		}
	}
}