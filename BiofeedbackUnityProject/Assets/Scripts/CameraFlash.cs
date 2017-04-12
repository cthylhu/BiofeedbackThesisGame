using UnityEngine;
using System.Collections;

public class CameraFlash : MonoBehaviour {

	SpriteRenderer mySprite;

	void Start () {
		mySprite = GetComponentInChildren<SpriteRenderer>();
	}

	public void StartFlashDark() {
		mySprite.color = Color.black;
	}

	void Update() {
		mySprite.color = Color.Lerp(mySprite.color, Color.clear, Time.deltaTime * 1.0f);
	}
}
