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
    public Text TooFastOrTooSlow;

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
	void Start () {
	
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
        OverallStats.text = ("Swings Remaining: " + swingCountRemaining + "\nTotal Swings Taken: " + numberOfSwingsTaken + "\nNumber of Hits: " + NumberOfFairHits + "\nNumber of Foul Balls: " + numberOfFoulHits + "\nHits per Swing Batting Avg: " + hitsPerSwingBattingAvg.ToString("F3"));

	}
}
