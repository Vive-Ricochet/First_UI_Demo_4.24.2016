using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Added_Results_Manager : MonoBehaviour {


    public Text BoF;
    public Text BoS;
    public Text Hoard;
    public Text Coward;
    public Text Travel;

    public static int TotalThrows;
    public static int TotalPickup;
    public static int TotalParry;
    public static int TotalTraveled;
    private float random;

	// Use this for initialization
	void Start ()
    {
        BoF = BoF.GetComponent<Text>();
        BoS = BoS.GetComponent<Text>();
        Hoard = Hoard.GetComponent <Text>();
        Coward = Coward.GetComponent<Text>();
        Travel = Travel.GetComponent<Text>();


        TotalThrows = ProjectileMaker.BoFP1 + ProjectileMaker.BoFP2 + TotalThrows;
        TotalPickup = ProjectileMaker.HoardP1 + ProjectileMaker.HoardP2 + TotalPickup;
        TotalParry = Parry.BoSP1 + Parry.BoSP2 + TotalParry;
        TotalTraveled = PlayerMovement.player1_travel + PlayerMovement.player2_travel + TotalTraveled;

        print("Traveled " + TotalTraveled + "units");
        print("Total Parries are " + TotalParry);
        print("Total Throws are " + TotalThrows);
        print("Total Pickedup are " + TotalPickup);

        random = Random.value;
        print(random);
    }
	
	
	// Update is called once per frame
	void Update () {
        if (random >= 0.5f)
        {
            Travel.text = "";
            Coward.text = "";
            if (ProjectileMaker.BoFP1 > ProjectileMaker.BoFP2)
            {
                BoF.text = "Balls of Fury: Player 1";
            }
            if (ProjectileMaker.BoFP1 < ProjectileMaker.BoFP2)
            {
                BoF.text = "Balls of Fury: Player 2";
            }
            if (ProjectileMaker.BoFP1 == ProjectileMaker.BoFP2)
            {
                BoF.text = "The Fury is Fierce";
            }

            if (Parry.BoSP1 > Parry.BoSP2)
            {
                BoS.text = "Balls of Steel: Player 1";
            }
            if (Parry.BoSP1 < Parry.BoSP2)
            {
                BoS.text = "Balls of Steel: Player 2";
            }
            if (Parry.BoSP1 == Parry.BoSP2)
            {
                BoS.text = "No one has Balls of Steel";
            }
        }
        if (random < 0.5f)
        {
            BoF.text = "";
            BoS.text = "";
            if (PlayerMovement.player1_travel > PlayerMovement.player2_travel)
            {
                Travel.text = "Traveler: Player 1"; 
            }
            if (PlayerMovement.player1_travel < PlayerMovement.player2_travel)
            {
                Travel.text = "Traveler: Player 2";
            }
            if (PlayerMovement.player1_travel == PlayerMovement.player2_travel)
            {
                Travel.text = "How did travel same distance?";
            }
            if (CowardScript.coward_player1 > CowardScript.coward_player2)
            {
                Coward.text = "Player 1 is a Coward";
            }
            if (CowardScript.coward_player1 < CowardScript.coward_player2)
            {
                Coward.text = "Player 2 is a Coward";
            }
            if (CowardScript.coward_player1 == CowardScript.coward_player2)
            {
                Coward.text = "You are both Brave Souls";
            }
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
