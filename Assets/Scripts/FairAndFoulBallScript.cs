using UnityEngine;
using System.Collections;

public class FairAndFoulBallScript : MonoBehaviour {

    public GameObject thisObject;
    private static string fair;

    public static string Fair
    {
        get
        {
            return fair;
        }
        set
        {
            fair = value;
        }


    }



	// Use this for initialization
	void Start () 
    {
        Debug.Log("I'm attached to this gameObject:" + this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision collision)
    {
        if (thisObject.gameObject.tag == "FoulBall")
            Fair = "Foul";
        else if (thisObject.gameObject.tag == "FairBall") 
            Fair = "Fair";
        //Debug.Log(Fair);
        //Destroy(collision.gameObject);
        


    }

    
}
