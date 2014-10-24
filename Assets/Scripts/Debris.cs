using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {
	
	public bool HasExploded = false;
	public bool startDebris = true;
	
	private float KillTime = 0f;
	private float ElapsedTime = 0f;
	
	// Use this for initialization
	void Start () {
		
		if(!startDebris) KillTime = Random.Range(12.5f,20f);
		else KillTime = Random.Range(25f,35f);
		
		if(startDebris) {
			transform.rigidbody.AddForce(transform.forward * Random.Range(35f,100f));
			rigidbody.AddTorque(Vector3.one * 10f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(HasExploded) ElapsedTime += Time.deltaTime;
		
		if(ElapsedTime >= KillTime) Destroy(gameObject);
	}
	
	public void StopTimer(bool stop) {
		
		if(!stop) ElapsedTime = 0f;
		HasExploded = !stop;
	}
}
