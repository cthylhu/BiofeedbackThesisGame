using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Manages environment generation, weather effects, and orb spawning

public class EnvironmentManager : MonoBehaviour {
	public GameObject myGameManager;
	public GameObject noTreeSpawnArea;
	//public GameObject IomPanelData;

	public GameObject TreePrefab;
	public GameObject TerrainPrefab;
	public List<GameObject> TreeObjList = new List<GameObject>();
	List<GameObject> TerrainObjList = new List<GameObject>();
	public GameObject MoonObject;

	public int treeDensity;
	public int rockDensity;
	public Vector2 maxRange;
	public float minRangeFromOtherObjects;
	public float instantiatedScaleFactor;
	public float noSpawnMin = -6f;
	public float noSpawnMax = 6f;
	bool useScaling;
	public float terrainUpTime = 1;
	public float morphRate;

	//public GameObject orbPrefab;
	//float spawnOrbHeight = 5f;
	//public float minPosition = -20f;
	//public float maxPosition = 20f;

	public float SCLthreshold;

	void Start () {
		useScaling = true;
		for (int i=0; i<treeDensity; i++) {
			ProcedurallyGenerateStuff(TreeObjList, TreePrefab, 0f, instantiatedScaleFactor);
		}
		useScaling = false;
		/*for (int j=0; j<rockDensity; j++) {
			ProcedurallyGenerateStuff(TerrainObjList, TerrainPrefab, -2.5f, 1);
		}*/

	}

	public void ProcedurallyGenerateStuff(List<GameObject> InstantiatedObjList, GameObject prefabModel, float spawnHeight, float scaleFactor) {
		bool isTooClose = false;
		Bounds noSpawnBounds = noTreeSpawnArea.GetComponent<Collider>().bounds;
		Vector3 randomPosition = new Vector3(Random.Range(-maxRange.x, maxRange.x), spawnHeight, Random.Range(-maxRange.y, maxRange.y));

		foreach (GameObject eachInstantiatedThing in InstantiatedObjList) {
			if (noSpawnBounds.Contains(randomPosition)){
				isTooClose = true;
				ProcedurallyGenerateStuff(InstantiatedObjList, prefabModel, spawnHeight, scaleFactor);
				break;
			}
			/*if (randomPosition.x > noSpawnMin && randomPosition.x < noSpawnMax && randomPosition.z > noSpawnMin && randomPosition.z < noSpawnMax){
				isTooClose = true;
				ProcedurallyGenerateStuff(InstantiatedObjList, prefabModel, spawnHeight, scaleFactor);
				break;
			}*/
			if (Vector3.Distance(randomPosition, eachInstantiatedThing.transform.position) < minRangeFromOtherObjects) {
				isTooClose = true;
				ProcedurallyGenerateStuff(InstantiatedObjList, prefabModel, spawnHeight, scaleFactor);
				break;
			}
		}

		if (!isTooClose) {
			GameObject instantiatedStuff = GameObject.Instantiate(prefabModel, randomPosition, Quaternion.identity) as GameObject;
			instantiatedStuff.transform.Rotate(new Vector3(0.0f, Random.Range(-180.0f, 180.0f), 0.0f));
			if (useScaling) {
				instantiatedStuff.transform.localScale *= Random.Range(1.0f - scaleFactor, 1.0f + scaleFactor);
			}
			InstantiatedObjList.Add(instantiatedStuff);
		}
	}

	/*public void SpawnOrb() {
		bool isTooClose = false;
		Bounds safeZoneBounds = noTreeSpawnArea.GetComponent<Collider>().bounds;
		Vector3 spawnNewPosition = new Vector3(Random.Range(minPosition,maxPosition), spawnOrbHeight, Random.Range(minPosition,maxPosition));

		if (safeZoneBounds.Contains(spawnNewPosition)){
			isTooClose = true;
			SpawnOrb();
		}

		foreach (GameObject obj in TreeObjList) {
			if (Vector3.Distance(spawnNewPosition, obj.transform.position) < 3 ) {
				isTooClose = true;
				SpawnOrb();
				break;
			}
		}
		if (!isTooClose) {
			Instantiate(orbPrefab, spawnNewPosition, transform.rotation);
			Debug.Log("Spawn Orb!");
		}

	}*/

}
