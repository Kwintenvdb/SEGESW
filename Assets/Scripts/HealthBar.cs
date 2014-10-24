using UnityEngine;
using System.Collections;
 
public class HealthBar : MonoBehaviour {
	
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(0, 0);
    public Vector2 size = new Vector2(125,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    public Texture2D BackDrop;
	public GUIStyle progress_empty, progress_full;
	public GameObject Player = null;
 
    void OnGUI() {
		if(Player != null)
		{
		    GUI.DrawTexture(new Rect(10, 10, (float)BackDrop.width / 2f, (float)BackDrop.height / 2f), BackDrop, ScaleMode.ScaleToFit);

            //draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
                GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex, progress_empty);

                //draw the filled-in part:
                GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
                    GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
                GUI.EndGroup();
            GUI.EndGroup();
		}
    }
 
    void Update() {
       
		if(Player != null) barDisplay = Player.GetComponent<SpaceShip>().Health / 100f;
		
		//if(Player = null) Destroy(gameObject);
    }
}