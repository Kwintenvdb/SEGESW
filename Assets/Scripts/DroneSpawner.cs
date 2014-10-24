using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneSpawner : MonoBehaviour {
	
	public GameObject Drone = null;
	
	private float ElapsedTime = 0f;
	private float MaxTime = 10f;
	
	private int MaxDrones = 30;
	
	private List<GameObject> AllDrones = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		ElapsedTime += Time.deltaTime;
	
		int amountOfDrones = AllDrones.Count;
		if(ElapsedTime >= MaxTime && amountOfDrones < MaxDrones)
		{
			Vector3 pos = new Vector3(Random.Range(-245f,245f),0f,Random.Range(-245f,245f));
			transform.position = pos;
			
			AllDrones.Add(Instantiate(Drone,transform.position,Quaternion.identity) as GameObject);
			
			ElapsedTime = 0f;
		}
	}
}
