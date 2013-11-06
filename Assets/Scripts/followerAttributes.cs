using UnityEngine;
using System.Collections;

public class followerAttributes : MonoBehaviour {
	
	bool moving = false; //Is this object instance on a Mover?
	bool killMeNow = false; //Destroy this object instance if true
	float moveSpeed; //Speed on Mover, value is pulled from Mover object.
	float castRange = 1000; //Range of RayCast
	float moveDirection; //Angle value pulled from Mover Object
	public bool inSlot = false; //Is this follower in a slot?
	public bool shipped = false; //reports variable back to other objects.
	public string type; //what type of follower am i?

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit; //= new RaycastHit ();
		//Debug.DrawRay(transform.position, Vector3.forward, Color.red, castRange);

		// Let's see if there is something below us.
		if (Physics.Raycast(transform.position, Vector3.forward, out hit , castRange)) {
			//Debug.Log ("I am on something...");
			//Debug.Log (hit.collider.gameObject.tag); // What am i looking at?
			
			//What are all the things i can recognize?
			moving = hit.collider.CompareTag("Mover");
			killMeNow = hit.collider.CompareTag("Killer");
			
			if (hit.collider.CompareTag("Box") && hit.collider.gameObject.GetComponent<slotBehavior>().isFull == false) {
			inSlot = hit.collider.CompareTag ("Box");
			}
				//inSlot = hit.collider.CompareTag("Box");
			
			// If I am on a mover, i want to move the direction and speed values given by that mover
			if (moving) {
				
				//Debug.Log ("Oh, I am on a Mover!");
				
				//Lets get these values from the Mover object via the moverAttributes script
				moveDirection = hit.collider.gameObject.GetComponent<moverAttributes>().moverDirection;
				//Debug.Log ("movement direction is" + moveDirection);
				moveSpeed = hit.collider.gameObject.GetComponent<moverAttributes>().moverSpeed;
				//Debug.Log ("movement speed is" + moveSpeed);
				
				//if there are children to the object, you can use:
				//moveDirection = hit.collider.gameObject.transform.parent.GetComponent<moverAttributes>().moverDirection;

				//Convert moveDirection into a Vector3 (This is not the most ideal way to do this)...
				float angleTest = moveDirection;
				float xMove = Mathf.Sin (Mathf.Deg2Rad * angleTest);
				float yMove = Mathf.Cos (Mathf.Deg2Rad * angleTest);
				
				Vector3 thatWay = new Vector3 (yMove, xMove, 0);
				transform.Translate (thatWay * moveSpeed * Time.deltaTime);
				//print (xMove);
				//print (yMove);
				
				//This is the ideal way to get the vector, but i haven't got it to work yet.
				//float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, 45, oldMoveSpeed * Time.deltaTime);
				//transform.eulerAngles = new Vector3(0, 0, angle);
				
			}
			
			//If I am on a Killer, then i should die!
			if (killMeNow) {
				Debug.Log ("Im gonna die!!!");
				Destroy(this.gameObject);
			}
			
			//If i am in a box, snap me to the nearest open slot
			
			if (hit.collider.CompareTag("Box")) { //&& Input.GetButtonUp ("Fire1")
				//Debug.Log ("I am in a box");
				var snapMeX = hit.collider.gameObject.GetComponent<Transform>().position.x;
				var snapMeY = hit.collider.gameObject.GetComponent<Transform>().position.y;
				//Debug.Log ("Snap me to x: " + snapMeX + " Snap me to y: " + snapMeY);
				transform.position = new Vector3 (snapMeX, snapMeY, transform.position.z);

			}
			// If im in a box that is full, ship me out.
			if (hit.collider.CompareTag("Box") && hit.collider.gameObject.GetComponent<slotBehavior>().clearSlot == true) {
				//Debug.Log ("I'm shipping out yo!");
				shipped = true;
				Destroy(this.gameObject); // This will need to be done after the follower is counted properly
			}
		}
	}
}