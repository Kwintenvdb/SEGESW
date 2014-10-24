using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	private int ScoreNr = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label (new Rect (25, 25, 100, 30), "" + ScoreNr);
	}
	
	public void AddScore(int score) {
	
		ScoreNr += score;
	}
}
