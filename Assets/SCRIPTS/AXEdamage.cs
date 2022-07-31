using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXEdamage : MonoBehaviour
{
    // Start is called before the first frame update
    public bool minus=false;
    public Health playerH;
    private void Start()
    {
        playerH = GameObject.Find("Player").GetComponent<Health>();
    }

    public void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player") && minus==true){
                  
                    playerH.playerlyf-=0.1f;
                    //StartCoroutine(waitt());
        }
    }
   
}
