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
    private static bool mainCameraPresent;
    public GameObject mainCamera;
    private bool hasPlayerPressedY = false;
    private bool mainMenuEnabled = false;
    public GameObject mainMenuCanvasHolder;
    public Canvas mainMenuCanvasHolder2;
    public Canvas winningTextUI;
    private string levelInstructions;
    private string controllerInstructions;





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

    public void perfectPitch()
    {
        NewPitchersScript.PitchMode = "Perfect";
    }

    public void BallsAndStrikes()
     {
         NewPitchersScript.PitchMode = "Balls & Strikes";
     }

    public void CurveBalls()
    {
        NewPitchersScript.PitchMode = "Curve Ball";
    }



    // Use this for initialization
	void Start () 
    {
        mainMenuCanvasHolder2 = mainMenuCanvasHolder2.GetComponent<Canvas>();
        mainMenuCanvasHolder2.enabled = false;
        winningTextUI.enabled = false;
        if (mainCamera.gameObject.activeSelf == false)
            MainCameraPresent = false;
        else
            MainCameraPresent = true;
	}
	




	// Update is called once per frame
	void Update () 
    {
        if (NewPitchersScript.HitsInARow == NewPitchersScript.numberOfHitsInARowToCompleteLevel)
        {
            winningTextUI.enabled = true;
            //StartCoroutine("LoadNextLevel");
        }
        swingCountRemaining = totalStartingSwings - numberOfSwingsTaken;
        numberOfFoulHits = NumberOfHits - NumberOfFairHits;
        if (numberOfSwingsTaken != 0)
        {   
            hitsPerSwingBattingAvg = (((float)NumberOfFairHits / (float)numberOfSwingsTaken) * 1000f)/1000f;
        }

        
        else
            hitsPerSwingBattingAvg = 0;
        if (UIScript.MainCameraPresent == false)
        {
            if (Input.GetButtonDown("Select"))
            {
                mainMenuCanvasHolder2.enabled = !mainMenuCanvasHolder2.enabled;
            }
            if (hasPlayerPressedY == false)
            {
                OverallStats.text = IntroScoreBoardText();
                if (Input.GetButtonDown("Button Y"))
                    hasPlayerPressedY = true;
            }
            else
            {
                OverallStats.text = ScoreBoardText();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.M))
                mainMenuCanvasHolder2.enabled = !mainMenuCanvasHolder2.enabled;
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



    public string ScoreBoardText()
    {
        //"Swings Remaining: " + swingCountRemaining + 
        return (
        "\nTotal Swings Taken: " + numberOfSwingsTaken + 
        "\nNumber of Hits: " + NumberOfFairHits + 
        "\nNumber of Foul Balls: " + numberOfFoulHits + 
        "\nHits per Swing Batting Avg: " + hitsPerSwingBattingAvg.ToString("F3") + 
        "\nNumber of Hits in a Row: " + NewPitchersScript.HitsInARow);
    }

    public string IntroScoreBoardText()
    {
        levelInstructions = "Level 1: Get 5 hits in a Row";
        if (UIScript.MainCameraPresent == false)
            controllerInstructions = "\nPress Y to start\nPress A to swing";
        else
            controllerInstructions = "\nPress S to start\nPress B to swing";
        return (levelInstructions + controllerInstructions);
    }
    //IEnumerator LoadNextLevel()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Application.LoadLevel(1);
    //}
}
