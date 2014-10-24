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
				rigidbody.AddForce(transform.forward * (EngineForce * Time.deltaTime));
				
				if(rigidbody.velocity.magnitude > MaxVel)
					rigidbody.velocity = rigidbody.velocity.normalized * MaxVel;
			}
			else rigidbody.velocity = rigidbody.velocity * 0.9f;
			
			rigidbody.angularVelocity = Vector3.zero;
			
			// sound
			
			if(!Sound.isPlaying) Sound.Play();
		}
		else Sound.Stop();
           
		if(Input.GetButton("Horizontal")) {
			rigidbody.transform.eulerAngles += new Vector3(0,(RotSpeed * Time.deltaTime) * Input.GetAxis("Horizontal"),0);
			rigidbody.angularVelocity = Vector3.zero;
		}
		
		Vector3 posFixed = rigidbody.transform.position;
		posFixed.y = 0f;
		
		rigidbody.transform.position = posFixed;
		
		Smoke.transform.position = transform.position;
		
		if(Health <= 0) {
			Instantiate(Explosion, transform.position, Quaternion.identity);
			Application.LoadLevel("Player1");
			Destroy(gameObject);
		}
	}
	
	
}
