using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Manages the visual and physical size of the safe zone

public class ZoneManager : MonoBehaviour {

	public GameObject myGameManager;
	public EnvironmentManager myEnvironmentManager;
	public Projector blobProjection;			// shadow projector
	public GameObject safeZone;					// safe zone trigger

	public Text debugmessage;
	public int OrbCount = 0;					// total orb count
	public int OrbThreshold;
	public AudioSource audio_Orb;    

	bool increaseSize = false;
	public float growthTime = 2f;				// Time it takes for the shadow to grow (should be short)

	float shrinkOldSize;						// The previous size of shadow to shrink from
	public float shrinkMinSize = 2f;			// Minimum shadow size
	Vector3 safeZoneSizeOld;					// The previous size of the safe zone to shrink from
	Vector3 safeZoneMinSize;					// Minimum safe zone size
	public float ShrinkRate = 0.5f;				// Shrink rate modifier


	public bool atBeginning;
	public float rateOfColorChange;
	float blend = 1f;

	public Color fogColorDark;
	public Color fogColorLight;

	void Start () {
		debugmessage = GameObject.Find("OrbCount").GetComponent<Text>();
		safeZoneMinSize = safeZone.transform.localScale;					// set minimum size of safe zone collider trigger

		blobProjection.orthographicSize = 225;			// enshroud everything in darkness
		//safeZone.transform.localScale = new Vector3 (225, 225, 225);
		RenderSettings.skybox.SetFloat("_Blend", blend);
		RenderSettings.fogColor = fogColorDark;
		atBeginning = true;
		//RenderSettings.skybox.SetColor("_TintColor", new Color(0,0,0,1));
	}

	void Update () {
		debugmessage.text = "Counter: " + myGameManager.GetComponent<OrbManager>().OrbCount;

		// If the safe zone should increase, Lerp the growth of the safe zone
		if (atBeginning) {
			if (myGameManager.GetComponent<OrbManager>().OrbCount == 1) {
				StartCoroutine(LerpBlobSizeBig());
				RenderSettings.fogColor = fogColorLight;
				atBeginning = false;
			}
		}
		else {
			if (increaseSize) {
				StartCoroutine(LerpBlobSize());
				Debug.Log("OrthoSize: " + blobProjection.orthographicSize);
			}
			//RenderSettings.fogColor = fogColorLight;
			// Constantly shrink the safe zone, to a minimum size
			else {
				shrinkOldSize = blobProjection.orthographicSize;
				blobProjection.orthographicSize = Mathf.Lerp(shrinkOldSize, shrinkMinSize, Time.deltaTime*ShrinkRate);

				safeZoneSizeOld = safeZone.transform.localScale;
				safeZone.transform.localScale = Vector3.Lerp(safeZoneSizeOld, safeZoneMinSize, Time.deltaTime*ShrinkRate);
			}
		}
	}

	// Called by an OrbTrigger
	public void IncreaseBlobSize ()	{
		increaseSize = true;
		myGameManager.GetComponent<OrbManager>().OrbCount++;
		audio_Orb.Play();
		/*if (OrbCount >= OrbThreshold) {
			myEnvironmentManager.StartRaining();
			//myEnvironmentManager.MorphGround();
		}*/
	}

	// Grow the blob size 
	private IEnumerator LerpBlobSize() {
		increaseSize = false;
		float elapsedTime = 0;
		float oldSize = blobProjection.orthographicSize;
		float newSize = oldSize + 2.0f;
		Vector3 oldSizeScale = safeZone.transform.localScale;
		Vector3 newSizeScale = oldSizeScale + new Vector3(5.66f,5.66f,5.66f);

      	while (elapsedTime < growthTime)
      	{
			blobProjection.orthographicSize = Mathf.Lerp(oldSize, newSize, (elapsedTime / growthTime));
			safeZone.transform.localScale = Vector3.Lerp(oldSizeScale, newSizeScale, (elapsedTime / growthTime));
			elapsedTime += Time.deltaTime;
        	yield return new WaitForEndOfFrame();
     	}
		// Spawn new orb at random position
		myGameManager.GetComponent<OrbManager>().SpawnOrb();
     }

	private IEnumerator LerpBlobSizeBig() {
		increaseSize = false;
		float elapsedTime = 0;
		float oldSize = blobProjection.orthographicSize;
		float newSize = 2.0f;
		Vector3 oldSizeScale = safeZone.transform.localScale;
		Vector3 newSizeScale = oldSizeScale + new Vector3(5.66f,5.66f,5.66f);  

		float oldBlend = 1f;
		float newBlend = 0f;  	

      	while (elapsedTime < growthTime)
      	{
			blobProjection.orthographicSize = Mathf.Lerp(oldSize, newSize, (elapsedTime / growthTime));
			safeZone.transform.localScale = Vector3.Lerp(oldSizeScale, newSizeScale, (elapsedTime / growthTime));

			blend = Mathf.Lerp(oldBlend, newBlend, (elapsedTime / growthTime));
			RenderSettings.skybox.SetFloat("_Blend", blend);

			elapsedTime += Time.deltaTime;


        	yield return new WaitForEndOfFrame();
     	}
		// Spawn new orb at random position
		//myEnvironmentManager.GetComponent<EnvironmentManager>().SpawnOrb();
		myGameManager.GetComponent<OrbManager>().SpawnOrb();
     }
}