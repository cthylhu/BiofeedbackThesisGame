using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrbManager : MonoBehaviour {
	public GameObject noSpawnArea;
	public GameObject orbPrefab;
	public EnvironmentManager myEnvironmentManager;
	float spawnOrbHeight = 5f;
	public float minPosition = -20f;
	public float maxPosition = 20f;

	public int OrbCount = 0;					// total orb count
	public int OrbThreshold;
	public int OrbCountCaptureTarget = 3;

	// Use this for initialization
	void Start () {
	
	}

	public void SpawnOrb() {
		bool isTooClose = false;
		Bounds safeZoneBounds = noSpawnArea.GetComponent<Collider>().bounds;
		Vector3 spawnNewPosition = new Vector3(Random.Range(minPosition,maxPosition), spawnOrbHeight, Random.Range(minPosition,maxPosition));

		if (safeZoneBounds.Contains(spawnNewPosition)){
			isTooClose = true;
			SpawnOrb();
		}

		/*foreach (GameObject obj in myEnvironmentManager.TreeObjList) {
			if (Vector3.Distance(spawnNewPosition, obj.transform.position) < 3 ) {
				isTooClose = true;
				SpawnOrb();
				break;
			}
		}*/
		if (!isTooClose) {
			Instantiate(orbPrefab, spawnNewPosition, transform.rotation);
			Debug.Log("Spawn Orb!");
		}

	}
}
