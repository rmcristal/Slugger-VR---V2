﻿using UnityEngine;
using System.Collections;

public class BallPrefabHolderScript : MonoBehaviour {

    public GameObject bat;

    bool hasBeenHit = false;
    bool firstBatHit = false;

	// Use this for initialization
	void Start () {

        
     
	}
	
	// Update is called once per frame
	void Update () 
	{
	

	}



	void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Bat" && firstBatHit == false)
        {
            firstBatHit = true;
            hasBeenHit = true;
            UIScript.NumberOfHits++;
            Debug.Log(UIScript.NumberOfHits);
            StartCoroutine("DestroyBallScript");
            
        }

	}



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NewFair" && hasBeenHit == true)
        {
            
                UIScript.NumberOfFairHits++;
                Destroy(gameObject.GetComponent<Collider>());
                //Debug.Log("I've entered a trigger with the \"new Fair\" tag");
            
        }
        
        if(other.gameObject.tag == "FoulBall")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBallScript()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
