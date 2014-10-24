using UnityEngine;
using System.Collections;

public class LocatePlayer : MonoBehaviour {
	
	public Transform ThisPlayer;
	public Transform OtherPlayer;
	//private Vector3 TargetPos;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(!ThisPlayer) Destroy(gameObject);
		
		if(OtherPlayer)
		{
		    transform.position = ThisPlayer.position;
		    
		    var v3T = OtherPlayer.position - transform.position;
		    v3T.y = 0;
		    Quaternion qTo = Quaternion.LookRotation(v3T);  
		    	
		    //transform.rotation = qTo;
		    
		    float maxDegreesPerSecond = 90f;
		    transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, maxDegreesPerSecond * Time.deltaTime);
		}
	}
}
