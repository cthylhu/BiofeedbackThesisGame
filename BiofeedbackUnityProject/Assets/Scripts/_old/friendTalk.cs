using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class friendTalk : MonoBehaviour {
	public GameObject textBox;
	public Text dialogue;

	//bool isColliding = false;
	public static bool isTalking = false;
	//bool isWaiting = false;

	public TextAsset textFile;
	public string[] textLines;				//all the speech text
	public int currentLine = 0;
	public int endAtLine;

	public CharacterController player;
	//public Animation anim;

	//float letterPause = 0.06f;
	//public AudioClip typeSound1;
	//public AudioClip typeSound2;
	
	string message;

	/*
	// Use this for initialization
	void Start () {
		dialogue = GameObject.Find("Dialogue").GetComponent<Text>();
		dialogue.text = "";
		DisableTextBox();
		if (textFile != null) {
			textLines = textFile.text.Split('\n');
			Debug.Log (textLines);
			message = textLines[currentLine];
		}

		if (endAtLine == 0){
			endAtLine = textLines.Length - 1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// if reached the end of the text file, then close the text box
		if (currentLine > endAtLine) {
			DisableTextBox();
			isWaiting = false;
		}
		else {
			if (isTalking){
				isTalking = false;
				StartCoroutine(TypeText ());
				isWaiting = true;
			}
			if (isWaiting && Input.GetMouseButtonDown(0)) {
				Debug.Log("Clicked left!");
				dialogue.text = "";
				currentLine += 1;
				message = textLines[currentLine];
				StartCoroutine(TypeText());
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if (!isColliding) {
			EnableTextBox();
			isColliding = true;
			isTalking = true;
			Debug.Log("Activate text box!");
		}

		//textBox.SetActive(true);
		//anim.Play("textboxFadeIn");
	}

	public void EnableTextBox() {
		textBox.SetActive(true);
	}

	public void DisableTextBox() {
		textBox.SetActive(false);
	}

	IEnumerator TypeText () {
		foreach (char letter in message.ToCharArray()) {			
		    dialogue.text += letter;
		    //Debug.Log(dialogue.text);
		    //if (typeSound1 && typeSound2)
		        //SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
		    //yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		Debug.Log("Stop talking!");
	}
	*/
}
