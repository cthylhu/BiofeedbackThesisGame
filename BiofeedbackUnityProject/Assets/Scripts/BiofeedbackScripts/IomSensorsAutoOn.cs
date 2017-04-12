using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Iom sensors. Searching for, initializing, and reading from Iom finger sensors.
/// Requires ui Text elements to display the readings
/// and uses a FileWriter to write them to text files.
/// </summary>
public class IomSensorsAutoOn : MonoBehaviour
{
	// the class assumes that the following Text properties are not null!
	public Text statusText;
	public Text sclText;
	public Grapher sclGraph;
	public Text hrvText;
	public Grapher hrvGraph;
	public Text qrsText;
	public Text bpmText;
	public double sclData;	// Skin Conductance Level
	private double hrvData;	// Heart Rate Variability
	private bool qrsData;	// in a QRS complex right now? (a heart signal peak)
	private double bpmData;	// Heart beats per minute
	private IOM iom;
	public string ID_Label;
	float timeAtDataPoint;

	// Called once initally, setting up UI components
	void Awake ()
	{
		statusText.text = "Not connected";
		sclText.text = "N/A yet";
		hrvText.text = "N/A yet";
		qrsText.text = "N/A yet";
		bpmText.text = "N/A yet";
	}
	
	// Called once when enabled, using this for hardware initialization
	void Start ()
	{
		Debug.Log ("Iom device Initializing");
		iom = new IOM ();
		int deviceCount = iom.setup ();
		statusText.text = string.Format("Initialized ({0} found)", deviceCount);
		iom.setAvgNum (10); // set avergae peaks number
		iom.startReadingData ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (iom != null) {
			timeAtDataPoint = Time.realtimeSinceStartup;
			sclData = iom.getSCL ();
			hrvData = iom.getHRV ();
			qrsData = iom.getQRS ();
			bpmData = iom.getBPM ();
			UpdateIomDataUIText ();
			WriteIomDataFile ();
			if (sclGraph != null) {
				sclGraph.AddPoint(Time.realtimeSinceStartup, sclData);
			}
			if (hrvGraph != null) {
				hrvGraph.AddPoint(Time.realtimeSinceStartup, hrvData);
			}

		}
	}

	void UpdateIomDataUIText ()
	{
		sclText.text = sclData.ToString ("R");
		hrvText.text = hrvData.ToString ("R");
		qrsText.text = qrsData.ToString ();
		bpmText.text = bpmData.ToString ("R");
	}
	
	/*void WriteIomDataFile ()
	{
		FileWriter.TxtSaveByStr ("Iom_SCL", sclData.ToString ("R"));
		FileWriter.TxtSaveByStr ("Iom_HRV", hrvData.ToString ("R"));
		FileWriter.TxtSaveByStr ("Iom_QRS", qrsData.ToString ());
		FileWriter.TxtSaveByStr ("Iom_BPM", bpmData.ToString ("R"));
	}*/

	void WriteIomDataFile ()
	{
		string SCL_string = timeAtDataPoint.ToString("R") + "," + sclData.ToString ("R");
		string BPM_string = timeAtDataPoint.ToString("R") + "," + bpmData.ToString ("R");
		FileWriter.TxtSaveByStr ("Iom_SCL"+ID_Label, SCL_string);
		FileWriter.TxtSaveByStr ("Iom_HRV"+ID_Label, hrvData.ToString ("R"));
		FileWriter.TxtSaveByStr ("Iom_QRS"+ID_Label, qrsData.ToString ());
		FileWriter.TxtSaveByStr ("Iom_BPM"+ID_Label, BPM_string);
	}
	
	void OnDestroy ()
	{
		if (iom != null) {
			Debug.Log ("Iom Device Exiting");
			iom.stopReadingData ();
			iom.close (); // free the resources
			iom = null;
		}
	}
}
