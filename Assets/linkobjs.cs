using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class linkobjs : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playepos,playang;
    private Cinemachine.CinemachineFreeLook cF;
    private PhotonView pv;

    // Update is called once per frame
    private void Start()
    {
        pv = this.GetComponent<PhotonView>();
        playepos = this.transform.parent.gameObject.transform;
        playang = playepos.transform.GetChild(0).gameObject.transform;
        if (pv.IsMine)
        {
            cF = this.gameObject.GetComponent<Cinemachine.CinemachineFreeLook>();
            cF.enabled = true;
            cF.Follow = playepos;
            cF.LookAt = playang;
        }
    }
    void Update()
    { 
    }
}
