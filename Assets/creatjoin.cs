using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class creatjoin : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TMP_InputField cr;
    public TMP_InputField jo;

    // Update is called once per frame
    public void create()
    {
        PhotonNetwork.CreateRoom(cr.text);
    }
    public void join()
    {
        PhotonNetwork.JoinRoom(jo.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("DesertScene");
    }
}
