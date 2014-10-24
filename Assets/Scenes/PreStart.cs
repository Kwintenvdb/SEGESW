using UnityEngine;
using System.Collections;



public class PreStart : MonoBehaviour {
	private GameObject Screen01;
	private GameObject Screen02;

	// Use this for initialization
	void Start () {
		//gameobject.GetComponent<FadeMaterials>().FadeOut();
		Screen01 = GameObject.Find("Screen01");
		Screen02 = GameObject.Find("Screen02");
		Screen01.GetComponent<Fader>().setAlpha(0);
		Screen02.GetComponent<Fader>().setAlpha(0);
		StartCoroutine(Wait(2));

	}
	
	// Update is called once per frame
	void Update () {
		//PreStartRoutine();
		//PreStartRoutine2();
		//Screen01.GetComponent<Fader>().FadeIn();

	}

	public void PreStartRoutine2(){
		//Mine.GetComponent<MeshRenderer>.enabled = false; 
		//Screen01.GetComponent<MeshRenderer>().enabled =true;
		//Screen02.GetComponent<MeshRenderer>().enabled =false;

		//StartCoroutine(Wait(2000));
		//Screen01.GetComponent<MeshRenderer>().enabled =false;
		//Screen02.GetComponent<MeshRenderer>().enabled =true;

		StartCoroutine(Wait(2000F));
		Application.LoadLevel(1);
		
	}
	public void PreStartRoutine(){
		Screen01.GetComponent<Fader>().FadeIn();
		StartCoroutine(Wait(4000F));
		Screen02.GetComponent<Fader>().FadeOut();
		StartCoroutine(Wait(3000F));
		Screen02.GetComponent<Fader>().FadeIn();
		StartCoroutine(Wait(4000F));
		Application.LoadLevel(1);

	}
	IEnumerator Wait(float seconds) 
	{
		Screen01.GetComponent<Fader>().FadeIn();
		//Screen01.GetComponent<MeshRenderer>().enabled =true;
		//Screen02.GetComponent<MeshRenderer>().enabled =false;
		yield return new WaitForSeconds (seconds+2);
		Screen01.GetComponent<Fader>().FadeOut();
		//Screen02.GetComponent<MeshRenderer>().enabled =false;
		yield return new WaitForSeconds (seconds-1);
		Screen02.GetComponent<Fader>().FadeIn();
		//Screen01.GetComponent<MeshRenderer>().enabled =false;
		//Screen02.GetComponent<MeshRenderer>().enabled =true;
		yield return new WaitForSeconds (seconds+2);
		Screen02.GetComponent<Fader>().FadeOut();
		yield return new WaitForSeconds (seconds-1);
		Application.LoadLevel(1);

	}
}
