using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemy_hlth=10f;
    Animator anim;
    Chase c;
    range_attack ra;
    private AXEdamage ad;
    void Start()
    {
        ad= GameObject.Find("Prop_Lute_01").GetComponent<AXEdamage>();
        anim =GetComponent<Animator>();
        c=GetComponent<Chase>();
        ra=GetComponent<range_attack>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(enemy_hlth==0f){  //die
            anim.enabled=false;
            c.enabled=false;
            ra.enabled=false;
            ad.minus=false;

            Destroy(this.gameObject,20f);
        }
    }
}
