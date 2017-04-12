using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbTiggerFirst : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		//if (other.name == "PlayerControl" || other.name == "actor_player"){
		if (other.name == "PlayerControl"){
			GameObject.Find("GameManagerObj").GetComponent<OrbManager>().SpawnOrb();
			Destroy(gameObject); 
		}
	}


}
