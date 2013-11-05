using UnityEngine;
using System.Collections;

public class piSpawner : MonoBehaviour {
        
public GameObject[] followers; // A group of followers defined in the prefab editor
int followerIndex; // defines which follower to spawn
float spawnRange; // defines the area in which the follower can spawn relative to th Spawner Object
Vector3 spawnFromPoint; // tells the Spawner where to spawn something
bool spawnWindowOpen = false; //a follower can only spawn if true
        
	IEnumerator Start () {
                
        renderer.enabled = false;
		      
		for(;;) {
			
			var spawnRate = gameMaster.inst.spawnRateController;
        	float nextSpawnTime = Random.Range(0, spawnRate);
            yield return new WaitForSeconds(nextSpawnTime);                    
                
            followerIndex = Random.Range(0, followers.Length); // Give me a random int from followers[]
            spawnRange = Random.Range(0.5f, -0.5f);
            spawnFromPoint = new Vector3(0, spawnRange, 0);
                
            // Make followers spawn on a countdown timer
            // Every time the SpawnRate ticks, the follower can spawn at anytime between this tick,and the next tick.
                
            GameObject piClone = Instantiate(followers[followerIndex], transform.position + spawnFromPoint, transform.rotation) as GameObject;
            spawnWindowOpen = false;
            Debug.Log ("***Follower has been spawned***");
            yield return new WaitForSeconds(spawnRate - nextSpawnTime);
			spawnWindowOpen = true;
            Debug.Log ("***Ready for the next follower***");
		}
	}
	void Update () {
		

	}
}