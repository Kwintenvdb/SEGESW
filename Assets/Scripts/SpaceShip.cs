using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShip : MonoBehaviour {

	// Public
	public int	EngineForce	= 800,
				RotSpeed	= 350,
				MaxVel		= 25;
	public	int Health = 100;
	
	public	GameObject	Explosion	= null;
	public 	GameObject	Smoke		= null;
	public 	GameObject	Shield		= null;
	
	public AudioSource Sound = null;
	
	// ----------

	void FixedUpdate () {
		if(Input.GetButton("Vertical")) { 
			if(Input.GetAxis("Vertical") > 0) {
				GetComponent<Rigidbody>().AddForce(transform.forward * (EngineForce * Time.deltaTime));
				
				if(GetComponent<Rigidbody>().velocity.magnitude > MaxVel)
					GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * MaxVel;
			}
			else GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.9f;
			
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			
			// sound
			
			if(!Sound.isPlaying) Sound.Play();
		}
		else Sound.Stop();
           
		if(Input.GetButton("Horizontal")) {
			GetComponent<Rigidbody>().transform.eulerAngles += new Vector3(0,(RotSpeed * Time.deltaTime) * Input.GetAxis("Horizontal"),0);
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		
		Vector3 posFixed = GetComponent<Rigidbody>().transform.position;
		posFixed.y = 0f;
		
		GetComponent<Rigidbody>().transform.position = posFixed;
		
		Smoke.transform.position = transform.position;
		
		if(Health <= 0) {
			Instantiate(Explosion, transform.position, Quaternion.identity);
			Application.LoadLevel("Player1");
			Destroy(gameObject);
		}
	}
	
	
}
