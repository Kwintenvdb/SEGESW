using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float MaxTime = 4f;
	private float ElapsedTime = 0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		ElapsedTime += Time.deltaTime;
		if(ElapsedTime >= MaxTime) Destroy(gameObject);
	}
}
