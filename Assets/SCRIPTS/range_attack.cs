using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_attack : MonoBehaviour
{
    // Start is called before the first frame update
    private AXEdamage axd;
    Chase mov;
    Animator anim;
    public bool rapid = true;
    public int random_;
    public float st, en;
    private int z=0;
    private string a;

    private void Start(){
        axd = GameObject.Find("Prop_Lute_01").GetComponent<AXEdamage>();
        anim=GetComponent<Animator>();
        mov=GetComponent<Chase>();
        
    }
    private void Update(){
        if (z < 1)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack 360 Low") || anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Horizontal") || anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Downward"))
            {
                Debug.Log(anim.GetCurrentAnimatorStateInfo(0) + "Success");
                StartCoroutine(minus());
                z = 1;
            }
        }

    }
    public void OnTriggerStay(Collider col){
        if(col.CompareTag("Player") && rapid==true){
            rapid = false;
            
                StartCoroutine(Damage());
                
        }
    }
    public void OnTriggerExit(Collider coll){
        if(coll.CompareTag("Player")){
            anim.SetBool("idle", false);
            anim.SetBool("Run", true);
        }
    }
    IEnumerator waitmove(){
        yield return new WaitForSeconds(1);
        mov.move=true;
    }
    private void Randomattack(){
        
        random_=Random.Range(0,3);

        if(random_==0){
           
            st = .10f;
            en = .12f;
            a = "A";
        }
        if(random_==1){
            
            st = .11f;
            en = .13f;
            a = "B";
        }
        if (random_ == 2)
        {
            st = 0.13f;
            en = 0.15f;
            a = "C";
        }

        }
    
    IEnumerator Damage(){
            anim.SetBool("Run", false);
            Randomattack();
            anim.SetBool("idle", false);
            anim.SetTrigger(a);
            yield return new WaitForSeconds(4);
            z=0;
            rapid = true;
                    
    }
    IEnumerator minus()
    {
        yield return new WaitForSeconds(st);
        axd.minus = true;
        yield return new WaitForSeconds(en);
        axd.minus = false;
        //anim.SetBool("idle", true);
    }
}