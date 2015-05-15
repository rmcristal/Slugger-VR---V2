﻿using UnityEngine;
using System.Collections;

public class NewPitchersScript : MonoBehaviour {

    public Rigidbody ballPrefab;
    private Rigidbody ballClone;
    private int pitchSpeed = 1450;
    private GameObject other;
    private bool started = false;
    private float randomWait;
    private float animationWaitTime;
    private int pitchRandomizer;
    private static string pitchMode = "Curve Ball"; //Can choose from "Perfect", "Balls & Strikes", or "Curve Ball"
    public int regularPitchSpeed = 1440;
    public Vector3 regularPitchVector3 = new Vector3(0f, 0f, 1f);
    private static int hitsInARow = 0;
    public static int numberOfHitsInARowToCompleteLevel = 10;


    public static string PitchMode
    {
        get
        {
            return pitchMode;
        }
        set
        {
            pitchMode = value;
        }
    }

    
    public static int HitsInARow
    {
        get
        {
            return hitsInARow;
        }
        set
        {
            hitsInARow = value;
        }
    }

    


    public GameObject m_PitcherPlayer = null;

    bool bEnd = true;

    // Use this for initialization
    void Start()
    {
        m_PitcherPlayer.GetComponent<Animation>()["idle"].wrapMode = WrapMode.Loop;
        m_PitcherPlayer.GetComponent<Animation>().Play("idle");
        animationWaitTime = m_PitcherPlayer.GetComponent<Animation>()["shoot"].length;
        Debug.Log(animationWaitTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            PitchMode = "Curve Ball";
        else if (Input.GetKeyDown(KeyCode.P))
            PitchMode = "Perfect";
        else if (Input.GetKeyDown(KeyCode.O))
            PitchMode = "Balls & Strikes";
        randomWait = Random.Range(1f, 1.5f);
        if (UIScript.MainCameraPresent == false)
        {
            if (started == false && Input.GetKeyDown(KeyCode.S))// Input.GetButtonDown("Button Y"))
            {
                if (bEnd)
                {
                    bEnd = false;
                    StartCoroutine("PlayAni", "shoot");

                }
                started = true;
            }
        }
        else
        {
            if (started == false && Input.GetKeyDown(KeyCode.S))
            {
                if (bEnd)
                {
                    bEnd = false;
                    StartCoroutine("PlayAni", "shoot");

                }
                started = true;
            }
        }
        if(Input.GetButtonDown("Button X"))
        {

        }
    }

 


    IEnumerator PlayAni(string name)
    {
        while (HitsInARow < numberOfHitsInARowToCompleteLevel)
        {
            
            m_PitcherPlayer.GetComponent<Animation>().Play(name);
            yield return new WaitForSeconds(1f);
            ballClone = Instantiate(ballPrefab) as Rigidbody;
            pitchRandomizer = Random.Range(1,6);
            if (PitchMode == "Balls & Strikes")
            {
                regularPitchVector3 = new Vector3(0f, -.15f, 1f);
                if (pitchRandomizer == 2)
                {
                    pitchSpeed = Random.Range(880,920);
                }
                else if (pitchRandomizer == 4)
                {
                    pitchSpeed = Random.Range(1100,1200);
                }
                else pitchSpeed = regularPitchSpeed;
            }
            else if (PitchMode == "Curve Ball")
            {
                regularPitchVector3 = new Vector3(.14f, -.28f, 1f);
                pitchSpeed = regularPitchSpeed - 0;
                ballClone.GetComponent<CurveBall>().pitcher = transform;
                ballClone.GetComponent<CurveBall>().enabled = true;
            }

            else
            {
                regularPitchVector3 = new Vector3(0f, -.15f, 1f);
                pitchSpeed = regularPitchSpeed;
            }  
            ballClone.AddForce(regularPitchVector3 * -pitchSpeed);
            yield return new WaitForSeconds(m_PitcherPlayer.GetComponent<Animation>()[name].length);
            m_PitcherPlayer.GetComponent<Animation>().Play("idle");
            yield return new WaitForSeconds(randomWait);
            bEnd = true;
            //Destroy(ballClone.gameObject);
        }
    }


}
