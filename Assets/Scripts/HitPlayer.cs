using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HitPlayer : MonoBehaviour {

	//public GUIText m_HelpText=null;
	public GameObject m_HitPlayer=null;
	bool bEnd=true;
    public AudioClip hit;
    private int swingCountRemaining = 20;
    private int numberOfFairHitsLocal;



	// Use this for initialization
	void Start () {
		//m_HelpText.text=m_HelpText.text.Replace("\\","\n");
		//m_HitPlayer.GetComponent<Animation>()["idle"].wrapMode=WrapMode.Loop;
		//m_HitPlayer.GetComponent<Animation>().Play("idle");
        
	}

	
	// Update is called once per frame
    void Update()
    {
        if (bEnd)
        {
            if (UIScript.MainCameraPresent == false)
            {
                if (Input.GetButtonDown("Button A"))
                {
                    bEnd = false;
                    StartCoroutine("PlayAni", "hit - Trying to Make the Swing Faster");
                    //swingCountRemaining -= 1;
                    UIScript.numberOfSwingsTaken++;
                    //UIText.text = ("Swings Remaining: " + swingCountRemaining + "\nNumber of Hits: " + numberOfFairHitsLocal);
                    return;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    bEnd = false;
                    StartCoroutine("PlayAni", "hit - Trying to Make the Swing Faster");
                    //swingCountRemaining -= 1;
                    UIScript.numberOfSwingsTaken++;
                    //UIText.text = ("Swings Remaining: " + swingCountRemaining + "\nNumber of Hits: " + numberOfFairHitsLocal);
                    return;
                }
            }
            //if (Input.GetKeyDown(KeyCode.F))
            //{
               
            //    //m_HitPlayer.GetComponent<Animation>().Play("NewBunt");
            //    StartCoroutine("PlayAni", "NewBunt");
                
            //}


        }



    }
    //fix
	
	IEnumerator PlayAni(string name) {
		m_HitPlayer.GetComponent<Animation>().Play(name);
		yield return new WaitForSeconds(m_HitPlayer.GetComponent<Animation>()[name].length);
		//m_HitPlayer.GetComponent<Animation>().Play("idle");
		bEnd=true;
	}

   void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hit, new Vector3(0f, 1f, -14f));
        Debug.Log("There was at least a tip");

    }

    
}
