using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour {
	
	// Public
	public GameObject 			Player			= null;
	
	public List<GameObject>		Asteroids		= new List<GameObject>();
	
	public float 				SpawnInterval	= 4f;
	
	public int					ColCheckRange	= 6,
								MinStartForce	= 60,
								MaxStartForce	= 275, 
								MinRotSpeed		= 12,
								MaxRotSpeed		= 24,
								Offset			= 3,
								MaxAsteroids	= 15;
	
	// Private
	//private	Vector3 			MinMaxPos		= new Vector3(0,0,0);
	
	private	float 				ElapsedTime		= 1.5f;
	
	private List<GameObject>	AllAsteroids	= new List<GameObject>();
	
	// ----------
	
	void Start () {
		
	}
	
	// ----------
	
	void Update () {
		
		if(Player != null)
		{
		ElapsedTime	+= Time.deltaTime;
		int asteroidsCount = AllAsteroids.Count;
		if(ElapsedTime >= SpawnInterval && asteroidsCount < MaxAsteroids)
		{
			float offsetRadius = 50f;
			Vector3 pos = RandomCircle(Player.transform.position,offsetRadius);
			pos.y = 0f;
			
			transform.position = pos;
			
			AsteroidExploding asteroidObj	= Asteroids[Random.Range(0, Asteroids.Count)].GetComponent<AsteroidExploding>();
			asteroidObj.StartForce	= Random.Range(MinStartForce, MaxStartForce) * asteroidObj.rigidbody.mass;
			asteroidObj.RotSpeed	= Random.Range(MinRotSpeed, MaxRotSpeed) * asteroidObj.rigidbody.mass;
			
			AllAsteroids.Add(Instantiate(asteroidObj, transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up))
					as GameObject);

			//if(Side == SideEnum.L || Side == SideEnum.R) 
			//	transform.position = new Vector3(MinMaxPos.z, 0, Random.Range((int)MinMaxPos.x, (int)MinMaxPos.y));
			//else transform.position = new Vector3(Random.Range((int)MinMaxPos.x, (int)MinMaxPos.y), transform.position.y, MinMaxPos.z);
			ElapsedTime = 0;
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