using UnityEngine;
using System.Collections;

public class WeatherManager : MonoBehaviour {
	public GameObject IomPanelData;
	public GameObject rainEmitter;
	public AudioSource rainSound;
	public float SCLthreshold;

	public float musicFadeSpeed;    // The speed at which the music fades.

   	void Start () {
		rainSound = rainEmitter.GetComponent<AudioSource>();
        rainSound.volume = 0.0F;
	}

	void Update () {
		/*if (IomPanelData.GetComponent<IomSensorsAutoOn>().sclData > SCLthreshold) {
			StartCoroutine(FadeInMusic());
		}
		if (IomPanelData.GetComponent<IomSensorsAutoOn>().sclData <= SCLthreshold) {
			StartCoroutine(FadeOutMusic());
		}*/
		if (Input.GetKeyDown(KeyCode.N)) {
			StartCoroutine(FadeInMusic());
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			StartCoroutine(FadeOutMusic());
		}
	}

	public void StartRaining() {
		rainEmitter.GetComponent<ParticleSystem>().Play();
		rainSound.Play();
	}

	public void StopRaining () {
		rainEmitter.GetComponent<ParticleSystem>().Stop();
	}

	private IEnumerator FadeInMusic() {
		StartRaining();
		while(rainSound.volume < 1.0f)
        {
			rainSound.volume += musicFadeSpeed * Time.deltaTime;
            yield return 1.0f;
        }
		rainSound.volume = 1.0f;
    }

    private IEnumerator FadeOutMusic()
    {
		StopRaining();
        while(rainSound.volume > 0.0f)
        {
			rainSound.volume -= musicFadeSpeed * Time.deltaTime;
            yield return 0.0f;
        }
		rainSound.volume = 0.0f;
        //insert an on-complete hook here before coroutine exits
    }


}
