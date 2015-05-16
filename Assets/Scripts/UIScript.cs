using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    private static int numberOfHits;
    private static int numberOfFairHits;
    public static int numberOfFoulHits;
    private int totalStartingSwings = 20;
    public static int numberOfSwingsTaken;
    public static int swingCountRemaining;
    private float hitsPerSwingBattingAvg;
    public Text OverallStats;
    public Text EndOfGameText;
    private static bool mainCameraPresent;
    public GameObject mainCamera;
    private bool hasPlayerPressedY = false;
    public static bool mainMenuEnabled = false;
    public Canvas mainMenuCanvasHolder;
    public Canvas endOfGameTextUI;
    private string levelInstructions;
    private string controllerInstructions;
    public static string gameMode; //Options: "Get 7 Hits in a Row", "Achieve .600 Batting Avg. Over 10 Swings", "Longest Hit Streak" 
    public Canvas gameModeMenuCanvas;
    public static bool gameModeMenuEnabled;
    private int longestHitStreak;
    public GameObject OVRCameraRig;
    







    public static bool MainCameraPresent
    {
        get
        {
            return mainCameraPresent;
        }
        set
        {
            mainCameraPresent = value;
        }
    }
    
    
    public static int NumberOfHits
    {
        get
        {
            return numberOfHits;
        }
        set
        {
            numberOfHits = value;
        }
    }


    public static int NumberOfFairHits
    {
        get
        {
            return numberOfFairHits;
        }
        set
        {
            {
                numberOfFairHits = value;
                NewPitchersScript.HitsInARow++;
            }
        }
    }



    public void PerfectPitch()
    {
        NewPitchersScript.PitchMode = "Perfect";
        mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
        mainMenuEnabled = false;
    }

    public void BallsAndStrikes()
     {
         NewPitchersScript.PitchMode = "Balls & Strikes";
         mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
         mainMenuEnabled = false;
     }

    public void CurveBalls()
    {
        NewPitchersScript.PitchMode = "Curve Ball";
        mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
        mainMenuEnabled = false;
    }




    // Use this for initialization
	void Start () 
    {
        mainMenuCanvasHolder = mainMenuCanvasHolder.GetComponent<Canvas>();
        mainMenuCanvasHolder.enabled = false;
        mainMenuEnabled = false;
        gameModeMenuCanvas.enabled = false;
        gameModeMenuEnabled = false;
        endOfGameTextUI.enabled = false;
        if (mainCamera.gameObject.activeSelf == false)
            MainCameraPresent = false;
        else
            MainCameraPresent = true;
	}
	




	// Update is called once per frame
	void Update () 
    {
        if (NewPitchersScript.pitchBoolLogic == false)
        {
            EndOfGameText.text = EndOfGameTextLogic();
            endOfGameTextUI.enabled = true;
            //StartCoroutine("LoadNextLevel");
        }
        if (endOfGameTextUI.enabled == true && Input.GetButtonDown("Button X"))
        {
            OVRCameraRig.transform.rotation = Quaternion.Euler(OVRCameraRig.transform.rotation.x, (OVRCameraRig.transform.rotation.y - 90f), OVRCameraRig.transform.rotation.z);
            Application.LoadLevel(Application.loadedLevel);
        }
        swingCountRemaining = totalStartingSwings - numberOfSwingsTaken;
        numberOfFoulHits = NumberOfHits - NumberOfFairHits;
        if (numberOfSwingsTaken != 0)
        {   
            hitsPerSwingBattingAvg = (((float)NumberOfFairHits / (float)numberOfSwingsTaken) * 1000f)/1000f;
        }





        else
            hitsPerSwingBattingAvg = 0;
        if (true) //(MainCameraPresent == false)
        {
            if (Input.GetButtonDown("Select")) // Input.GetButtonDown("Select")) // Input.GetKeyDown(KeyCode.M)) 
            {
                mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
                mainMenuEnabled = !mainMenuEnabled;
            }
            if (mainMenuCanvasHolder.enabled == true)
            {
                mainMenuEnabled = true;
                if (Input.GetButtonDown("Button X")) // Input.GetButtonDown("Button X"))
                    PerfectPitch();
                else if (Input.GetButtonDown("Button A"))
                    BallsAndStrikes();
                else if (Input.GetButtonDown("Button B"))
                    CurveBalls();
            }
            else
                mainMenuEnabled = false;

            if (Input.GetButtonDown("Start"))
            {
                gameModeMenuCanvas.enabled = !gameModeMenuCanvas.enabled;
                gameModeMenuEnabled = !gameModeMenuEnabled;

            }
            if (gameModeMenuCanvas.enabled == true)
            {
                //Debug.Log("mainMenuCanvasHolder is enabled");
                gameModeMenuEnabled = true;
                if (Input.GetButtonDown("Button X")) // Input.GetButtonDown("Button X"))
                {
                    gameMode = "Get 7 Hits in a Row";
                    gameModeMenuCanvas.enabled = !gameModeMenuCanvas.enabled;
                    gameModeMenuEnabled = false;
                    EnableMainMenu();
                }
                else if (Input.GetButtonDown("Button A"))
                {
                    gameMode = "Achieve .600 Batting Avg. Over 10 Swings";
                    gameModeMenuCanvas.enabled = !gameModeMenuCanvas.enabled;
                    gameModeMenuEnabled = false;
                    EnableMainMenu();
                }
                else if (Input.GetButtonDown("Button B"))
                {
                    gameMode = "Longest Hit Streak";
                    gameModeMenuCanvas.enabled = !gameModeMenuCanvas.enabled;
                    gameModeMenuEnabled = false;
                    EnableMainMenu();
                }
            }
            else
                gameModeMenuEnabled = false;


            if (hasPlayerPressedY == false)
            {
                OverallStats.text = IntroScoreBoardText();
                if (Input.GetButtonDown("Button Y"))
                    hasPlayerPressedY = true;
            }
            else
            {
                OverallStats.text = ScoreBoardText();
                OverallStats.fontSize = 15;
            }
            if (NewPitchersScript.HitsInARow > longestHitStreak)
                longestHitStreak = NewPitchersScript.HitsInARow;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
                mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
            if (hasPlayerPressedY == false)
            {
                OverallStats.text = IntroScoreBoardText();
                if (Input.GetKeyDown(KeyCode.S))
                    hasPlayerPressedY = true;
            }
            else
            {
                OverallStats.text = ScoreBoardText();
            }
        }

	}


    public void EnableMainMenu()
    {
        mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
        mainMenuEnabled = !mainMenuEnabled;
    }

    public string ScoreBoardText()
    {
        //"Swings Remaining: " + swingCountRemaining + 
        return (
        "\nTotal Swings Taken: " + numberOfSwingsTaken + 
        "\nNumber of Hits: " + NumberOfFairHits + 
        "\nNumber of Foul Balls: " + numberOfFoulHits + 
        "\nHits per Swing Batting Avg: " + hitsPerSwingBattingAvg.ToString("F3") + 
        "\nNumber of Hits in a Row: " + NewPitchersScript.HitsInARow + 
        "\nLongest Hit Streak: " + longestHitStreak);
    }
    public string EndOfGameTextLogic()
    {
        if (gameMode == "Get 7 Hits in a Row")
            return ("5 Hits in a Row!!! \nYou Win!!!");
        if(gameMode == "Achieve .600 Batting Avg. Over 10 Swings" && hitsPerSwingBattingAvg >= 0.6f)
            return ("Batting average: " + hitsPerSwingBattingAvg.ToString("F3") + "\nYou Win!!!");
        else
            return ("Batting average: " + hitsPerSwingBattingAvg.ToString("F3") + "\nNot quite there, try again!");
            //Options: "Get 7 Hits in a Row", "Achieve .600 Batting Avg. Over 10 Swings", "Longest Hit Streak" 
    }





    public string IntroScoreBoardText()
    {
        if (UIScript.MainCameraPresent == false)
        {
            levelInstructions = "- Press Start on your controller to \n  choose Game Mode and Pitch Types";
            controllerInstructions = "\n- Press Y to start\n- Press A to swing";
        }
        else
        {
            levelInstructions = "Press G to select Game Mode and Pitch Types.";
            controllerInstructions = "\nPress S to start\nPress B to swing";
        }
        return (levelInstructions + controllerInstructions);
    }
    //IEnumerator LoadNextLevel()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Application.LoadLevel(1);
    //}
}
