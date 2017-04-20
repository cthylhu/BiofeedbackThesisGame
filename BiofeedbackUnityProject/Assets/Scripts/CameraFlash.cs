using UnityEngine;
using System.Collections;

public class CameraFlash : MonoBehaviour {
	SpriteRenderer mySprite;

	public bool isFadingOut; 
	public Texture2D fadeTexture; 
	public float fadeSpeed = 0.2f; 
	public int drawDepth = -1000; 
	private float alpha = 1.0f; 
	private int fadeDir = -1; 


	void Start () {
		mySprite = GetComponentInChildren<SpriteRenderer>();
	}

	public void StartFlashDark() {
		mySprite.color = Color.black;
	}

	void Update() {
		mySprite.color = Color.Lerp(mySprite.color, Color.clear, Time.deltaTime * 1.0f);
	}

	void OnGUI() {

		if (isFadingOut)
         {
             alpha -= fadeDir * fadeSpeed * Time.deltaTime;
             alpha = Mathf.Clamp01(alpha);
 
             Color thisAlpha = GUI.color;
             thisAlpha.a = alpha;
             GUI.color = thisAlpha;
 
             GUI.depth = drawDepth;
 
             GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
         }
 	}
}
