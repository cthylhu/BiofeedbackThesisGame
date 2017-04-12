using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public GameObject messageBox;
	public Text message;
	public TextAsset textFile;
	public string[] textLines;

	public int currentLine = 0;
	public int endAtLine;

	public CharacterController player;
	//public Animation anim;


	void Start () {
		message = GameObject.Find("NarrativeText").GetComponent<Text>();
		message.text = "";
		//EnableTextBox();
		DisableTextBox();

		if (textFile != null) {
			textLines = textFile.text.Split('\n');
			message.text = textLines[currentLine];

		}

		if (endAtLine == 0){
			endAtLine = textLines.Length - 1;
		}
	}

	void Update () {
		if (!friendTalk.isTalking){
			if (Input.GetMouseButtonDown(0)){
				DisableTextBox();
			}
		}
	}

	public void EnableTextBox() {
		messageBox.SetActive(true);
	}

	public void DisableTextBox() {
		messageBox.SetActive(false);
	}
}