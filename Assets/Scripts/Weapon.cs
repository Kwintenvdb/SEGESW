using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	public AudioClip ShotFire = null;
	
	// Private
	private DebrisRing	DebrisRing	= null;
	private float		StartForce	= 2000f;

	// ----------

	void Start () {
		DebrisRing = transform.parent.Find("DebrisRing").GetComponent<DebrisRing> ();
	}

	// ----------

	void Update () {
		if (transform.childCount == 0)
			DebrisRing.HasBullet = false;

		if(Input.GetButtonDown("Fire1")) {
			if(DebrisRing.HasBullet) {
				AudioSource.PlayClipAtPoint(ShotFire,transform.position,0.6f);
				
				Transform Bullet = transform.GetChild(0);
				transform.DetachChildren();

				Bullet.gameObject.AddComponent<Rigidbody>();
				Bullet.GetComponent<Rigidbody>().useGravity = false;
				Bullet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
				Bullet.GetComponent<Rigidbody>().velocity = transform.parent.GetComponent<Rigidbody>().velocity;
				Bullet.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * StartForce);
				
				Bullet.tag = "Bullet";
				Bullet.gameObject.layer = 10;
				Bullet.GetComponent<Wireframe2>().lineColor = new Color(255,0,0);
				DebrisRing.HasBullet = false;
			}
		}
	}
}
