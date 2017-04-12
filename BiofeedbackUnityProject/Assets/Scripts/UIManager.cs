using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Animator animTitle;
	public Animator animSubtitle;
	bool atStart;
	bool isPause;

	void Start(){
		atStart = true;
		isPause = false;
		GameObject.Find("MoonIcon").GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);	
	}

	void Update () {
		if (Input.anyKeyDown && atStart){
			animTitle.Play ("TitleFadeOut", -1);
			animSubtitle.Play("SubtitleFadeOut", -1);
			atStart = false;
		}
		if (!atStart && Input.GetKeyDown(KeyCode.Escape)) {
			isPause = !isPause;
			if(isPause)
	        	Time.timeScale = 0;
	        else
	        	Time.timeScale = 1;
		}
	}

	void OnGUI()
	{
		if(isPause)
			GUI.Button(new Rect(10,10,100,25), "Paused");
	}
}
