using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    private static int numberOfHits;
    private static int numberOfFairHits;
    private int numberOfFoulHits;
    private int totalStartingSwings = 20;
    public static int numberOfSwingsTaken;
    public static int swingCountRemaining;
    private float hitsPerSwingBattingAvg;
    public Text OverallStats;
    private static bool mainCameraPresent;
    public GameObject mainCamera;
    private bool hasPlayerPressedY = false;

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
            numberOfFairHits = value;
        }
    }

 
    // Use this for initialization
	void Start () 
    {
        
        if (mainCamera.gameObject.activeSelf == false)
            MainCameraPresent = false;
        else
            MainCameraPresent = true;
	}
	



	// Update is called once per frame
	void Update () 
    {
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
            if (hasPlayerPressedY == false)
            {
                OverallStats.text = ("Press Y to start\nPress A to swing");
                if (Input.GetButtonDown("Button Y"))
                    hasPlayerPressedY = true;
            }
            else
            {
                OverallStats.text = ("Swings Remaining: " + swingCountRemaining + "\nTotal Swings Taken: " + numberOfSwingsTaken + "\nNumber of Hits: " + NumberOfFairHits + "\nNumber of Foul Balls: " + numberOfFoulHits + "\nHits per Swing Batting Avg: " + hitsPerSwingBattingAvg.ToString("F3"));
            }
        }
        else
        {
            if (hasPlayerPressedY == false)
            {
                OverallStats.text = ("Press S to start\nPress B to swing");
                if (Input.GetKeyDown(KeyCode.S))
                    hasPlayerPressedY = true;
            }
            else
            {
                OverallStats.text = ("Swings Remaining: " + swingCountRemaining + "\nTotal Swings Taken: " + numberOfSwingsTaken + "\nNumber of Hits: " + NumberOfFairHits + "\nNumber of Foul Balls: " + numberOfFoulHits + "\nHits per Swing Batting Avg: " + hitsPerSwingBattingAvg.ToString("F3"));
            }
        }
        

	}
}
