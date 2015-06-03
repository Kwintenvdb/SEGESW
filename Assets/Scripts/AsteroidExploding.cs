using UnityEngine;
using System.Collections;

public class AsteroidExploding : MonoBehaviour {
	
	public int Health = 100;
	public GameObject Explosion = null;
	//public GameObject Smoke = null;
	
	public float		StartForce		= 0,
						RotSpeed		= 0;
	
	public AudioClip sound = null;
	
	// Use this for initialization
	void Start () {
	
		GetComponent<Rigidbody>().AddForce(transform.forward * StartForce);
		GetComponent<Rigidbody>().AddTorque(Vector3.one * RotSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Smoke.transform.position = transform.position;
		
		//if(Input.GetButton("Fire1"))
		if(Health <= 0)
		{
			foreach(Debris debris in GetComponentsInChildren<Debris>())
			{
				debris.HasExploded = true;
			}
			foreach( Transform trans in GetComponentsInChildren<Transform>())
			{
				trans.GetComponent<Rigidbody>().isKinematic = false;
				trans.parent = null;
				foreach(MeshCollider mc in trans.GetComponentsInChildren<MeshCollider>())
				{
					mc.enabled = true;
				}
				
				//Vector3 forceDir = transform.position - trans.position;
				//trans.rigidbody.AddForce(forceDir.normalized * 10);
			}
			
			Instantiate(Explosion,transform.position,transform.rotation); // particles
			
			AudioSource.PlayClipAtPoint(sound, transform.position);
			
			//transform.DetachChildren();
			Destroy(gameObject);
		}
		
	}
	
	void OnCollisionEnter(Collision collObj)
	{
		if(collObj.gameObject.tag == "Bullet" || collObj.gameObject.tag == "Ammo")
		{
			Health -= 25;
			Destroy(collObj.gameObject);
		}
	}
}
