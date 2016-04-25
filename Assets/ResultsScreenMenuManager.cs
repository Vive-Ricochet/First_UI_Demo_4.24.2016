using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultsScreenMenuManager : MonoBehaviour {

    // texture buttons for menu
    public Texture2D image_frame;

    public Texture2D[] button_rematch = new Texture2D[3];
    public Texture2D[] button_mainMenu = new Texture2D[3];


    public int menuState = 0;

    private InputManager input;
    private bool canNavigate = true;
    private int menuSize = 1;

    // Use this for initialization
    void Start() {

        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        image_frame = Resources.Load("Menu/menu_frame", typeof(Texture2D)) as Texture2D;
        button_rematch[0] = Resources.Load("Menu/button_rematch00", typeof(Texture2D)) as Texture2D;
        button_rematch[1] = Resources.Load("Menu/button_rematch01", typeof(Texture2D)) as Texture2D;
        button_mainMenu[0] = Resources.Load("Menu/button_mainmenu00", typeof(Texture2D)) as Texture2D;
        button_mainMenu[1] = Resources.Load("Menu/button_mainmenu01", typeof(Texture2D)) as Texture2D;

    }

    // Update is called once per frame
    void Update() {

        //======= Navigate the menus via left control stick =======//
        if (input.leftStick(1, "Y") < -0.2 || input.leftStick(2, "Y") < -0.2 || input.leftStick(3, "Y") < -0.2 || input.leftStick(4, "Y") < -0.2) {
            if (canNavigate) {
                menuState += 1;
                if (menuState > menuSize)
                    menuState = 0;
                canNavigate = false;
            }
        } else if (input.leftStick(1, "Y") > 0.2 || input.leftStick(2, "Y") > 0.2 || input.leftStick(3, "Y") > 0.2 || input.leftStick(4, "Y") > 0.2) {
            if (canNavigate) {
                menuState -= 1;
                if (menuState < 0)
                    menuState = menuSize;
                canNavigate = false;
            }
        } else {
            canNavigate = true;
        }

        //======= Upon hitting "A", check the menu state and continue ======//
        if (input.buttonDown(1, "A") || input.buttonDown(2, "A") ||
            input.buttonDown(3, "A") || input.buttonDown(4, "A")) {

            switch (menuState) {
                case 0:
                    gotoVersus();
                    break;
                case 1:
                    gotoMainMenu();
                    break;
            }

        }
    }

    void OnGUI() {

        //GUI.DrawTexture(new Rect(20, 20, Screen.width - 40, Screen.height - 40), image_frame);

        GUI.DrawTexture(new Rect(Screen.width - 200, Screen.height - 200, 180, 80), button_rematch[(menuState == 0 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(Screen.width - 200, Screen.height - 100, 180, 80), button_mainMenu[(menuState == 1 ? 1 : 0)]);
    }

    void gotoVersus() {
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        ProjectileMaker.BoFP1 = 0;
        ProjectileMaker.BoFP2 = 0;
        ProjectileMaker.HoardP1 = 0;
        ProjectileMaker.HoardP2 = 0;
        Parry.BoSP1 = 0;
        Parry.BoSP2 = 0;
        SceneManager.LoadScene(2);
    }

    void gotoMainMenu() {
        ProjectileMaker.BoFP1 = 0;
        ProjectileMaker.BoFP2 = 0;
        ProjectileMaker.HoardP1 = 0;
        ProjectileMaker.HoardP2 = 0;
        Parry.BoSP1 = 0;
        Parry.BoSP2 = 0;
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        SceneManager.LoadScene(1);
    }
}
