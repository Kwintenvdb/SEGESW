using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	
	public GameObject Shield = null;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Fire3"))
		{
			Instantiate(Shield,transform.parent.position,Quaternion.identity);
		}
	}
	
	void OnCollisionEnter(Collision colObj) {
			
		//case "Bullet":
		//	GameObject.FindWithTag("SpaceShip").GetComponent<SpaceShip>().Health += Health / 2;
		//	Destroy(gameObject);
		//	break;
	}
	
}
