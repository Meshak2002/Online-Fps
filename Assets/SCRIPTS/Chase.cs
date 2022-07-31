using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float Sspeed=30f;
    public float Mspeed=1.5f;
    public bool move=true;
    private Quaternion targetangle;

    private void Update(){
        
        targetangle=Quaternion.LookRotation(player.transform.position-this.transform.position);  //this line will come for tracking moving target
        this.transform.rotation=Quaternion.RotateTowards(this.transform.rotation,targetangle,Sspeed*Time.deltaTime); //this is just to track a static point 
    }
}
