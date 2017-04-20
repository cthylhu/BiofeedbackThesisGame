using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject myPlayer;
	public GameObject myEnemyManager;
	public Camera myMainCamera;
	public GameObject mySoundEffects;
	public GameObject MoonObject;
	public AudioSource soundCollect;
	public AudioSource soundEnterSafeZone;

	public bool isSafe;			// for preventing double triggers
	public bool spawnTrue;

	void Start() {
		//isSafe = true;
		PlayerReset();
		AudioSource[] audioSourceList = mySoundEffects.GetComponents<AudioSource>();
		soundCollect = audioSourceList[0];
		soundEnterSafeZone = audioSourceList[1];
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.N)){
			pointPlayerCameraAtSky();
		}
	}

	public void PlayerReset() {
		myPlayer.transform.position = Vector3.up;
		myPlayer.transform.rotation = Quaternion.LookRotation(Vector3.forward);
	}

	void pointPlayerCameraAtSky() {
		//myMainCamera.GetComponent<MouseLook>.enabled = false;
		myMainCamera.transform.LookAt(MoonObject.transform);
	}

	void OnTriggerEnter (Collider other){
		//Debug.Log("This collider: " + this.name);
		//Debug.Log("Other collider: "+other.name);

		// when the player enters safe zone from unsafe zone, despawn enemy
		if (other.name == "SafeZoneCollider" && !isSafe) {
			myMainCamera.GetComponentInChildren<CameraFlash>().StartFlashDark();
			soundEnterSafeZone.Play();
			myEnemyManager.GetComponent<EnemyBehaviour>().DespawnEnemy();
			isSafe = true;
		}
	}

	void OnTriggerExit(Collider other){
		//Debug.Log("Other collider: "+other.name);
		// if player exits the safe zone, spawn the enemy
    	if(other.gameObject.name == "SafeZoneCollider" && isSafe && myEnemyManager.GetComponent<EnemyBehaviour>().canSpawnEnemy){
			myEnemyManager.GetComponent<EnemyBehaviour>().SpawnEnemy();
			isSafe = false;
    	}
	}
}
