using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	
	// Public
	public GameObject 	Explosion;
	
	public float		StartForce		= 0,
						RotSpeed		= 0;
	
	// Private
	private SpaceShip	SpaceShipObj	= null;
	
	private float 		Health			= 0;

	// ----------
	
	void Start () {
		GameObject tmpGameObj = GameObject.FindWithTag("Player");
		if(tmpGameObj) SpaceShipObj = tmpGameObj.GetComponent<SpaceShip>();
		//else Debug.Log("- Asteroid.cs - SpaceShipObj is empty!");
		Health = 10 * rigidbody.mass;
			
		rigidbody.AddForce(transform.forward * StartForce);
		rigidbody.AddTorque(Vector3.one * RotSpeed);
	}
	
	// ----------
	
	void FixedUpdate () {
		if(SpaceShipObj) {
			float distance	= Vector3.Distance(SpaceShipObj.transform.position, transform.position) / 300;
			Vector3 force	= (SpaceShipObj.transform.position - transform.position) * distance;
			rigidbody.AddForce(force);
		}
	}
	
	// ----------
	
	//void OnCollisionEnter(Collision colObj) {
	//	//Gui guiObj = GameObject.FindWithTag("Gui").GetComponent<Gui>();
	//	//Bullet bulletObj = colObj.gameObject.GetComponent<Bullet>();
	//	//
	//	//switch(colObj.transform.tag)
	//	//{
	//	//case "Bullet":
	//	//	if((Health -= bulletObj.Damage) <= 0) {
	//	//		guiObj.Score += (int)(10.0f * rigidbody.mass);
	//	//		Instantiate(Explosion, transform.position, Quaternion.identity);
	//	//		StartForce = RotSpeed = 0;
	//	//		Destroy(gameObject);
	//	//	}
	//	//	break;
	//	//}
	//}
}

//		GameObject tmpGui = GameObject.FindWithTag("Gui");
//		if(tmpGui) GuiObj = tmpGui.GetComponent<Gui>();
//		else Debug.Log("- Asteroid.cs - tmpGui is empty!");