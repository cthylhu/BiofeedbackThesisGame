using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject myGameManager;
	public GameObject myPlayer;
	public GameObject EnemyPrefab;
	public GameObject EnemyIntroPrefab;

	public int EnemyCapturedCount = 0;

	public float minPosition = -20f;
	public float maxPosition = 20f;
	public float spawnHeight = 0.77f;
	public float noSpawnMin = -10f;
	public float noSpawnMax = 10f;
	public double EnemySpeed;
	public double IomSCLdata;

	public bool canSpawnEnemy = false;

	//public int OrbCountCaptureTarget = 3;

	Renderer[] enemyModelParts;

	public List<GameObject> EnemyList = new List<GameObject>();

	void Start () {
		//enemyModelParts = EnemyActor.GetComponentsInChildren<Renderer>();
		//DespawnEnemy();
		//SpawnEnemy();
	}

	void Update () {
		// Control Enemy speed
		IomSCLdata = GameObject.Find("IomPanel").GetComponent<IomSensorsAutoOn>().sclData;
		EnemySpeed = IomSCLdata *10d;
		if (myGameManager.GetComponent<OrbManager>().OrbCount >= myGameManager.GetComponent<OrbManager>().OrbCountCaptureTarget) {
			if (EnemyList.Count != 0) {
				changeEnemyColor();	
			}
			myGameManager.GetComponent<ZoneManager>().ShrinkRate = 0;
			GameObject.Find("dark_field_particles").GetComponent<ParticleSystem>().startColor = new Color(1,0,0,1);
		}	

		if (Input.GetKeyDown(KeyCode.G)) {
			SpawnEnemyIntro();
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
			EnemyList.Remove(m);
			Destroy(m);
		}
	}

	public void SpawnEnemyIntro() {
		List<GameObject> enemies = new List<GameObject>();
		Vector3 enemyPosition1 = new Vector3(myPlayer.transform.position.x + 10, myPlayer.transform.position.y, myPlayer.transform.position.z);
		Vector3 enemyPosition2 = new Vector3(myPlayer.transform.position.x - 10, myPlayer.transform.position.y, myPlayer.transform.position.z);
		Vector3 enemyPosition3 = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y, myPlayer.transform.position.z + 10);
		Vector3 enemyPosition4 = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y, myPlayer.transform.position.z - 10);

		GameObject newEnemy1 = (GameObject)Instantiate(EnemyIntroPrefab, enemyPosition1, Quaternion.identity);
		enemies.Add(newEnemy1);
		GameObject newEnemy2 = (GameObject)Instantiate(EnemyIntroPrefab, enemyPosition2, Quaternion.identity);
		enemies.Add(newEnemy2);
		GameObject newEnemy3 = (GameObject)Instantiate(EnemyIntroPrefab, enemyPosition3, Quaternion.identity);
		enemies.Add(newEnemy3);
		GameObject newEnemy4 = (GameObject)Instantiate(EnemyIntroPrefab, enemyPosition4, Quaternion.identity);
		enemies.Add(newEnemy4);

		foreach (GameObject e in enemies) {
			e.GetComponent<EnemyMovement>().moveSpeed = 1.5f;
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
