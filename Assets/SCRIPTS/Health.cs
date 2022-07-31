using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private ProgressBarPro bar;
    public float playerlyf = 1f;
    PhotonView pv;
    void Start()
    {
        bar = GameObject.Find("HorizontalBoxGradient").GetComponent<ProgressBarPro>();
        bar.Value=1f;
        pv = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            bar.Value = playerlyf;
            if (bar.Value == 0)
            {
                this.enabled = false;
            }
        }
    }
}
