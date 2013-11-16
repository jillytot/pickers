using UnityEngine;
using System.Collections;

public class functionThang : MonoBehaviour {

	public int counter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {

			counter = derpFunction (counter);

		}
	}

	int derpFunction (int value) {
		int newValue = value +2;
		return newValue;
	}
}
