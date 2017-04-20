using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// When the player collides with an orb, increase the safe zone size and destroy the orb

public class OrbTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		//if (other.name == "PlayerControl" || other.name == "actor_player"){
		if (other.name == "PlayerControl"){
			GameObject.Find("GameManagerObj").GetComponent<ZoneManager>().IncreaseBlobSize();
			Destroy(gameObject); 
		}

	}

}
