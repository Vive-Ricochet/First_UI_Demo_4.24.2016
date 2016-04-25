using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Added_Results_Manager : MonoBehaviour {


    public Text BoF;
    public Text BoS;
    public Text Hoard;

    public static int TotalThrows;
    public static int TotalPickup;
    public static int TotalParry;

	// Use this for initialization
	void Start ()
    {
        BoF = BoF.GetComponent<Text>();
        BoS = BoS.GetComponent<Text>();
        Hoard = Hoard.GetComponent <Text>();

        TotalThrows = ProjectileMaker.BoFP1 + ProjectileMaker.BoFP2;
        TotalPickup = ProjectileMaker.HoardP1 + ProjectileMaker.HoardP2;
        TotalParry = Parry.BoSP1 + Parry.BoSP2;

        print("Total Throws are " + TotalThrows);
        print("Total Pickedup are " + TotalPickup);
        print("Total Parries are " + TotalParry);
    }
	
	
	// Update is called once per frame
	void Update () {
        if (ProjectileMaker.BoFP1 > ProjectileMaker.BoFP2) {
            BoF.text = "Balls of Fury: Player 1";
        }
        if (ProjectileMaker.BoFP1 < ProjectileMaker.BoFP2) {
            BoF.text = "Balls of Fury: Player 2";
        }
        if (ProjectileMaker.BoFP1 == ProjectileMaker.BoFP2) {
            BoF.text = "The Fury is Fierce";
        }
        if (Parry.BoSP1 > Parry.BoSP2) {
            BoS.text = "Balls of Steel: Player 1";
        }
        if (Parry.BoSP1 < Parry.BoSP2) {
            BoS.text = "Balls of Steel: Player 2";
        }
        if (Parry.BoSP1 == Parry.BoSP2) {
            BoS.text = "No one has Balls of Steel";
        }
        if (ProjectileMaker.HoardP1 > ProjectileMaker.HoardP2) {
            Hoard.text = "Hoarder:  Player 1";
        }
        if (ProjectileMaker.HoardP1 < ProjectileMaker.HoardP2) {
            Hoard.text = "Hoarder: Player 2";
        }
        if (ProjectileMaker.HoardP1 == ProjectileMaker.HoardP2) {
            Hoard.text = "You're both Hoarders";
        }

    }
}
