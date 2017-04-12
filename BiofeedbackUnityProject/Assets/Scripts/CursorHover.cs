using UnityEngine;
using System.Collections;

public class CursorHover : MonoBehaviour {

	public Texture2D crosshairTexture;

    public float crosshairScale = 1;
    public GameObject lookCamera; 
    bool isLooking = false;

	public static float enemyTimer = 0;


	public static void startEnemyTimer() {
		enemyTimer += Time.deltaTime;
	}
	public static void stopEnemyTimer()	{
		
	}

    void Update() {
		Vector3 fwd = lookCamera.transform.forward;
		RaycastHit hit;
		if (Physics.Raycast(lookCamera.transform.position, fwd, out hit, 9)){
			if (hit.collider.name == "actor_friend"){
				isLooking = true;
			}
			else if (hit.collider.name == "actor_monster") {
				isLooking = true;
				startEnemyTimer();
			}
			else {
				isLooking = false;

			}
			//Debug.Log("Collider: "+hit.collider.name);
		}
		else {
			isLooking = false;
		}
    }

    void OnGUI()
    {
        //if not paused
        if(Time.timeScale != 0) {
        	if (isLooking) {
				Color colorPreviousGUI = GUI.color;
				GUI.color = new Color(1,0,0,0.25f);
    	    	GUI.DrawTexture(new Rect((Screen.width-crosshairTexture.width*crosshairScale)/2 ,(Screen.height-crosshairTexture.height*crosshairScale)/2, crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale),crosshairTexture);
				GUI.color = colorPreviousGUI;
			}
			else {
				Color colorPreviousGUI = GUI.color;
				GUI.color = new Color(colorPreviousGUI.r,colorPreviousGUI.g,colorPreviousGUI.b,0.25f);
    	    	GUI.DrawTexture(new Rect((Screen.width-crosshairTexture.width*crosshairScale)/2 ,(Screen.height-crosshairTexture.height*crosshairScale)/2, crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale),crosshairTexture);
				GUI.color = colorPreviousGUI;
			}
        }

    }
}
