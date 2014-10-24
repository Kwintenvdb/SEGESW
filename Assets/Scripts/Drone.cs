using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {
	
	public bool HealPlayer = false;
	
	private float ElapsedTime = 0f;
	private float Time2 = 0f;
	private bool startTime = false;
	
	public GameObject emitter = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		ElapsedTime += Time.deltaTime;
		
		if(ElapsedTime >= 1f)
		{
			HealPlayer = true;
			ElapsedTime = 0f;
		}
		else HealPlayer = false;
		
		if(startTime) 
		{
			Time2 += Time.deltaTime;
			if(Time2 >= 15f)
			{
				var list = transform.parent.GetComponent<DronesRing>().DroneList;
				list.Remove(gameObject.collider);
				transform.parent.GetComponent<DronesRing>().CalcPositions();
				Destroy(gameObject);
			}
		}
	}
	
	public void StartEmitter() {
	
		emitter.SetActive(true);
		startTime = true;
	}
}
