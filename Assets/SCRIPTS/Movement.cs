using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 move=Vector3.zero;
    Animator anim;
    PhotonView pv;
    
    void Start()
    {
        anim=GetComponent<Animator>();
        pv = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pv.IsMine)
        {
            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");
            anim.SetFloat("Inputy", move.z);
            anim.SetFloat("Inputx", move.x);
        }
    }
}
