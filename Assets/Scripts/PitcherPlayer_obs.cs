using UnityEngine;
using System.Collections;

public class PitcherPlayer : MonoBehaviour {

	public GameObject m_PitcherPlayer=null;

	bool bEnd=true;

	// Use this for initialization
	void Start () {
		m_PitcherPlayer.GetComponent<Animation>()["idle"].wrapMode=WrapMode.Loop;
		m_PitcherPlayer.GetComponent<Animation>().Play("idle");
	}
	
	// Update is called once per frame
	void Update () {
		if (bEnd) {
			if (Input.GetKeyDown(KeyCode.A)) {
				bEnd=false;
				StartCoroutine("PlayAni","shoot");
			}
		}
	}

	IEnumerator PlayAni(string name) {
		m_PitcherPlayer.GetComponent<Animation>().Play(name);
		yield return new WaitForSeconds(m_PitcherPlayer.GetComponent<Animation>()[name].length);
		m_PitcherPlayer.GetComponent<Animation>().Play("idle");
		bEnd=true;
	}
}
