using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject parent;


    public void AddTarget()
    {
        parent.GetComponent<CompteurCible>().targetHit++;
    }
}
