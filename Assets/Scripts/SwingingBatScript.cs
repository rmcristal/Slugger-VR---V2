using UnityEngine;
using System.Collections;

public class SwingingBatScript : MonoBehaviour {
	
	private Animator batAnimator;
	public GameObject bat;
	public AudioClip hit;
    //private static int numberOfHits; 
    //private static int numberOfFairHits;
    //private int numberOfFoulHits = NumberOfHits - NumberOfFairHits;
    
    //public static int NumberOfHits
    //{
    //    get
    //    {
    //        return numberOfHits;
    //    }
    //    set 
    //    {
    //        numberOfHits = value;
    //    }
    //}


    //public static int NumberOfFairHits
    //{
    //    get
    //    {
    //        return numberOfFairHits;
    //    }
    //    set
    //    {
    //        numberOfFairHits = value;
    //    }
    //}


	
	
	// Use this for initialization
	void Start () 
	{
		batAnimator = GetComponent<Animator> ();
		//hit = GetComponent<AudioClip> ();
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.B))
		{
			batAnimator.SetInteger ("Swing", 1);
		}
		else batAnimator.SetInteger ("Swing", 0); 
	}
	
	void OnCollisionEnter(Collision collision)
	{
		AudioSource.PlayClipAtPoint (hit,new Vector3(0f,1f,-14f));
	}
}
