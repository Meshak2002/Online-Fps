using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class charAngle : MonoBehaviour
{
    // Start is called before the first frame update
    private float camangle;
    private float speed=25f;
    private Camera camer;
    PhotonView pv;
    void Start()
    {
        camer=GameObject.Find("Main Camera").GetComponent<Camera>();
        pv = this.gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pv.IsMine)
        {
            camangle = camer.transform.rotation.eulerAngles.y;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, camangle, 0), speed * Time.fixedDeltaTime);
        }
    }
}
