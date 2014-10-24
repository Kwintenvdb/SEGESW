using UnityEngine;

public class Shield : MonoBehaviour {

	// Public
	public float	LifeTime	= 30;

	// Private
	private float	PassedTime 	= 0;

	// ----------

	void Update () {
		transform.Rotate(Vector3.up * 25 * Time.deltaTime);
		if ((PassedTime += Time.deltaTime) > LifeTime)
			Destroy (gameObject);
	}
}
