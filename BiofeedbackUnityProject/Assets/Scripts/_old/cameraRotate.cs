using UnityEngine;
using System.Collections;

public class cameraRotate : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.Euler(0, 180, 0);
		transform.Rotate(Vector3.up, 5.0f * Time.deltaTime);
	}
}

