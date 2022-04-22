using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurCibles : MonoBehaviour
{
    public int targetHit = 0;
    private bool won = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetHit == 10 && !won)
        {
            Debug.Log("Win");
            won = true;
        }
            
    }
}
