using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject myGameManager;
	public GameObject myPlayer;
	public GameObject EnemyPrefab;
	public OrbManager myOrbManager;
	//public ZoneManager myZoneManager;

	public int EnemyCapturedCount = 0;

	public float minPosition = -20f;
	public float maxPosition = 20f;
	public float spawnHeight = 0.77f;
	public float noSpawnMin = -10f;
	public float noSpawnMax = 10f;
	public double EnemySpeed;
	public double IomSCLdata;

	//public int OrbCountCaptureTarget = 3;

	Renderer[] enemyModelParts;

	public List<GameObject> EnemyList = new List<GameObject>();

	void Start () {
		myOrbManager = myGameManager.GetComponent<OrbManager>();
		//enemyModelParts = EnemyActor.GetComponentsInChildren<Renderer>();
		//DespawnEnemy();
		//SpawnEnemy();
	}

	void Update () {
		// Control Enemy speed
		IomSCLdata = GameObject.Find("IomPanel").GetComponent<IomSensorsAutoOn>().sclData;
		EnemySpeed = IomSCLdata *10d;
		if (myOrbManager.OrbCount >= myOrbManager.OrbCountCaptureTarget) {
			if (EnemyList.Count != 0) {
				changeEnemyColor();	
			}
			myGameManager.GetComponent<ZoneManager>().ShrinkRate = 0;
			GameObject.Find("dark_field_particles").GetComponent<ParticleSystem>().startColor = new Color(1,0,0,1);
		}	
	}

	void ResetEnemySpeed() {
		//EnemySpeed = 
	}

	public void SpawnEnemy() {
		//if (EnemyList.Count < 5) {
			Debug.Log("Spawn Enemy!");
			Vector3 spawnPosition = new Vector3(Random.Range(minPosition, maxPosition), 0, Random.Range(minPosition, maxPosition));
			GameObject newEnemy = (GameObject)Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
			EnemyList.Add(newEnemy);
		//}
	}

	public void DespawnEnemy() {
		foreach (GameObject m in EnemyList){
			Destroy (m);
		}
	}

	/*public void SpawnEnemy() {
		Debug.Log("Spawning Enemy!");
		Vector3 spawnNewPosition = new Vector3(Random.Range(minPosition,maxPosition), spawnHeight, Random.Range(minPosition,maxPosition));
		while (spawnNewPosition.x > noSpawnMin && spawnNewPosition.x < noSpawnMax && spawnNewPosition.z > noSpawnMin && spawnNewPosition.z < noSpawnMax) {
			spawnNewPosition = new Vector3(Random.Range(minPosition,maxPosition), spawnHeight, Random.Range(minPosition,maxPosition));
		}

		EnemyActor.transform.position = spawnNewPosition;
		foreach (Renderer r in enemyModelParts){
			r.enabled = true;
		}
	}

	public void DespawnEnemy() {
		EnemyActor.transform.position = despawnPoint;
		//GameObject.Find("TestCube").transform.position = new Vector3(0, 50, 10);
		foreach (Renderer r in enemyModelParts){
			r.enabled = false;
		}
	}*/

	void changeEnemyColor() {
		GameObject EnemyBody = GameObject.Find("body_fix");
		if (EnemyBody !=null){
			EnemyBody.GetComponent<Renderer>().material = Resources.Load("Materials/enemy_skin_dark") as Material;
		}
		/*foreach (GameObject m in EnemyList){
			Renderer EnemySkin = m.GetComponentInChildren<Renderer>();
			EnemySkin.material = Resources.Load("enemy_skin_dark") as Material;
		}*/
	}

}
