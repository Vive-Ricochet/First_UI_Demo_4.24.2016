using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int scoreP1;
    public static int scoreP2;
    public static int endScore = 3;
    public static bool continueRound = true;

    private int round;
    public CollisionManager p1Hit;
    public CollisionManager p2Hit;

    // texture buttons for menu
    public Texture2D image_redUI;
    public Texture2D image_blueUI;

    public Texture2D[] image_redScore = new Texture2D[10];
    public Texture2D[] image_blueScore = new Texture2D[10];

    void Start() {

        image_redUI = Resources.Load("Menu/redUI", typeof(Texture2D)) as Texture2D;
        image_blueUI = Resources.Load("Menu/blueUI", typeof(Texture2D)) as Texture2D;

        int i = 0;
        foreach (object o in Resources.LoadAll("Text/Red", typeof(Texture2D))) {
            image_redScore[i] = o as Texture2D;
            i++;
        }

        i = 0;
        foreach (object o in Resources.LoadAll("Text/Blue", typeof(Texture2D))) {
            image_blueScore[i] = o as Texture2D;
            i++;
        }
    }
    
    // Update is called once per frame
    void Update() {

        if (p1Hit != null && p2Hit != null) {
            if (p1Hit.hit) { 
                scoreP2 += 1; print("Player 2 Scored:" + scoreP2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (p2Hit.hit) { 
                scoreP1 += 1; print("Player 1 Scored:" + scoreP1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (scoreP1 == endScore || scoreP2 == endScore) {

                Destroy(GameObject.Find("BGMplayer"));
                continueRound = false;
                SceneManager.LoadScene(3);

            }
        }
    }

    void OnGUI() {

        if (p1Hit != null && p2Hit != null) {
            GUI.DrawTexture(new Rect(Screen.width - 130, 0, 100, 100), image_redUI);
            GUI.DrawTexture(new Rect(10, Screen.height - 100, 100, 100), image_blueUI);

            GUI.DrawTexture(new Rect(Screen.width - 60, 20, 30, 50), image_redScore[scoreP1]);
            GUI.DrawTexture(new Rect(90, Screen.height - 80, 30, 50), image_blueScore[scoreP2]);
        }
    }
}
