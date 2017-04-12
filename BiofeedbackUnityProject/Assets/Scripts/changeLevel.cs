using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour {
	bool start;

	// Use this for initialization
	void Start () {
		start = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
			if (Input.GetKeyDown ("space")) {
				start = false;
				SceneManager.LoadScene ("main_scene");

			}
		}
	}

}
