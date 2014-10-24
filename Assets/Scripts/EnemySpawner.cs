using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject EnemyType = null;
	public GameObject Player = null;
	public float SpawnInterval = 3.5f;
	
	private float ElapsedTime = 1.5f;
	public List<GameObject> EnemyList = new List<GameObject>();
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Player != null)
		{
		ElapsedTime += Time.deltaTime;
		
		int maxEnemies = 100;
		int enemyCount = EnemyList.Count;
			Debug.Log(enemyCount);
		if(ElapsedTime >= SpawnInterval && enemyCount < maxEnemies)
		{
			float offsetRadius = 50f;
			Vector3 pos = RandomCircle(Player.transform.position,offsetRadius);
			if(pos.x >= 250) pos.x -= 30;
			if(pos.x <= -250) pos.x += 30;
			if(pos.z >= 250) pos.z -= 30;
			if(pos.z <= -250) pos.z += 30;
			pos.y = 0f;
			
			transform.position = pos;
			
			Enemy enemyObj = EnemyType.GetComponent<Enemy>();
			
			EnemyList.Add(Instantiate(enemyObj, transform.position, Quaternion.identity) as GameObject);
			
			ElapsedTime = 0f;
		}
		}
		else Destroy(gameObject);
	}
	
	private Vector3 RandomCircle(Vector3 center, float radius) {
    	// create random angle between 0 to 360 degrees
    	var ang = Random.value * 360;
    	Vector3 pos;
    	pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
    	pos.y = 0;
    	pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
    	return pos;
	}
}
