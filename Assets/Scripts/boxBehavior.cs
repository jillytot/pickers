﻿using UnityEngine;
using System.Collections;

public class boxBehavior : MonoBehaviour {
	
	int boxCount; // Number of things in the box
	int boxSize; // The size of the box
	public bool boxFull; // Is the box full?
	slotBehavior[] boxSlots; //array of slotBehavior instances
	bool[] slotIndex; // containter for boxSlots array
	public static boxBehavior thisBox;
	
	void Awake() {
		
		thisBox = this;	
	}
 
	void Start () {
 
    	boxSize = transform.childCount;
    	Debug.Log ("Children = " + boxSize);
 
	}
 
	void Update () {
 
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
         		if(boxSlots[i].isFull) boxCount++;     
       	}
 
       	if(boxCount == boxSize) {
         	boxFull = true;
         	Debug.Log ("Box is full");
       	}
 
      	Debug.Log ("Followers in Box: " + boxCount);
    	}
	}
}