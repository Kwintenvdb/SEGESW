using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebrisSpawner : MonoBehaviour {
	
	public List<GameObject>		Debris		= new List<GameObject>();
	public int					Amount		= 200;
	
	// Use this for initialization
	void Start () {
	
		for(int i = 0; i < Amount; ++i)
		{
			float x = Random.Range(-250f,250f);
			float z = Random.Range(-250f,250f);
			
			var debrisObj = Debris[Random.Range(0,Debris.Count)];
			debrisObj.GetComponent<MeshCollider>().enabled = true;
			debrisObj.GetComponent<Rigidbody>().isKinematic = false;
			debrisObj.GetComponent<Debris>().startDebris = true;
			
			Vector3 scale = new Vector3(6f,6f,6f);
			debrisObj.transform.localScale = scale;
			Instantiate(debrisObj,new Vector3(x,0f,z),Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up));
		}
		
		Destroy(gameObject);
	}
}
