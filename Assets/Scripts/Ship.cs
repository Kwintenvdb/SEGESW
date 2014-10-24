using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public	GameObject	Explosion	= null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision colObj) {
		switch(colObj.transform.tag)
		{
		//case "Asteroid":
		//	Health -= (int)(colObj.rigidbody.mass * 10);
		//	foreach(ContactPoint contact in colObj.contacts)
		//		Instantiate(Sparkles, contact.point, Quaternion.identity);
		//	break;
		//	
		case "Bullet":
			foreach(ContactPoint contact in colObj.contacts)
			{
				Instantiate(Explosion, contact.point, transform.rotation);
			}
			transform.parent.GetComponent<SpaceShip>().Health -= 10;
			Destroy(colObj.gameObject);
			break;
		}
	}
}
