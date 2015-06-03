using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	// Public
	
	public Transform Player = null;
	public Vector2 ScreenMin { get; private set; }
	public Vector2 ScreenMax { get; private set; }
	
	public GameObject PauseScreen = null;
	
	public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
	
	// ----------
	
	void FixedUpdate () {
		
		if(Player)
		{
		Vector3 playerPos = Player.position;

  		//transform.position = playerPos;
		
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(playerPos);
        Vector3 delta = playerPos - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
	
	void Update(){
	
		if(Input.GetKeyDown(KeyCode.Escape)){
  			if(Time.timeScale == 1){
      			Time.timeScale = 0;
				PauseScreen.SetActive(true);
   			}
   			else {
      			Time.timeScale = 1f;
				PauseScreen.SetActive(false);
   			}
		}
	}
	
	void Awake () {
		Vector3	camPos = Camera.main.transform.position;
		
		//Camera is rotated 90 degrees around the x axis resulting in an Y axis that turns into an Z axis.
		Vector3 min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, camPos.y));
		ScreenMin = new Vector2(min.x, min.z);
		
		Vector3 max	= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camPos.y));
		ScreenMax = new Vector2(max.x, max.z);
	}
}
