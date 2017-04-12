using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {

	public GameObject camIntro;
	public GameObject camPlay;
	public GameObject PlayerCont;
	Component[] compList;
	MonoBehaviour someJS;

	void Start() {
		camIntro.GetComponent<Camera>().enabled = true;
		camIntro.tag = "MainCamera";
		camPlay.tag = "OtherCamera";
		someJS = PlayerCont.GetComponent<CharacterMotor>() as MonoBehaviour;	// Cast CharacterMotor javascript for use in C#
		DisableCameraComponents();
	}

	public void SwitchCamera(){
		Debug.Log("Switch Camera event");
		camIntro.tag = "OtherCamera";
		camPlay.tag = "MainCamera";
		camIntro.GetComponent<Camera>().enabled = false;
		//GameObject.Find("Title").SetActive(false);
		//GameObject.Find("Subtitle").SetActive(false);
		EnableCameraComponents();
	}

	void EnableCameraComponents() {
		camPlay.GetComponent<Camera>().enabled = true;
		camPlay.GetComponent<MouseLook>().enabled = true;
		PlayerCont.GetComponent<MouseLook>().enabled = true;
		PlayerCont.GetComponent<CharacterController>().enabled = true;
		PlayerCont.GetComponent<CursorHover>().enabled = true;
		someJS.enabled = true;
	}

	void DisableCameraComponents() {
		camPlay.GetComponent<Camera>().enabled = false;
		camPlay.GetComponent<MouseLook>().enabled = false;
		PlayerCont.GetComponent<MouseLook>().enabled = false;
		PlayerCont.GetComponent<CharacterController>().enabled = false;
		PlayerCont.GetComponent<CursorHover>().enabled = false;
		someJS.enabled = false;
	}
}
