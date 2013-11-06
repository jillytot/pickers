using UnityEngine;
using System.Collections;

public class slotBehavior : MonoBehaviour {
	
	//public slotBehavior thisSlot;
	public bool slotActive;
	public bool isFull = false;
	public bool clearSlot;
	public string followerType;
	Vector3 goBack = new Vector3(0,0,-1); //detects what's over the slot
	
	// Update is called once per frame
	void Update () {
		var clearThisSlot = boxBehavior.thisBox.boxFull;
		clearSlot = false;
		isFull = false; 
		slotActive = false;
		
		
		//Is there a follower on me?
		RaycastHit hit;
		if (Physics.Raycast(transform.position, goBack, out hit , 1000)) {
			//Debug.Log ("There is someting above me");
			//Debug.DrawRay(transform.position, goBack , Color.blue, 10000);
			slotActive = hit.collider.CompareTag("Touchable");
			if (slotActive) {
				isFull = hit.collider.gameObject.GetComponent<followerAttributes>().inSlot;
				getBirdType ();
				}	
			}
		//if (Input.GetButtonUp("Fire1")) {
			
			//getBirdType ();
		//}
		
		if (clearThisSlot) { 
			
			clearSlot = true;
		
			}
		}
	
	void getBirdType () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, goBack, out hit , 1000)) {
			followerType = hit.collider.gameObject.GetComponent<followerAttributes>().type;
			Debug.Log (followerType);
			
		}
	
	}

}