using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurCible : MonoBehaviour
{
    public int targetHit = 0;
    private bool won = false;
    void Update()
    {
        if (targetHit == 10 && !won)
        {
            Debug.Log("win");
            won = true;
        }
    }
}
