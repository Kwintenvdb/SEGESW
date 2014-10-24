using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	public Rigidbody Projectile;
	public GameObject Muzzle = null;
	public GameObject Explosion = null;
	public AudioSource Sound = null;
	public AudioClip ExplosionSound = null;
	public GameObject Score = null;
	
	private GameObject[] Targets;
	
	private float MoveSpeed = 7.5f;
	private float RotationSpeed = 6.5f;
	
	private Transform MyTransform;
	private Transform CurrentTarget;
	
	private float Interval = 1f;
	private float ElapsedTime = 0f;
	
	private int Health = 1;
	private EnemySpawner spawner;

	
	// Use this for initialization
	void Awake () {
	
		MyTransform = transform;
	}
	
	void Start () {
	
		Targets = GameObject.FindGameObjectsWithTag("Player");
		spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        // Find closest player
        StartCoroutine("FindPlayer");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		
		if(MyTransform) MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation,
					Quaternion.LookRotation(CurrentTarget.position - MyTransform.position),RotationSpeed * Time.deltaTime);
				
		MyTransform.position += MyTransform.forward * MoveSpeed * Time.deltaTime;
		
		ElapsedTime += Time.deltaTime;
		if (ElapsedTime >= Interval) 
		{
      		Rigidbody clone;
			float velocity = 30f;
      		clone = Instantiate(Projectile, transform.position + transform.forward * 3f, transform.rotation) as Rigidbody;
      		clone.velocity = transform.TransformDirection(Vector3.forward * velocity);
			
			Instantiate(Muzzle,transform.position + transform.forward * 2f,transform.rotation);
			Sound.Play();
			
			ElapsedTime = 0;
      	}
	}

    IEnumerator FindPlayer()
    {
        while (true)
        {
            float dist = 0f;

            if (Targets[0] != null)
            {
                CurrentTarget = Targets[0].transform;
                dist = Vector3.Distance(transform.position, Targets[0].transform.position);
            }

            for (int i = 0; i < Targets.Length; ++i)
            {
                if (Targets[i] != null)
                {
                    if (Vector3.Distance(transform.position, Targets[i].transform.position) < dist)
                    {
                        CurrentTarget = Targets[i].transform;
                    }
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

	void OnCollisionEnter(Collision collObj)
	{
		if(collObj.gameObject.tag == "Bullet" || collObj.gameObject.tag == "Ammo")
		{
			Instantiate(Explosion,transform.position,transform.rotation);
			AudioSource.PlayClipAtPoint(ExplosionSound,transform.position,0.3f);
			Destroy(collObj.gameObject);
			
			Score.GetComponent<Score>().AddScore(5);
			spawner.EnemyList.Remove(gameObject);
			Destroy(gameObject);
		}
	}
}
