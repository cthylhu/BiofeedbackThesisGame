using UnityEngine;
using System.Collections;

/// CameraSwoop plays the intro camera animation after the player has pressed a key 
/// 
/// 

public class CameraSwoop : MonoBehaviour {

	public Animator anim;
	bool atStart = true;

	void Update () {
		if (Input.anyKeyDown && atStart){

			Debug.Log("Play Camera Swoop");
			anim.Play ("CameraSwoop");
			atStart = false;
		}
	}

}
