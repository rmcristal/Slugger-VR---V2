using UnityEngine;
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
    private string perfectPitch = "Perfect"; //Can choose from "Perfect", "No", or "Curve Ball"
    public int regularPitchSpeed = 1440;
    private float amountOfCurve = 15f;
    private Vector3 regularPitchVector3 = new Vector3(0f, 0f, 1f);
    public GameObject Box1;
    public GameObject Box2;
    private float magnitude;
    
    



    public GameObject m_PitcherPlayer = null;

    bool bEnd = true;

    // Use this for initialization
    void Start()
    {
        magnitude = (Box1.transform.position - Box2.transform.position).magnitude;
        Debug.Log(magnitude);
        m_PitcherPlayer.GetComponent<Animation>()["idle"].wrapMode = WrapMode.Loop;
        m_PitcherPlayer.GetComponent<Animation>().Play("idle");
        animationWaitTime = m_PitcherPlayer.GetComponent<Animation>()["shoot"].length;
        Debug.Log(animationWaitTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        randomWait = Random.Range(1f, 1.5f);
        if (started == false && Input.GetKeyDown(KeyCode.S))
        {
            if (bEnd)
            {
                bEnd = false;
                StartCoroutine("PlayAni", "shoot");
                
            }
            //StartCoroutine("Pitch");
            started = true;
        }
    }


    IEnumerator PlayAni(string name)
    {
        while (true)
        {
            m_PitcherPlayer.GetComponent<Animation>().Play(name);
            yield return new WaitForSeconds(1f);
            ballClone = Instantiate(ballPrefab) as Rigidbody;
            pitchRandomizer = Random.Range(1,6);
            if (perfectPitch == "No")
            {
                if (pitchRandomizer == 2)
                {
                    pitchSpeed = 1200;
                }
                else if (pitchRandomizer == 4)
                {
                    pitchSpeed = 1700;
                }
                else pitchSpeed = regularPitchSpeed;
            }
            else if (perfectPitch == "Curve Ball")
            {
                regularPitchVector3 = new Vector3(.2f, .2f, 1f);
                pitchSpeed = regularPitchSpeed - 26;
                StartCoroutine("CurveBallMovement");
            }

            else pitchSpeed = regularPitchSpeed;
            ballClone.AddForce(regularPitchVector3 * -pitchSpeed);
            yield return new WaitForSeconds(m_PitcherPlayer.GetComponent<Animation>()[name].length);
            m_PitcherPlayer.GetComponent<Animation>().Play("idle");
            yield return new WaitForSeconds(randomWait);
            bEnd = true;
            //Destroy(ballClone.gameObject);
        }
    }



    IEnumerator CurveBallMovement()
    {
		

		while(true)
        {

			
            ballClone.AddForce((-amountOfCurve)*(transform.forward));
            ballClone.AddForce((-amountOfCurve) * (transform.up));
            yield return null;
        }


    }
}
