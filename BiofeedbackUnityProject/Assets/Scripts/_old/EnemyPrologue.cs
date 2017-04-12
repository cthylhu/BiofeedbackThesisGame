using UnityEngine;
using System.Collections;

public class EnemyPrologue : MonoBehaviour {
	bool isMoving = false;
	//float enemyTimer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CursorHover.enemyTimer >= 5){
			isMoving = true;
		}

		if (isMoving) {
			//Vector3 EnemyToPlayer = GameObject.Find("PlayerControl").transform.position - transform.position;
			//transform.Translate(EnemyToPlayer * Time.deltaTime *5);
			transform.Translate(Vector3.forward * Time.deltaTime *5);
		}

	}


}
