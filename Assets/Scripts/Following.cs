using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {
	
	private Vector3 targetPos; //Move me where the cursor is pointing
	public Rigidbody Follower; //Make me touchable
	public bool hasTarget = false; //Am i currently selected to move?
	public float speed = 5.0f; //Speed at which i follow the cursor
	//public static Following inst;
	public AudioClip clickMe;
	
		void Awake() {
		//inst = this;	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1")) {
   
   			RaycastHit hit;
			
			//Suggestion from Johnathan
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//so, ray.origin
			//and you should be able to do ray.origin.x and ray.origin.y
			
			//Use cursor to detect this game object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
   				if(Physics.Raycast(ray, out hit, 1000.0f)) {
     				if(hit.rigidbody == this.rigidbody) {
     					Follower = hit.rigidbody;
    					hasTarget = true;
						audio.PlayOneShot(clickMe);
				}
			}
		}
			else if (Input.GetButtonUp ("Fire1")) {
				hasTarget = false;
		}
			else if (hasTarget) {
				MoveTheObject();

		}
	}

	//Following
	void MoveTheObject () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000.0f)) {
			targetPos = new Vector3 (hit.point.x, hit.point.y, Follower.position.z);
			
			// collect the difference betwen the target and position
			Vector3 diff = targetPos - Follower.transform.position;
			
			//Set the direction of the diff's normalized direction
			Vector3 dir = diff.normalized;
			
			//set the max move amount
			float moveAmount = speed * Time.deltaTime;
			
			//if the max move amount is greater then what we have left,
			//only use what we have left
			if (diff.magnitude < moveAmount)moveAmount = diff.magnitude;
			
			//translate the move amount
			Follower.transform.Translate(dir * moveAmount, Space.World);
		}
	}
}
