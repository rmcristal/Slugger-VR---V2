using UnityEngine;
using System.Collections;

public class BallPrefabHolderScript : MonoBehaviour {

    //public GameObject bat;

    bool hasBeenHit = false;
    bool firstBatHit = false;
    private bool strike = false;
    private bool ball = false;
    public ParticleSystem fireWorksPrefab;
    private ParticleSystem clone;
    private ParticleSystem clone2;

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
        if(collision.gameObject.tag == "Ground" && firstBatHit == false)
        {
            Destroy(GetComponent<Collider>());
        }

	}



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NewFair" && hasBeenHit == true)
        {
            
            UIScript.NumberOfFairHits++;
			hasBeenHit = false;
            //Destroy(gameObject.GetComponent<Collider>());
            //Debug.Log("I've entered a trigger with the \"new Fair\" tag");   
        }
        
        if(other.gameObject.tag == "FoulBall")
        {
            StartCoroutine("DestroyFoulBallScript");
        }
        if (other.gameObject.tag == "Strike")
        {
            strike = true;
            Debug.Log("Strike");
        }
        if (other.gameObject.tag == "CrossedThePlate" && strike == false)
        {
            ball = true;
            Debug.Log("Ball");
        }
        if(other.gameObject.tag == "Homerun")
        {
            clone = Instantiate(fireWorksPrefab, new Vector3(14.5f, 4.3f, 18.5f), Quaternion.Euler(-90f,0f,0f)) as ParticleSystem;
            clone2 = Instantiate(fireWorksPrefab, new Vector3(-14.18f, 4.3f, 18.5f), Quaternion.Euler(-90f, 0f, 0f)) as ParticleSystem;
            Debug.Log("Fireworks should be generated");

        }
    }

    IEnumerator DestroyBallScript()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }

    IEnumerator DestroyFoulBallScript()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
