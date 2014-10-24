using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebrisRing : MonoBehaviour {
	
	public bool 			HasBullet 	{ get; set; }
	public AudioClip ShotFire = null;
	
	// Private
	List<Collider>	DebrisList = new List<Collider>();
	private Transform 		Weapon 		= null;
	
	// ----------
	
	void Start() {
		
		Weapon = transform.parent.Find ("Weapon");
	}

	void FixedUpdate () {
		if(DebrisList.Count < 40){
			foreach(Collider collider in Physics.OverlapSphere(transform.position, 10)) {
				if(collider.CompareTag("Debris")) {
					collider.transform.parent = transform;
					Destroy(collider.rigidbody);
					collider.tag = "DebrisInOrbit";
					collider.gameObject.layer = 9;
					collider.GetComponent<Debris>().StopTimer(true);
					collider.GetComponent<Wireframe2>().lineColor = new Color(1f,1f,0f);
			
					DebrisList.Add(collider);

				    StartCoroutine("CalcPositions");
				}
			}
		}
		float rotSpeed = 35f;
		transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
		
		if(Input.GetButton("Fire2")) {
			
			AudioSource.PlayClipAtPoint(ShotFire,transform.position,0.8f);
			ShockWave();
		}
		
		// Give weapon a bullet when there is none
		if(!HasBullet) {
			if(DebrisList.Count > 0) {
				Collider col = DebrisList[0];
				col.transform.position = Weapon.position;
				col.transform.parent = Weapon;
				col.tag = "Ammo";
				col.GetComponent<Wireframe2>().lineColor = new Color(1f,0.5f,0f);
				DebrisList.Remove(col);
			    StartCoroutine("CalcPositions");
				HasBullet = true;
			}
		}
	}
	
	public void ShockWave() {
		
		Vector3 shipVel = transform.parent.rigidbody.velocity;
		foreach(Collider debris in DebrisList)
		{	
			debris.gameObject.AddComponent<Rigidbody>();
			debris.rigidbody.useGravity = false;
			debris.transform.parent = null;
			
			debris.GetComponent<Wireframe2>().lineColor = new Color(255,0,0);			
			debris.GetComponent<Debris>().StopTimer(false);
			
			debris.tag = "Bullet";
				
			Vector3 forceDir = (debris.transform.position - transform.position).normalized;
			forceDir.y = 0;
			float forceStrength = 1750f;
			debris.rigidbody.AddForce(forceDir * forceStrength + shipVel * 40f);			
		}
		DebrisList.Clear();
	}
	
	IEnumerator CalcPositions() 
    {
		float distance = 10f;
		float angle = 360.0f / DebrisList.Count;
		for(int i=0; i < DebrisList.Count; ++i)
			DebrisList[i].transform.position = transform.position + (Quaternion.Euler(0,angle * i,0) * transform.forward * distance);

	    yield return 0; //WaitForSeconds(0.1f);
    }
}