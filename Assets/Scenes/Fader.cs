using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	private GameObject targetScreen;
	// Use this for initialization
	void Start () {
		targetScreen = GameObject.Find(this.name);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void FadeOut() {
		
		iTween.ValueTo(targetScreen, iTween.Hash(
			"from", 1.0f, "to", 0.0f,
			"time", 1f, "easetype", "linear",
			"onupdate", "setAlpha"));
		               
	}
		               
	public void FadeIn() {
			
		iTween.ValueTo(targetScreen, iTween.Hash(
			"from", 0f, "to", 1f,
			"time", 1f, "easetype", "linear",
			"onupdate", "setAlpha"));
			               
	}
			               
	public void setAlpha(float newAlpha) {
				
		foreach (Material mObj in GetComponent<Renderer>().materials) 
					mObj.color = new Color(
						mObj.color.r, mObj.color.g, 
						mObj.color.b, newAlpha);
					
	}
				
}
