using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceWave : MonoBehaviour {
	
	public 	GameObject		Shockwave	= null;
	public	AudioClip		Sound		= null;
	
	private float limit = 2.5f;
	private float elapsed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		elapsed += Time.deltaTime;
		
		if(Input.GetButton("Fire3") && elapsed >= limit)
		{
			foreach(Collider col in Physics.OverlapSphere(transform.position,25f)) 
			{
				if(col.GetComponent<Rigidbody>() != null)
				{
					Vector3 forceDir = (col.transform.position - transform.position).normalized;
					float force = 1200f;
					col.rigidbody.AddForce(forceDir * force);
				}
			}
			
			AudioSource.PlayClipAtPoint(Sound,transform.position,0.3f);
			Instantiate(Shockwave,transform.position,Quaternion.AngleAxis(270,Vector3.left));
			
			elapsed = 0f;
		}
	}
}
