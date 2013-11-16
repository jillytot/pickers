using UnityEngine;
using System.Collections;

public class boxBehavior : MonoBehaviour {
	
	int boxCount; // Number of things in the box
	int boxSize; // The size of the box
	public bool boxFull; // Is the box full?
	slotBehavior[] boxSlots; //array of slotBehavior instances
	bool[] slotIndex; // containter for boxSlots array
	public static boxBehavior thisBox;
	public int thisPiCount;
	public string[] boxContents;
	int[] colorCount; // = new int[gameMaster.followerTypes];
	public GameObject boxTop;
	//Vector3 boxSpawnVector = new Vector3(0, 0, 0);
	
	void Awake() {
		
		thisBox = this;	
	}
 
	void Start () {
 		
    	boxSize = transform.childCount;
    	Debug.Log ("Children = " + boxSize);
		colorCount = new int[gameMaster.inst.followerTypes.Length];
 
	}
 
	void FixedUpdate () {
 
		boxFull = false;
    	if(Input.GetButtonUp("Fire1")) {
			boxCount = 0;     //Reset everything after counting the slots
       		boxFull = false;
       		boxSlots = GetComponentsInChildren<slotBehavior>();     //Return an array of slotBehaviors to store
       		slotIndex = new bool[boxSize]; 
       		
			for(int i = 0;i < boxSize;i++) {
				//Iterate through slotIndex and store whether the corresponding slot is full or not
         		slotIndex[i] = boxSlots[i].isFull; 
				//If the current slot is full, increase boxCount by one
         		if(boxSlots[i].isFull) 
					boxCount++;     
       	}
		collectTypes ();
		
 
       	if(boxCount == boxSize) {
				
			//collectFollowerTypes ();
         	boxFull = true;
			thisPiCount = boxCount + thisPiCount;
			countColors ();
			spawnBoxTop ();
			gameMaster.entropy = gameMaster.entropy - boxSize;
			Debug.Log ("Box is full");
       	}
 
      	Debug.Log ("Followers in Box: " + boxCount);
    	}
	}
	
	//list all the bird type strings collected by slotBehavior
	void collectTypes () {
		//boxSlots = GetComponentsInChildren<slotBehavior>(); //Return an array of slotBehaviors to store
		boxContents = new string[boxSize];
		
		for(int i = 0; i < boxSize; i++) {
				
			boxContents[i] = boxSlots[i].followerType;
			Debug.Log (boxContents);
				
		}
	}
	
	//Spawn a box top based on the how many of each type of follower is in it
	//i.e. If there are 3 red and 3 blue followers in the box when it ships, then you get a special box like "RedBlue Berries"
	void spawnBoxTop () { 
		Debug.Log("Reds: " + colorCount[0] + " Greens: " + colorCount[1] + " Blues: " + colorCount[2] + " Yellows: " + colorCount[3] + " Purples: " + colorCount[4]);
		
		if (colorCount[0] == 6) {
			Debug.Log ("They are all Red");
		}
		
		GameObject boxTopSpawn = (GameObject)Instantiate(boxTop, transform.position, transform.rotation);
	}
	
	//Count how many of each type of color is in this box
	void countColors () { 
		
		colorCount[0] = 0;  //Red
		colorCount[1] = 0;  //Green
		colorCount[2] = 0;  //Blue
		colorCount[3] = 0;	//Yellow
		colorCount[4] = 0;	//Purple
		
		foreach (string searchToString in boxContents) {
			if (searchToString == "Red") {
				colorCount[0]++;
			}
		}
		foreach (string searchToString in boxContents) {
			if (searchToString == "Green") {
				colorCount[1]++;
			}
		}
		foreach (string searchToString in boxContents) {
			if (searchToString == "Blue") {
				colorCount[2]++;
			}
		}
		foreach (string searchToString in boxContents) {
			if (searchToString == "Yellow") {
				colorCount[3]++;
			}
		}
		foreach (string searchToString in boxContents) {
			if (searchToString == "Purple") {
				colorCount[4]++;
			}
		}
	}
}
