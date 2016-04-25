using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsScript : MonoBehaviour {

    public Text Thrown;
    public Text PickedUp;
    public Text Parry;

	// Use this for initialization
	void Start () {
        Thrown = Thrown.GetComponent<Text>();
        PickedUp = PickedUp.GetComponent<Text>();
        Parry = Parry.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrown.text = "Total Throws = " + Added_Results_Manager.TotalThrows;
        PickedUp.text = "Total Items picked up = " + Added_Results_Manager.TotalPickup;
        Parry.text = "Total number of Parries = " + Added_Results_Manager.TotalParry;
	}
}
