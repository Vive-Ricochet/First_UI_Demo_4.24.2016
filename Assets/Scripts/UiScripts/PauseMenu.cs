using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    // public fields
    public bool isPaused = false;

    // private fields
    private InputManager input;
    private bool canNavigate = false;
    private int menuSize = 2;
    [SerializeField] private int menuState = 0;

    // texture buttons for menu
    public Texture2D shade;
    public Texture2D image_frame;

    public Texture2D[] button_resume = new Texture2D[3];
    public Texture2D[] button_restart = new Texture2D[3];
    public Texture2D[] button_mainmenu = new Texture2D[3];

    private bool currentlypaused = false;
    private float TimeSpeed;

    void Start(){

        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // Pre-load textures and assign to buttons
        shade = Resources.Load("Menu/black_screen", typeof(Texture2D)) as Texture2D;
        image_frame = Resources.Load("Menu/menu_frame_orange", typeof(Texture2D)) as Texture2D;

        button_resume[0] = Resources.Load("Menu/button_resume00", typeof(Texture2D)) as Texture2D;
        button_resume[1] = Resources.Load("Menu/button_resume01", typeof(Texture2D)) as Texture2D;
        button_restart[0] = Resources.Load("Menu/button_restart00", typeof(Texture2D)) as Texture2D;
        button_restart[1] = Resources.Load("Menu/button_restart01", typeof(Texture2D)) as Texture2D;
        button_mainmenu[0] = Resources.Load("Menu/button_mainmenu00", typeof(Texture2D)) as Texture2D;
        button_mainmenu[1] = Resources.Load("Menu/button_mainmenu01", typeof(Texture2D)) as Texture2D;
    }

    // Update is called once per frame
    void Update(){

        if (isPaused) {
            if(currentlypaused == false) {
                TimeSpeed = Time.timeScale;
            }
            Time.timeScale = 0f;

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

            //========================================================//

            //======= Upon hitting "A", check the menu state and continue ======//
            if (input.buttonDown(1, "A") || input.buttonDown(2, "A") ||
                input.buttonDown(3, "A") || input.buttonDown(4, "A")) {

                switch(menuState) {
                    case 0 :
                        Time.timeScale = TimeSpeed;
                        currentlypaused = false;
                        TogglePause();
                        break;
                    case 1 :
                        RestartMatch();
                        break;
                    case 2 :
                        gotoMainMenu();
                        break;
                }

            }

            //===============================================================//

            //====== Upon hitting "B", exit pause menu ============//
            if (input.buttonDown(1, "B") || input.buttonDown(2, "A") ||
                input.buttonDown(3, "B") || input.buttonDown(4, "B")) {

                Time.timeScale = TimeSpeed;
                currentlypaused = false;
                TogglePause();
            }


        } 
        

        if (input.buttonDown(1, "Start") || input.buttonDown(2, "Start") ||
            input.buttonDown(3, "Start") || input.buttonDown(4, "Start")) {

            TogglePause();
            menuState = 0;
        }


    }

    public void Resume(){
    }

    public void PauseGame() {
    }

    public void TogglePause() {
        isPaused = !isPaused;
    }

    public void OnGUI() {
        if (isPaused) {
            GUI.depth = 10;
            GUI.color = new Vector4(0,0,0,0.75f);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), shade);
            GUI.DrawTexture(new Rect(20, 20, Screen.width - 40, Screen.height - 40), image_frame);

            GUI.color = Color.white;

            GUI.DrawTexture(new Rect(80, 80, 190, 90), button_resume[(menuState == 0 ? 1 : 0)]);
            GUI.DrawTexture(new Rect(100, 220, 180, 80), button_restart[(menuState == 1 ? 1 : 0)]);
            GUI.DrawTexture(new Rect(100, 320, 180, 80), button_mainmenu[(menuState == 2 ? 1 : 0)]);
        }
    }

    public void RestartMatch(){
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        Added_Results_Manager.TotalParry = Parry.BoSP1 + Parry.BoSP2;
        Added_Results_Manager.TotalThrows = ProjectileMaker.BoFP1 + ProjectileMaker.BoFP2;
        Added_Results_Manager.TotalPickup = ProjectileMaker.HoardP1 + ProjectileMaker.HoardP2;
        ProjectileMaker.BoFP1 = 0;
        ProjectileMaker.BoFP2 = 0;
        ProjectileMaker.HoardP1 = 0;
        ProjectileMaker.HoardP2 = 0;
        Parry.BoSP1 = 0;
        Parry.BoSP2 = 0;
        PlayerMovement.player1_travel = 0;
        PlayerMovement.player2_travel = 0;
        CowardScript.coward_player1 = 0;
        CowardScript.coward_player2 = 0;
        SceneManager.LoadScene(2);
    }

    public void gotoMainMenu(){
        Added_Results_Manager.TotalParry = Parry.BoSP1 + Parry.BoSP2;
        Added_Results_Manager.TotalThrows = ProjectileMaker.BoFP1 + ProjectileMaker.BoFP2;
        Added_Results_Manager.TotalPickup = ProjectileMaker.HoardP1 + ProjectileMaker.HoardP2;
        ProjectileMaker.BoFP1 = 0;
        ProjectileMaker.BoFP2 = 0;
        ProjectileMaker.HoardP1 = 0;
        ProjectileMaker.HoardP2 = 0;
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        PlayerMovement.player1_travel = 0;
        PlayerMovement.player2_travel = 0;
        CowardScript.coward_player1 = 0;
        CowardScript.coward_player2 = 0;
        SceneManager.LoadScene(1);
    }
}
