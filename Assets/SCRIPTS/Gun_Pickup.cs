using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Pickup : MonoBehaviour
{
    Animator ani;
    public void OnTriggerEnter(Collider col){
            if(col.tag=="Player"){
                ani=col.GetComponent<Animator>();
                ani.SetBool("Pistol",true);
            }
    }
}
