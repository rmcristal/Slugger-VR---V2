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
    private bool mainMenuEnabled = false;
    public GameObject mainMenuCanvasHolder;
    public Canvas mainMenuCanvasHolder2;




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
        //mainMenuCanvasHolder = mainMenuCanvasHolder.GetComponentInChildren<GameObject>();
        //mainMenuCanvasHolder.GetComponentInChildren<GameObject>().SetActive(false);
        mainMenuCanvasHolder2 = mainMenuCanvasHolder2.GetComponent<Canvas>();
        mainMenuCanvasHolder2.enabled = false;
        //mainMenuCanvasHolder.GetComponentInChildren<Canvas>().enabled = false;
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
            if (mainMenuEnabled == false && Input.GetButtonDown("Select"))
            {
                mainMenuEnabled = true;
                mainMenuCanvasHolder2.enabled = true;
                //mainMenuCanvasHolder.SetActive(true);
            }
            if (mainMenuEnabled == true && Input.GetButtonDown("Select"))
            {
                mainMenuEnabled = false;
                mainMenuCanvasHolder2.enabled = false;
                //mainMenuCanvasHolder.SetActive(false);
            }

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
            if (mainMenuCanvasHolder2.enabled == false && Input.GetKey(KeyCode.M))
            {
                mainMenuEnabled = true;
                mainMenuCanvasHolder2.enabled = true;
                //mainMenuCanvasHolder.SetActive(true);
            }
            if (mainMenuCanvasHolder2.enabled == true && Input.GetKey(KeyCode.M))
            {
                mainMenuEnabled = false;
                mainMenuCanvasHolder2.enabled = false;
                //mainMenuCanvasHolder.SetActive(false);
            }
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
