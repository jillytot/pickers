using UnityEngine;
using System.Collections;

public class boxTopBehavior : MonoBehaviour {
	public float boxTopSpeed = 10.0f;
	public float deathTime = 3.0f;

// make boxtop move and dissapear after a certain amount of time.
	IEnumerator Start () {
		
		for (;;) {
		
			Debug.Log("put a lid on it and wait this many seconds: " + deathTime);
			yield return new WaitForSeconds(deathTime);
			Destroy(this.gameObject);
		}
	}
	
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * boxTopSpeed);
		
	}
}
