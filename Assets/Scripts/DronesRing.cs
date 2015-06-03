using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DronesRing : MonoBehaviour {
	
	public List<Collider> DroneList = new List<Collider>();
	private SpaceShip Ship = null;
	
	// Use this for initialization
	void Start () {
	
		Ship = transform.parent.GetComponent<SpaceShip>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(DroneList.Count < 30){
			foreach(Collider collider in Physics.OverlapSphere(transform.position, 12)) {
				if(collider.CompareTag("DronePickup")) {
					collider.transform.parent = transform;
					Destroy(collider.GetComponent<Rigidbody>());
					collider.tag = "Drone";
					collider.GetComponent<BoxCollider>().enabled = false;
					
					collider.GetComponent<Drone>().StartEmitter();
					collider.GetComponent<Drone>().transform.Find("Lightning Emitter").GetComponent<LightningBolt>().target = transform;
					
					DroneList.Add(collider);
					
					CalcPositions();
				}
			}
		}
		
		int heal = 1;
		for(int i = 0; i < DroneList.Count; ++i)
		{
			if(DroneList[i] != null) if(DroneList[i].GetComponent<Drone>().HealPlayer) Ship.Health += heal;
		}
		
		transform.Rotate(Vector3.up * -25 * Time.deltaTime);
	}
	
	public void CalcPositions() {
		
		float distance = 15f;
		float angle = 360.0f / DroneList.Count;
		for(int i=0; i < DroneList.Count; ++i)
		{
			if(DroneList[i] != null) 
			{
				DroneList[i].transform.position = transform.position + (Quaternion.Euler(0,angle * i,0) * transform.forward * distance);
			
				Vector3 vec = (DroneList[i].transform.position - Ship.transform.position).normalized;
				DroneList[i].transform.rotation = Quaternion.LookRotation(vec) * Quaternion.Euler(0, -90, 0);
			}
		}
	}
}
