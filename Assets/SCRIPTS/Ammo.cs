using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public int totammo=30;
    public int ammo=6;
    private Text txt;
    private Text text1;
    public int x;
    private gun_shoot shoot;
    Animator anim;
    PhotonView pv;
    private void Start(){
        txt = GameObject.Find("Totammo").GetComponent<Text>();
        text1 = GameObject.Find("ammo").GetComponent<Text>();
        shoot = this.GetComponent<gun_shoot>();
        anim =GetComponent<Animator>();
        pv = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pv.IsMine)
        {
            txt.text = totammo.ToString();
            text1.text = ammo.ToString();
            if (Input.GetKeyDown(KeyCode.R) && ammo < 6)
            {
                x = 6 - ammo;
                if (totammo >= x)
                {
                    shoot.avoid_rapid = false;
                    anim.SetTrigger("Reload");
                    StartCoroutine(wait());
                    totammo -= x;
                    ammo += x;
                    Debug.Log("1");
                }
                else if (totammo < x && totammo > 0)
                {
                    shoot.avoid_rapid = false;
                    anim.SetBool("Reload", true);
                    StartCoroutine(wait());
                    ammo += totammo;
                    totammo = 0;
                    Debug.Log("2");
                }
            }
        }
    }
    IEnumerator wait(){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Reload",false);
        shoot.avoid_rapid=true;
    }
}
