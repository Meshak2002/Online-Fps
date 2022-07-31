using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class gun_shoot : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public bool have;
    private Ammo am;
    private GameObject shootangle;
    private GameObject normalangle;
    public bool avoid_rapid=true;
    private GameObject muzleflash;
    private GameObject camer;
    public RaycastHit hit;
    private float shoot_range=100f;
    public GameObject impacteff;
    PhotonView pv;
    void Start()
    {
        am = this.GetComponent<Ammo>();
        shootangle = GameObject.Find("pistol_shoot");
        normalangle = GameObject.Find("pistol_1");
        muzleflash = GameObject.Find("MuzzleFlash7");
        anim=GetComponent<Animator>();
        camer = GameObject.Find("Main Camera");
        pv = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            have = anim.GetBool("Pistol");
            if (have == true && am.ammo > 0)
            { //have=If u have a pistol you can shoot
                if (Input.GetMouseButtonDown(0) && avoid_rapid == true)
                {
                    avoid_rapid = false;
                    StartCoroutine(shoot());
                }
            }
            if (have == true && Input.GetMouseButton(1))
            {
                anim.SetBool("Aim", true);
                if (am.ammo > 0)
                { //have=If u have a pistol you can shoot
                    if (Input.GetMouseButtonDown(0) && avoid_rapid == true)
                    {
                        avoid_rapid = false;
                        StartCoroutine(shoot());
                    }
                }
            }
            else
            {
                anim.SetBool("Aim", false);
            }
        }
    }
    IEnumerator shoot(){
        normalangle.SetActive(false);
        shootangle.SetActive(true);
        anim.SetBool("Shoot",true);
        am.ammo-=1;
        yield return new WaitForSeconds(0.6f);

        muzleflash.SetActive(true);
        if(Physics.Raycast(camer.transform.position,camer.transform.forward,out hit,shoot_range)){
            if(hit.collider.CompareTag("Enemy")){
                hit.collider.GetComponent<enHealth>().enemy_hlth -= 2.5f;
            }
            else{
                GameObject go=Instantiate(impacteff,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(go,3f);
            }
        }

        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Shoot",false);
        normalangle.SetActive(true);
        shootangle.SetActive(false);
        avoid_rapid=true;
        muzleflash.SetActive(false);
    }
}
