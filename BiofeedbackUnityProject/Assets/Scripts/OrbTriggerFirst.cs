using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbTriggerFirst : MonoBehaviour {
	public GameObject myGameManager;

	void OnTriggerEnter(Collider other) {

		//if (other.name == "PlayerControl" || other.name == "actor_player"){
		if (other.name == "PlayerControl"){
			myGameManager.GetComponent<ZoneManager>().ChangeTheWorldIntro();
			//GameObject.Find("GameManagerObj").GetComponent<ZoneManager>().IncreaseBlobSize();
			Destroy(gameObject); 
		}
	}


}
