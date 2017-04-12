using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalibrationController : MonoBehaviour {
	public GameObject TextObject;
	int textcount = 0;
	bool notAtStart = true;
	public float SecondsOfDelay = 10f;


	// Use this for initialization
	void Start () {
		TextObject.GetComponent<Text>().text = "Welcome to the Calibration Tool! Please follow the on-screen instructions. Before beginning the game, we need a few readings from you. (click to continue)";

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)) {
			if (textcount == 0) {
				TextObject.GetComponent<Text>().text = "Before beginning the game, we need a few readings from you. (click to continue)";
				textcount++;
				notAtStart = false;
			}
			if (!notAtStart && textcount == 1) {
				TextObject.GetComponent<Text>().text = "Please relax and sit still for the next few seconds.";
				textcount++;
				StartCoroutine(DelayForSeconds(SecondsOfDelay));
			}
		}

	}

	private IEnumerator DelayForSeconds(float sec){
		yield return new WaitForSeconds(sec);
		TextObject.GetComponent<Text>().text = "Thank you.";
		SceneManager.LoadScene("main_scene");
	}

}
