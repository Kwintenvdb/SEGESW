using UnityEngine;

public class ShieldPU : MonoBehaviour {

	// Public
	public GameObject	Shield;
	public float 		Force 	= 25;

	// Private
	private Collision 	ColObj 	= null;

	// ----------

	void Update () {
		if (ColObj != null) {
			bool ColIsSpaceShip = false;
			int Objects = 0;
			foreach(Collider col in Physics.OverlapSphere(ColObj.transform.position, 12)) {
				if(col.rigidbody) {
					if(col.CompareTag("Debris") || col.CompareTag("Asteroid") || col.CompareTag("Bullet") || col.CompareTag("Enemy") || (ColIsSpaceShip = col.CompareTag("SpaceShip"))) {
						if(ColIsSpaceShip) if(ColObj.gameObject == col.gameObject) continue;
						Vector3 dir = (col.transform.position - ColObj.transform.position).normalized;
						col.rigidbody.AddForce(dir * Force);
						++Objects;
					}
				}
			}
			if(Objects == 0) {
				GameObject ShieldInstance = Instantiate(Shield, ColObj.transform.position, ColObj.transform.rotation) as GameObject;
				ShieldInstance.transform.parent = ColObj.transform;
				Destroy(gameObject);
			}
		}
	}

	// ----------

	void OnCollisionEnter(Collision colObj) {
		if (colObj.gameObject.tag == "Player") {
			Debug.Log("hit");
			collider.enabled = false;
			renderer.enabled = false;
			ColObj = colObj;
		}
	}
}