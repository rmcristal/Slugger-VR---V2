using UnityEngine;
using System.Collections;

public class ConnectedBatSound : MonoBehaviour {

    public AudioClip hit;

	// Use this for initialization
	void Start () {

        Debug.Log("I'm attached to this gameObject:" + this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
	

	}

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hit, new Vector3(0f, 1f, -14f));
    }
}
