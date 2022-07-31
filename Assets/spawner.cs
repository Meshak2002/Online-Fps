using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] G;
    void Start()
    {
        Vector3 Pose = new Vector3(Random.Range(-270.4f, -248.14f), 0.005f, Random.Range(14.54f, 79.7f));
        foreach (GameObject o in G)
        {
            PhotonNetwork.Instantiate(o.name, Pose, Quaternion.identity);
        }
    }

}