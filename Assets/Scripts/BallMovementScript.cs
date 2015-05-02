using UnityEngine;
using System.Collections;

public class BallMovementScript : MonoBehaviour {
	
	public Rigidbody ballPrefab;
	private Rigidbody ballClone;
	public int pitchSpeed = 1600;
	private GameObject other;
	private bool started = false;
	public int test;

	
	
	
	// Use this for initialization
	void Start () 
	{
        Debug.Log("I'm attached to this gameObject:" + this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (started == false && Input.GetKeyDown(KeyCode.S)) 
		{
			StartCoroutine ("Pitch");
			started = true;
		}
	}
	
	
	
	
	IEnumerator Pitch()
	{
		while (true)
		{
			ballClone = Instantiate (ballPrefab) as Rigidbody;
			ballClone.AddForce (transform.forward * -pitchSpeed);
			yield return new WaitForSeconds(Random.Range (3.5f,4.2f));
			Destroy(ballClone.gameObject);
			
		}
	}
	
}