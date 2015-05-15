﻿using UnityEngine;
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
    public static bool mainMenuEnabled = false;
    public Canvas mainMenuCanvasHolder;
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
        if (true) //(MainCameraPresent == false)
        {
            if (Input.GetButtonDown("Select")) // Input.GetButtonDown("Select")) // Input.GetKeyDown(KeyCode.M)) 
            {
                mainMenuCanvasHolder.enabled = !mainMenuCanvasHolder.enabled;
                mainMenuEnabled = !mainMenuEnabled;
            }
            if (mainMenuCanvasHolder.enabled == true)
            {
                //Debug.Log("mainMenuCanvasHolder is enabled");
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
