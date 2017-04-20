using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public GameObject myGameManager;
	public GameObject player;
	public EnemyBehaviour myEnemyManager;
	public float moveSpeed;
	public float maxAttackDistance;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerControl");
		myGameManager = GameObject.Find("GameManagerObj");
		myEnemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {

		MoveEnemy();
		
	}

	public void MoveEnemy() {
		if (Vector3.Distance(transform.position, player.transform.position) > maxAttackDistance) {
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);

			transform.LookAt(player.transform);
		}
		else if (Vector3.Distance(transform.position, player.transform.position) <= maxAttackDistance) {
			//Start attack animation and cutscene and tell the player that they are dead
		}
	}

	public void StopEnemy() {
		
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Enemy trigger enter: "+other.name);
		if (other.name == "actor_player") {
			Debug.Log("Player is caught!");
			GameObject.Find("Main Camera").GetComponentInChildren<CameraFlash>().StartFlashDark();
			GameObject.Find("PlayerControl").GetComponent<PlayerManager>().PlayerReset();
			if (gameObject.tag == "EnemyIntro"){
				//Destroy(gameObject);
				GameObject[] IntroEnemies = GameObject.FindGameObjectsWithTag("EnemyIntro");
				foreach (GameObject e in IntroEnemies) {
					Destroy(e);
				}
			}
		}
		if (other.name == "SafeZoneCollider"){
			Debug.Log("Enemy collide with safe zone");
			if (myGameManager.GetComponent<OrbManager>().OrbCount >= myGameManager.GetComponent<OrbManager>().OrbCountCaptureTarget) {
				Debug.Log("Captured Enemy!");
				myEnemyManager.EnemyCapturedCount++;
				GameObject.Find("MoonIcon").GetComponent<SpriteRenderer>().color = new Color (1,1,1,1);	
				Destroy(this);
			}
		}

	}
}
