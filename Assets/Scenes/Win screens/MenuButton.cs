using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Debug.Log("clicked");
		if(this.name == "BtnStart"){
			Application.LoadLevel(2);
		}
		else if(this.name == "BtnControls"){
			Application.LoadLevel(4);
		}
		else if(this.name == "BtnPlayer1"){
			Application.LoadLevel(3);
		}
		else if(this.name == "BtnPlayer2"){
			Application.LoadLevel(5);
		}
		else if(this.name == "BtnBack"){
			Application.LoadLevel(1);
		}
		else if(this.name == "BtnResume"){
			Application.LoadLevel(1);
		}
		else if(this.name == "BtnQuit"){
			Application.Quit();
		}

	}
}
