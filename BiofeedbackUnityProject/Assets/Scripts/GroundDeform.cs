using UnityEngine;
using System.Collections;

public class GroundDeform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.L)) {
		Debug.Log("Morph Ground!");
			//StartCoroutine(LerpGroundMorphUp());
		}
	}

	public void MorphGround() {
		// raise pieces of ground
		//StartCoroutine(LerpGroundMorphUp());

	}

	/*private IEnumerator LerpGroundMorphUp() {

		float elapsedTime = 0;
		foreach (GameObject rock in TerrainObjList) {
			//GameObject rock = GameObject.Find("Rick");
			Vector3 oldPosition = rock.transform.position;
			Vector3 newPosition = new Vector3 (oldPosition.x, oldPosition.y + 3.0f, oldPosition.z);
			Debug.Log(oldPosition + " / " + newPosition);
	
	      	while (elapsedTime < terrainUpTime)
	      	{
				rock.transform.position = Vector3.Lerp(oldPosition, newPosition, elapsedTime);
				elapsedTime += Time.deltaTime * morphRate;
	        	yield return new WaitForEndOfFrame();
	     	}
     	}
     }*/
}
