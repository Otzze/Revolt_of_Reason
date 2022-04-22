using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddTarget()
    {
        parent.GetComponent<CompteurCibles>().targetHit++;
    }
}
