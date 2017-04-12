using UnityEngine;
using System.Collections;

public class walkingbob : MonoBehaviour
{
	public CharacterController playerController;
	public Animation anim;
	//Empty GameObject's animation component
	private bool isMoving;

	private bool left;
	private bool right;

	
	void Start ()
	{ //First step in a new scene/life/etc. will be "walkLeft"
		//splayerController = FindObjectOfType<CharacterController>();
		left = true;
		right = false;
	}


	void Update ()
	{
		float inputX = Input.GetAxis ("Horizontal"); //Keyboard input to determine if player is moving
		float inputY = Input.GetAxis ("Vertical");

		if (inputX != 0 || inputY != 0) {
				isMoving = true;	
		} else if (inputX == 0 && inputY == 0) {
				isMoving = false;	
		}

		CameraAnimations ();

	}

	void CameraAnimations ()
	{
		if (playerController.isGrounded == true) {
			if (isMoving == true) {
				if (left == true) {
						if (!anim.isPlaying) {			//Waits until no animation is playing to play the next
								anim.Play ("bobLeft");
								left = false;
								right = true;
						}
				}
				if (right == true) {
						if (!anim.isPlaying) {
								anim.Play ("bobRight");
								right = false;
								left = true;
						}
				}
			}			
	}
	}
}