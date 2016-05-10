using UnityEngine;
using System.Collections;

public class CowardScript : MonoBehaviour {

    public GameObject other_player;
    public GameObject player;
    public static int coward_player1;
    public static int coward_player2;
    private float player_position;
    private float other_player_position;
    private float player_pos_check;
    private float other_player_pos_check;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        player_position = player.transform.position.x + player.transform.position.z;
        other_player_position = other_player.transform.position.x + other_player.transform.position.z;
        if (player_pos_check == 0.0f) player_pos_check = player_position;
        if (other_player_pos_check == 0.0f) other_player_pos_check = other_player_position;
        if (player_position == player_pos_check)
        {
            if (other_player_position > other_player_pos_check && other_player.name == "human2")
            {
                coward_player2 += 1;
            }
            if (other_player_position > other_player_pos_check && other_player.name == "human1")
            {
                coward_player1 += 1;
            }
        }
        if (other_player_position == other_player_pos_check)
        {
            if (player_position > player_pos_check && player.name == "human1")
            {
                coward_player1 += 1;
            }
            if (player_position > player_pos_check && player.name == "human2")
            {
                coward_player2 += 1;
            }

        }
    }
}
